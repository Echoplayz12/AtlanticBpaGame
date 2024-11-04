using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Sliding : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public Transform playerObject;
    private Rigidbody rb;
    private PlayerMovement PM;

    [Header("Sliding")]
    public float maxSlideTime;
    public float slideForce;
    public float slideTimer;

    public float slideYScale;
    private float StartYScale;

    [Header("Input")]
    public KeyCode slideKey = KeyCode.LeftControl;
    private float horizontalInput;
    private float verticalInput;

    private bool isSliding;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        PM = GetComponent<PlayerMovement>();

        StartYScale = playerObject.localScale.y;
    }
    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(slideKey) && (horizontalInput != 0 || verticalInput != 0))
        {
            StartSlide();
        }
        if (Input.GetKeyUp(slideKey) && isSliding)
        {
            StopSliding();
        }
    }
    private void StartSlide()
    {
        isSliding = true;

        playerObject.localScale = new Vector3(playerObject.localScale.x, slideYScale, playerObject.localScale.z);
        rb.AddForce(Vector3.down * 5, ForceMode.Impulse);

        slideTimer = maxSlideTime;
    }
    private void FixedUpdate()
    {
        if (isSliding) 
        {
            SlidingMovement();
        }
    }

    private void SlidingMovement()
    {
        Vector3 inputDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(inputDirection.normalized * slideForce, ForceMode.Force);

        slideTimer -= Time.deltaTime;

        if (slideTimer <= 0)
        {
            StopSliding();
        }
    }
    private void StopSliding()
    {
        isSliding = false;

        playerObject.localScale = new Vector3(playerObject.localScale.x, StartYScale, playerObject.localScale.z);
    }



}
