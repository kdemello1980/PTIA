using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The Roamer class represents a clade of Actors that hop around in random directions. 
/// </summary>
public class Roamer : MobileController // INHERITANCE
{
    // Variables unique to the Roamer clade.
    public float minHopRange = -2.5f;
    public float maxHopRange = 2.5f;
    public float minSpeed = 2.5f;
    public float maxSpeed = 5.0f;
    public float minHopDelaySeconds = 1.0f;
    public float maxHopDelaySeconds = 2.0f;

    // Influence of player-biasing of random hopping
    public float playerDirectionBias = 0.75f;

    // Size range for Roamers.
    public float minVolume = 0.25f;
    public float maxVolume = 1.5f;

    public float Mass { get; set; } = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().mass = Mass;
        lifeSpanSeconds = 30.0f;
        float ActorVolume = Random.Range(minVolume, maxVolume);
        float radius = ComputeRadius(ActorVolume);
        transform.localScale = new Vector3(radius, radius, radius);
        StartCoroutine(ChangeDirection());
        // StartCoroutine(EndOfLife());
        playerGameObject = GameObject.Find("Player");
    }

    // Borrow the MobileController's 
    public override void Move() // POLYMORPHISM
    {
        if (DataManager.Instance.IsGameActive)
        {
            if (IsGrounded)
            {
                float randomSpeed = Random.Range(minSpeed, maxSpeed);
                // Debug.Log("RandomSpeed: " + randomSpeed);
                float randomX = Random.Range(minHopRange, maxHopRange);
                float randomY = Random.Range(0.0f, maxHopRange);
                float randomZ = Random.Range(minHopRange, maxHopRange);
                Vector3 leftRight = new Vector3(randomX, 0.0f, 0.0f);
                Vector3 forwardBackward = new Vector3(0.0f, 0.0f, randomZ);
                Vector3 upDown = new Vector3(0.0f, randomY, 0.0f);
                // gameController.gameObject.transform.Translate(Vector3.Normalize(leftRight + forwardBackward) 
                // * randomSpeed);
                GetComponent<Rigidbody>().AddForce(Vector3.Normalize(leftRight + forwardBackward + upDown + playerDirectionBias * FindPlayer()) * randomSpeed,
                    ForceMode.Impulse);
            }
        }
    }

    public IEnumerator ChangeDirection()
    {
        // Debug.Log("ChangeDirection()");
        while (DataManager.Instance.IsGameActive)
        {
            float randomSeconds = Random.Range(minHopDelaySeconds, maxHopDelaySeconds);
            // Debug.Log("Moving controller in randomSeconds" + randomSeconds);
            Move();
            yield return new WaitForSeconds(randomSeconds);
        }
    }

}
