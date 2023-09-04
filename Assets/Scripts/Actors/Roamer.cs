using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The Roamer class represents a clade of Actors that hop around in random directions. 
/// </summary>
public class Roamer : MobileController // INHERITANCE
{
    // Variables unique to the Roamer clade.
    public float minHopRange = -0.5f;
    public float maxHopRange = 0.5f;
    public float minSpeed = 0.25f;
    public float maxSpeed = 0.5f;
    public float minHopDelaySeconds = 0.75f;
    public float maxHopDelaySeconds = 1.5f;

    // Size range for Roamers.
    public float minVolume = 0.25f;
    public float maxVolume = 0.75f;


    // Start is called before the first frame update
    void Start()
    {
        float ActorVolume = Random.Range(minVolume, maxVolume);
        float radius = SetScale(ActorVolume);
        transform.localScale = new Vector3(radius, radius, radius);
        StartCoroutine(ChangeDirection());
    }

    // Borrow the MobileController's 
    public override void Move() // POLYMORPHISM
    {
        if (DataManager.Instance.IsGameActive)
        {
            float randomSpeed = Random.Range(minSpeed, maxSpeed);
            // Debug.Log("RandomSpeed: " + randomSpeed);
            float randomX = Random.Range(minHopRange, maxHopRange);
            float randomZ = Random.Range(minHopRange, maxHopRange);
            Vector3 leftRight = new Vector3(randomX, 0.0f, 0.0f);
            Vector3 forwardBackward = new Vector3(0.0f, 0.0f, randomZ);
            // gameController.gameObject.transform.Translate(Vector3.Normalize(leftRight + forwardBackward) 
            // * randomSpeed);
            GetComponent<Rigidbody>().AddForce(Vector3.Normalize(leftRight + forwardBackward) * randomSpeed,
                ForceMode.Impulse);
        }
    }

    public IEnumerator ChangeDirection()
    {
        // Debug.Log("ChangeDirection()");
        while (DataManager.Instance.IsGameActive)
        {
            float randomSeconds = Random.Range(.25f, 1.5f);
            // Debug.Log("Moving controller in randomSeconds" + randomSeconds);
            Move();
            yield return new WaitForSeconds(randomSeconds);
        }
    }

    // Implement the Consume() method.
    // public override void Consume(Collision other) // ABSTRACTION
    // {
    //     return;
    // }
}
