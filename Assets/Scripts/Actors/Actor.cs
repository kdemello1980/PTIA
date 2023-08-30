using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>Actor is the base class of objects that the player interacts with. 
/// They are either safe or toxic, mobile or stationary, and have hit points.
/// 
/// Actor is an abstract class, because it contains one abstract method, Consume(),
/// which defines the behavior when different actors of different types interact.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public abstract class Actor : MonoBehaviour
{
    // Size of actor. Arbitrarily defaulted to .5.
    public virtual float ActorVolume { get; set; } = 0.5f;

    // Safe or toxic. Default to safe (true)
    public virtual bool IsToxic { get; set; } = false;

    // Mobile or stationary. Default to mobile.
    public virtual bool IsMobile { get; protected set; } = true;

    // GameManager for logging.
    public GameManager gameManager { get; set; }

    // Rigidbody. All Actors have a Rigidbody.

    // The player's rigidbody
    public GameObject playerGameObject { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        playerGameObject = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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

    /// <summary>public abstract void Consume(Collision other) is called by OnCollisionEnter(Collision other)
    /// which defines the behavior of how child classes behave when they collide with each other.
    /// 
    /// Each concrete child class must implement this method. </summary>
    public abstract void Consume(Collision other);



    /// <summary>Trigger Consume() when a Rigidbody collision is entered.</summary>
    void OnCollisionEnter(Collision other)
    {
        // gameManager.ShowMessage("Collision detected.");
        // Just a reminder how to get at our actor object
        // float volume = other.gameObject.GetComponent<Actor>().ActorVolume;
        if (other.gameObject.CompareTag("Actor"))
        {
            Consume(other);
        }
    }

}