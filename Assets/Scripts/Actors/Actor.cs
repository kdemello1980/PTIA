using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Actor is the base class of objects that the player interacts with.
// They are either safe or toxic, mobile or stationary, and have hit points.
[RequireComponent(typeof(Rigidbody))]
public class Actor : MonoBehaviour
{
    // Size of actor. Arbitrarily defaulted to .5.
    public virtual float ActorVolume { get; set; } = 0.5f;

    // Safe or toxic. Default to safe (true)
    public virtual bool IsToxic { get; set; } = false;

    // Mobile or stationary. Default to mobile.
    public virtual bool IsMobile { get; protected set; } = true;

    // Rigidbody. All Actors have a Rigidbody.

    // The player's rigidbody
    protected GameObject playerGameObject { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the Rigidbody
        playerGameObject = GameObject.FindWithTag("Player").GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Actors use Rigidbody physics, so calculations should be done
    // in FixedUpdate()
    void FixedUpdate()
    {

    }

    /// <summary>Consume() is called by the collision of 2 Actors and determines what happens with each.</summary>
    public virtual void Consume()
    {

    }
}