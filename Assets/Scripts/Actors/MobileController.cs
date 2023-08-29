using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileController : Actor // INHERITANCE
{
    // Force multiplier. This is applied to AddForce(). Arbitrarily defaulted
    // to 1.0f.
    protected virtual float ForceMultiplier { get; set; } = 1.0f; // ENCAPSULATION


    // Start is called before the first frame update
    void Start()
    {
        IsMobile = true;
        StartCoroutine(ChangeDirection());
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
        // Move();
    }

    // Apply a ForceMultiplier magnitude Impulse to the actor
    // in the direction of the player.
    public virtual void Move()
    {
        // playerRb.AddForce(FindPlayer() * ForceMultiplier, ForceMode.Impulse);
        playerGameObject.GetComponent<Rigidbody>().AddForce(FindPlayer() * ForceMultiplier, ForceMode.Impulse);
    }

    // Returns a normalized Vector3 pointing the the direction of 
    // the player.
    public virtual Vector3 FindPlayer() // ABSTRACTION
    {
        Vector3 result = playerGameObject.transform.position - gameObject.transform.position;
        return result.normalized;
    }

    public IEnumerator ChangeDirection()
    {
        // Debug.Log("ChangeDirection()");
        while (DataManager.Instance.IsGameActive)
        {
            float randomSeconds = Random.Range(.25f, 1.5f);
            // Debug.Log("Moving controller in randomSeconds" + randomSeconds);
            MoveGameController();
            yield return new WaitForSeconds(randomSeconds);
        }
    }


    /// <summary>
    /// MoveGameController()
    /// </summary>Alternative to Move() that moves in a random direction along the XZ axis. <summary>
    /// 
    /// </summary>
    void MoveGameController()
    {
        if (DataManager.Instance.IsGameActive)
        {
            float randomSpeed = Random.Range(10.0f, 20.0f);
            // Debug.Log("RandomSpeed: " + randomSpeed);
            float randomX = Random.Range(-10.0f, 10.0f);
            float randomZ = Random.Range(-10.0f, 10.0f);
            Vector3 leftRight = new Vector3(randomX, 0.0f, 0.0f);
            Vector3 forwardBackward = new Vector3(0.0f, 0.0f, randomZ);
            // gameController.gameObject.transform.Translate(Vector3.Normalize(leftRight + forwardBackward) 
            // * randomSpeed);
            GetComponent<Rigidbody>().AddForce(Vector3.Normalize(leftRight + forwardBackward) * randomSpeed,
                ForceMode.Impulse);
        }
    }
}
