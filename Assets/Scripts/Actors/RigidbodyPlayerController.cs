using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using TMPro;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyPlayerController : Actor // INHERITANCE
{
    // Score text
    public TMP_Text scoreText;
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

    // Position of the player in the previous frame
    private Vector3 playerGameObjectPositionLastFrame;

    // Transform that stores the player's forward direction
    private Transform orientation;

    // The vector AddForce is applied to to move the player
    Vector3 moveDirection;


    // Start is called before the first frame update
    void Start()
    {
        orientation = GameObject.Find("PlayerOrientation").GetComponent<Transform>();
        onGround = true;
        Physics.gravity = new Vector3(0, -10.0f, 0);
        ActorVolume = 2.5f;
        scoreText.text = "Remaining Volume: " + ActorVolume;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // transform.rotation = orientation.rotation;
        Move();
        if (Input.GetKeyDown(jumpKey))
        {
            Jump();
        }
    }

    void LateUpdate()
    {
        // playerGameObjectPositionLastFrame = playerGameObject.transform.position;
    }


    // Move the player
    void Move()
    {
        if (onGround)
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");

            moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
            GetComponent<Rigidbody>().AddForce(moveDirection.normalized * velocity, ForceMode.Force);

            if (GetComponent<Rigidbody>().velocity.magnitude > maxVelocity)
            {
                GetComponent<Rigidbody>().AddForce(moveDirection.normalized * -velocity, ForceMode.Force);
            }
            // SlowDown();
        }
    }

    // Slow down
    void SlowDown()
    {
        if (horizontalInput == 0 && verticalInput == 0)
        {
            GetComponent<Rigidbody>().AddForce(-moveDirection.normalized * slowDownFactor * velocity, ForceMode.Force);
            // playerGameObject.velocity = new Vector3(0, 0, 0);
        }
    }

    // Jump
    void Jump()
    {
        if (onGround)
        {
            onGround = false;
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
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

    // We should never need this.
    public override void Consume(Collision other) { }
} // end