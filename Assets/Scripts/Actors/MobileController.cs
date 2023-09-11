using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileController : Actor // INHERITANCE & ABSTRACTION
{
    // Force multiplier. This is applied to AddForce(). Arbitrarily defaulted
    // to 1.0f.
    protected virtual float ForceMultiplier { get; set; } = 0.15f; // ENCAPSULATION
    public float lifeSpanSeconds = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        IsMobile = true;
        playerGameObject = GameObject.Find("Player");
        StartCoroutine(EndOfLife());
    }

    // All of our motion involves Rigidbody physics
    public void FixedUpdate()
    {
        Move(); // ABSTRACTION
    }

    // Apply a ForceMultiplier magnitude Impulse to the actor
    // in the direction of the player.
    public virtual void Move()
    {
        GetComponent<Rigidbody>().AddForce(FindPlayer() * ForceMultiplier, ForceMode.Impulse);
    }

    // Returns a normalized Vector3 pointing the the direction of 
    // the player.
    public virtual Vector3 FindPlayer() // ABSTRACTION
    {
        Vector3 result = playerGameObject.transform.position - gameObject.transform.position;
        return result.normalized;
    }

    public IEnumerator EndOfLife()
    {
        float randomLife = Random.Range(0.0f, lifeSpanSeconds);
        yield return new WaitForSeconds(randomLife);
        Destroy(gameObject);
    }
}
