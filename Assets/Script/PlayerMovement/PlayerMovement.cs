using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    [Header("References")]
    public Rigidbody rb;
    public Transform head;
    public Camera cameraPos;

    [Header("Configuration")]
    public float walkSpeed;

    public float runSpeed;

    public float startYScale;
    public float crouchSpeed;
    public float crouchYScale;
   
    public float jumpForce;

    public float impactThreshold;

    [Header("Runtime")]
    Vector3 newVelocity;
    bool isGrounded = false;
    bool isJumping = false;
    bool inWater = false;

    float vyCache;

    //incase we want a score
    //private int count;
    //public TextMeshProUGUI countText;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        //rigidbody call
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        startYScale = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * 2f);

        newVelocity = Vector3.up * rb.velocity.y;
        //if input key-left shift- can run, else walk
        float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
        newVelocity.x = Input.GetAxis("Horizontal") * speed;
        newVelocity.z = Input.GetAxis("Vertical") * speed;

        //jumping
        if(isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = new Vector3(rb.velocity.x, 1f, rb.velocity.z);
                rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            }
        }
        //crouching
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);

            //change the movespeed to crouchspeed
        }
        if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
        }
    }
    void FixedUpdate()
    {
        rb.velocity = transform.TransformDirection(newVelocity);
        vyCache = rb.velocity.y;
    }
    void LateUpdate()
    {
        //vertical rotation
        Vector3 e = head.eulerAngles;
        e.x -= Input.GetAxis("Mouse Y") * 2f;
        e.x = RestrictAngle(e.x, -90, 90f);
        head.eulerAngles = e;
    }
    public static float RestrictAngle(float angle, float angleMin, float angleMax)
    {
        //clamp the vertical head roation/ I could of used Mathf.Clamp but didn't 
        if (angle > 180)
            angle -= 360;
        else if (angle < -180)
            angle += 360;
        if (angle > angleMax)
            angle = angleMax;
        if (angle < angleMin)
            angle = angleMin;
        return angle;
    }
    void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
        isJumping = false;
    }
    void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
    void OnCollisionEnter(Collision collision)
    {   // movment 
        if (Vector3.Dot(collision.GetContact(0).normal, Vector3.up) < .5f)
        {
            if (rb.velocity.y < -5f)
            {
                rb.velocity = Vector3.up * rb.velocity.y;
                return;
            }
        }

        float acceleration = (rb.velocity.y - vyCache) / Time.fixedDeltaTime;
        float impactForce = rb.mass * Mathf.Abs(acceleration);

        if (impactForce >= impactThreshold)
        {
            SceneManager.LoadScene(1);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

}
