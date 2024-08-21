using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rpm;
    [SerializeField] private float horsePower = 0;
    [SerializeField] private float turnSpeed = 45.0f;
    private float horizontalInput;
    private float verticalInput;
    private Rigidbody playerRb;
    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] List<WheelCollider> wheels;
    private int wheelsOnGround;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if(IsOnGround())
        {
            // Moves vehicle based on vertical input
            //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            playerRb.AddRelativeForce(Vector3.forward * horsePower * verticalInput);
            // Moves vehicle based on horizontal input
            transform.Rotate(Vector3.up, Time.deltaTime * horizontalInput * turnSpeed);
            speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 3.6f);

            speedometerText.SetText("Speed: " + speed + "km/h");
            rpm = Mathf.Round((speed % 30) * 40);
            rpmText.SetText("RPM: " + rpm);
        }
    }

    private bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach(WheelCollider wheel in wheels)
        {
            if(wheel.isGrounded)
                wheelsOnGround++;
        }

        return wheelsOnGround == 4;
    }
}
