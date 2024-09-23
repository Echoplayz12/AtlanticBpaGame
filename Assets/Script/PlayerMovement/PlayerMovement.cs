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

    public float crouchSpeed;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode runKey = KeyCode.LeftShift;
    public KeyCode crouchKey = KeyCode.LeftControl;

    [Header("Ground Check")]
    public float crouchYScale;
    public float startYScale;
    public float playerHeight;
    public LayerMask whatIsGround;


    public Transform body;

    float horizantalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;


    [Header("Runtime")]
    bool isGrounded = false;
    bool readyJump;
    bool inWater = true;
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
        SpeedCtrl();

        //drag handler
        if (isGrounded)
        {
            rb.drag = gDrag;
        }
        else
        {
            rb.drag = 0;
        }
        //crouching
        if (Input.GetKeyDown(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);

            //change the movespeed to crouchspeed
        }
        if(Input.GetKeyUp(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
        }
        if ()
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void PlyerInput()
    {
        horizantalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        //if jumping statment
        if (Input.GetKeyDown(jumpKey) && readyJump && isGrounded)
        {
            Jumping();

            Invoke(nameof(RestJumping), jumpCooldown);
        }
    }

    private void MovePlayer()
    {
        moveDirection = body.forward * verticalInput + body.right * horizantalInput;

        //on ground
        if (isGrounded)
        {
            rb.AddForce(moveDirection.normalized * walkSpeed * 10f, ForceMode.Force);
        }
        else if (!isGrounded)
        {
            rb.AddForce(moveDirection.normalized * walkSpeed * 10f * airMultiplier, ForceMode.Force);
        }
    }

    private void SpeedCtrl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //limit the velocity or speed of player to specified value
        if (flatVel.magnitude > walkSpeed)
        {
            Vector3 limitVel = flatVel.normalized * walkSpeed;
            rb.velocity = new Vector3(limitVel.x, rb.velocity.y, limitVel.z);
        }
    }
    private void Jumping()
    {
        //reset the y value to 0 so it does not feel like your on moon when jumping 
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void RestJumping()
    {
        readyJump = true;
    }
}
