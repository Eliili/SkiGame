using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3f; // Speed of the player movement
    public float turnSpeed = 90f;
    public float boostSpeed = 50f;
    public float brakeSpeed = 0.5f;
    public float boostDuration = 1f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody rb; // Reference to the Rigidbody2D component
    private bool isGrounded = false;
    private bool isBoosting = false;
    private bool isBraking = false;

    void Start()
    {
        // Get the Rigidbody2D component attached to the player object
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Check if skier is grounded
        isGrounded = Physics.Raycast(groundCheck.position, Vector3.down, 0.1f, groundLayer);
       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(SpeedBoost());
            
            Debug.Log("Is boosting");
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            isBraking = true;
            //speed = brakeSpeed;
            Debug.Log("Is braking");
        }
        else
        {
            isBraking = false;
        }
        
        // Get horizontal input from the player
        float moveHorizontal = Input.GetAxis("Horizontal");

        float currentSpeed = isBraking ? brakeSpeed : speed;

        // Create a movement vector only along the X-axis based on the input and speed
        Vector3 movement = new Vector3(moveHorizontal, 0f, 0f) * speed * Time.deltaTime;

        // Move the player by directly changing its position
        rb.MovePosition(transform.position + movement);

        if (isGrounded)
        {
            transform.Rotate(Vector3.up,  moveHorizontal * turnSpeed * Time.deltaTime);
        }
    }

    private IEnumerator SpeedBoost()
    {
        isBoosting = true;
        float originalSpeed = speed * boostSpeed;
        speed = boostSpeed;

        yield return new WaitForSeconds(boostDuration);

        speed = originalSpeed;
        isBoosting = false;
        Debug.Log("Boost stopped");
    }

   // private void OnCollisionStay(Collision other)
   // {
   //     isGrounded = true;
    //}
}
