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
    public float jumpForce;
    public float impactThreshold;

    [Header("Runtime")]
    Vector3 newVelocity;
    bool isGrounded = false;
    bool isJumping = false;
    bool inWater = false;
    float vyCache;

    //incase we want a score
    private int count;
    public TextMeshProUGUI countText;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        //rigidbody call
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
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

        }
    }
}
