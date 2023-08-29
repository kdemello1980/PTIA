using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileController : Actor // INHERITANCE
{
    // Force multiplier. This is applied to AddForce(). Arbitrarily defaulted
    // to 1.0f.
    protected virtual float ForceMultiplier { get; set; } = 0.5f; // ENCAPSULATION


    // Start is called before the first frame update
    void Start()
    {
        IsMobile = true;
        playerGameObject = GameObject.Find("Player");
    }

    // protected override void InitializeActor()
    // {
    //     return;
    // }


    // All of our motion involves Rigidbody physics
    public void FixedUpdate()
    {
        Move();
    }

    // Apply a ForceMultiplier magnitude Impulse to the actor
    // in the direction of the player.
    public virtual void Move()
    {
        // playerRb.AddForce(FindPlayer() * ForceMultiplier, ForceMode.Impulse);
        // playerGameObject.GetComponent<Rigidbody>().AddForce(FindPlayer() * ForceMultiplier, ForceMode.Impulse);
        GetComponent<Rigidbody>().AddForce(FindPlayer() * ForceMultiplier, ForceMode.Impulse);
    }
    // public abstract void Move();

    // Returns a normalized Vector3 pointing the the direction of 
    // the player.
    public virtual Vector3 FindPlayer() // ABSTRACTION
    {
        Vector3 result = playerGameObject.transform.position - gameObject.transform.position;
        return result.normalized;
    }

}
