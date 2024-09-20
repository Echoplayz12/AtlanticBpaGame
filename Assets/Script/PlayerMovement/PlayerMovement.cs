using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float walkSpeed;
    public float runSpeed;
    public float gDrag;

    public float startYScale;
    public float crouchSpeed;
    public float crouchYScale;

    public float jumpForce;
    public float impactThreshold;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;


    public Transform body;

    float horizantalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;


    [Header("Runtime")]
    bool isGrounded;
    bool isJumping;
    bool inWater;
    float vyCache;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    // Update is called once per frame
    private void Update()
    {
        ///ground check
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        
        PlyerInput();


        //drag handler
        if (isGrounded)
        {
            rb.drag = gDrag;
            //jumping condition
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = new Vector3(rb.velocity.x, 1f, rb.velocity.z);
                rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            }
        }
        else
        {
            rb.drag = 0;
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

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void PlyerInput()
    {
        horizantalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

    }

    private void MovePlayer()
    {
        moveDirection = body.forward * verticalInput + body.right * horizantalInput;

        rb.AddForce(moveDirection.normalized * walkSpeed * 10f, ForceMode.Force);
    }
}
