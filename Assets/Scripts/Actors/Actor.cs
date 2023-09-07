using System.Collections;
using System.Collections.Generic;
using UnityEngine;




/// <summary>Actor is the base class of objects that the player interacts with. 
/// They are either safe or toxic, mobile or stationary, and have hit points.
/// 
/// Actor is an abstract class, because it contains one abstract method, Consume(),
/// which defines the behavior when different actors of different types interact.
/// </summary>
/// 

// I'm not sure it's necessary to make this abstract.  A virtual function would 
// suffice.1 
[RequireComponent(typeof(Rigidbody))]
public class Actor : MonoBehaviour // ABSTRACTION
{
    /// <param name="ActorVolume">Size of actor. Arbitrarily defaulted to .5.</param>
    public virtual float ActorVolume { get; set; } = 0.5f;

    /// <param name="IsToxic">Safe or toxic. Default to safe (true).</param>
    public virtual bool IsToxic { get; set; } = false;

    /// <param name="IsMobile">Mobile or stationary. Default to mobile (true).</param>
    public virtual bool IsMobile { get; protected set; } = true;

    /// <param name="gameManager">GameManager to get access to the score text, which will need to be updated when Consume() is called.</param>
    public GameManager gameManager;

    /// <param name="playerGameObject">The GameObject of the Player.</param>
    protected GameObject playerGameObject;

    /// <param name="IsGrounded">True if our Rigidbody is in contact with the ground.</param>
    public bool IsGrounded { get; set; } = false;

    // Start is called before the first frame update
    void Start()
    {
        playerGameObject = GameObject.Find("Player");        // transform.localScale = new Vector3(radius, radius, radius);
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

    /// <summary><c>public abstract void Consume(Collision other)</c> is called by <c>OnCollisionEnter(Collision other)</c>
    /// which defines the behavior of how child classes behave when they collide with each other.
    /// 
    /// Each concrete child class must implement this method. </summary>
    public void Consume(Collision other) // INHERITANCE
    {
        Actor actor = other.gameObject.GetComponent<Actor>();
        if (actor.CompareTag("Actor"))
        {
            Eat(actor);
        }
        else
        {
            return;
        }
    }

    /// <summary>Eat(Actor actor) is called by Consume, and is a virtual method for child classes
    /// to override if needed.

    /// <param name="actor">An Actor object, representing the object to be consumed, or interacted
    /// with if toxic.</param>
    /// </summary>
    public virtual void Eat(Actor actor)
    {
        if (actor.IsToxic)
        {
            // Subtract the actor's volume from our own and game over
            // if we're 0 or below.
            ActorVolume -= actor.ActorVolume;
            // float toxicRadius = ComputeRadius(ActorVolume);
            // actor.GetComponent<GameObject>().transform.localScale = new Vector3(toxicRadius, toxicRadius, toxicRadius);
            if (ActorVolume <= 0)
            {
                if (gameObject.tag == "Player")
                {
                    DataManager.Instance.GoToGameOverScene();
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
        else
        {
            // If the other actor is bigger, return. Their
            // Consume() will handle this case.
            if (actor.ActorVolume < ActorVolume)
            {
                ActorVolume += actor.ActorVolume;
                Destroy(actor.gameObject);
            }
        }
        float radius = ComputeRadius(ActorVolume);
        // Debug.Log("New radius: " + radius);
        transform.localScale = new Vector3(radius, radius, radius);
    }

    /// <summary>SetScale(float volume) takes the volume of an actor and returns the 
    /// radius of a sphere with that volume. Spheres will model our actor since they have
    /// the smallest surface area to volume ratio.
    /// <param name="volume">float. Volume of the sphere to compute the radius of.</param>
    ///  </summary>
    public virtual float ComputeRadius(float volume)
    {
        if (volume <= 0)
        {
            return 0.0001f;
        }
        return (float)System.Math.Cbrt(3 * volume / 4 * System.Math.PI);
    }



    /// <summary>Trigger Consume() when a Rigidbody collision is entered.</summary>
    public void OnCollisionEnter(Collision other)
    {
        // Debug.Log("OnCollisionEnter() " + gameObject.tag + " collided with " + other.gameObject.tag);
        // Just a reminder how to get at our actor object
        // float volume = other.gameObject.GetComponent<Actor>().ActorVolume;
        if (other.gameObject.CompareTag("Actor"))
        {
            Consume(other);
        }

        // Land after becoming airborne
        if (other.gameObject.CompareTag("Ground"))
        {
            IsGrounded = true;
        }

    }

    /// <summary></summary>
    public void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            // Debug.Log("Grounded");
            IsGrounded = true;
        }
    }

    public void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            // Debug.Log("Not Grounded");
            IsGrounded = false;
        }
    }
}