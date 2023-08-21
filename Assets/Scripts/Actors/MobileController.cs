using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileController : Actor
{
    // Force multiplier. This is applied to AddForce(). Arbitrarily defaulted
    // to 1.0f.
    protected virtual float ForceMultiplier { get; set; } = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        IsMobile = true;
    }

    // Update is called once per frame
    // void Update()
    // {

    // }

    // All of our motion involves Rigidbody physics
    public void FixedUpdate()
    {
        // if (DataManager.Instance.IsPaused)
        // {
        //     Debug.Log("foo");
        // }

    }

    // Apply a ForceMultiplier magnitude Impulse to the actor
    // in the direction of the player.
    public virtual void Move()
    {
        playerRb.AddForce(FindPlayer() * ForceMultiplier, ForceMode.Impulse);
    }

    // Returns a normalized Vector3 pointing the the direction of 
    // the player.
    public virtual Vector3 FindPlayer()
    {
        Vector3 result = playerRb.position - gameObject.transform.position;
        return result.normalized;
    }
}