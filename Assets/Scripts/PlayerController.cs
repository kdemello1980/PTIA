using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float WalkSpeed = 3.0f;
    public float RunSpeed = 5.0f;
    private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        // The player gets "stuck" in the air after going up a hill on Terrain when going back down.
        // It will move horizontally, but stay at the same Y value, probably because the Y component 
        // of the direction vector is always 0 here.
        // Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        // characterController.Move(direction * WalkSpeed * Time.deltaTime);


        // This points the character in the direction of the motion, independent of
        // how the camera is aimed. The movement transform of movement appears to be global, instead of
        // local as a rigidbody might behave.
        // I think I can make this work.
        // if (direction != Vector3.zero)
        // {
        // gameObject.transform.forward = direction;
        // }
    }
}
