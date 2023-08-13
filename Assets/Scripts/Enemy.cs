using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Rigidbody enemyRb;
    protected GameObject player;
    [SerializeField] protected float speed;
    [SerializeField] protected Vector3 lookDirection;

    // We don't want to start hunting until we've reached a minimum height
    // over the ground. If we apply a Sphere Collider to a cube for the enemy,
    // it is going to require a height > 0 to accommodate the additional volume
    // the collider requires around the cube.
    protected float height = 0.90f;
    protected float floor = -10.0f;
    [SerializeField] protected bool onGround = false;
    // public GameObject floor;

    // Start is called before the first frame update
    protected void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    protected void Update()
    {
        HuntPlayer();
    }

    protected void HuntPlayer()
    {
        if (transform.position.y < floor)
                Destroy(gameObject);

        if(onGround)
        {
            // Somehow this results in 2 bugs. 1) the player moves as the enemies approach, and 
            // 2) the enemies initially retreat as the player approaches.
            lookDirection = (player.transform.position - transform.position).normalized;
            enemyRb.AddForce(lookDirection * speed, ForceMode.Force);
        }
        else
        {
            if (transform.position.y <= height)
                onGround = true;
        }
    }

    // Change onGround to true once the Rigidbody has collided with 
    // an object tagged "Ground"
    private void OnCollisionEnter(Collision other) 
    {
        if (!onGround && other.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }
}