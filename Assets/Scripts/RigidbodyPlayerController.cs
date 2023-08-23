using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyPlayerController : Actor
{
    // User inputs
    private float mouseInputX;
    private float mouseInputY;
    public float horizontalInput;
    public float verticalInput;
    [SerializeField] private KeyCode jumpKey;
    [SerializeField] private float jumpForce;
    [SerializeField] private bool onGround;
    public float slowDownFactor = 1000.0f;

    // Starting position and rotation
    private Vector3 startingPosition;
    private Quaternion startingRotation;

    // Velocity and maximum velocity
    [SerializeField] private float velocity = 10.0f;
    [SerializeField] private float maxVelocity = 20.0f;

    // Player Rigidbody
    // private Rigidbody playerRb;

    // Position of the player in the previous frame
    private Vector3 playerRbPositionLastFrame;

    // Transform that stores the player's forward direction
    private Transform orientation;

    // The vector AddForce is applied to to move the player
    Vector3 moveDirection;


    // Start is called before the first frame update
    void Start()
    {
        // playerRb = GetComponent<Rigidbody>();
        // startingPosition = transform.position;
        // startingRotation = transform.rotation;
        orientation = GameObject.Find("PlayerOrientation").GetComponent<Transform>();
        onGround = true;
        Physics.gravity = new Vector3(0, -10.0f, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // transform.rotation = orientation.rotation;
        MovePlayerWithKeyboard();
        if (Input.GetKeyDown(jumpKey))
        {
            Jump();
        }
    }

    void LateUpdate()
    {
        // playerRbPositionLastFrame = playerRb.transform.position;
    }


    // Move the player
    void MovePlayerWithKeyboard()
    {
        if (onGround)
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");

            moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
            playerRb.AddForce(moveDirection.normalized * velocity, ForceMode.Force);

            if (playerRb.velocity.magnitude > maxVelocity)
            {
                playerRb.AddForce(moveDirection.normalized * -velocity, ForceMode.Force);
            }
            // SlowDown();
        }
    }

    // Slow down
    void SlowDown()
    {
        if (horizontalInput == 0 && verticalInput == 0)
        {
            playerRb.AddForce(-moveDirection.normalized * slowDownFactor * velocity, ForceMode.Force);
            // playerRb.velocity = new Vector3(0, 0, 0);
        }
    }

    // Jump
    void Jump()
    {
        if (onGround)
        {
            onGround = false;
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }

    // Land
    private void OnCollisionEnter(Collision other)
    {
        if (!onGround && other.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }

    // Spin
    // private void Spin(KeyCode code)
    // {
    //     if (code == KeyCode.Q)
    //     {
    //         playerRb.AddTorque(-orientation.right);
    //     }
    //     if (code == KeyCode.E)
    //     {
    //         playerRb.AddTorque(orientation.right);
    //     }
    // }
} // end