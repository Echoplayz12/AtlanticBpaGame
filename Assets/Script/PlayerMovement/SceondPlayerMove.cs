using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceondPlayerMove : MonoBehaviour
{
    [Header("References")]
    public Rigidbody rb;
    public Transform head;
    public Camera cameraPos;

    [Header("Configuration")]
    public float walkSpeed;
    public float runSpeed;
    public float jumpForce;
    public float impactThreshold;

    [Header("Runtime")]
    Vector3 newVelocity;
    bool isGrouned = false;
    bool isJumping = false;
    float vyCache;

    // Start is called before the first frame update
    void Start()
    {
       //makes the cursor not visible and locks it

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * 2f);

        newVelocity = Vector3.up * rb.velocity.y;
        float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
        newVelocity.x = Input.GetAxis("Horizontal") * speed;
        newVelocity.z = Input.GetAxis("Vertical") * speed;
        if (isGrouned)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

                rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            }
        }
    }
    void FixedUpdate()
    {
        rb.velocity = transform.TransformDirection(newVelocity);

        /*if(Physics.Raycast (Transform.position, Vector3.down, out RaycastHit hit, if))
        {
            isGrouned = true;
        }
        else
        {
            isGrouned = false;
        }
        */
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
        isGrouned = true;
        isJumping = false;
    }
    void OnCollisionExit(Collision collision)
    {
        isGrouned = false;
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
