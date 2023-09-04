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

    // GameManager for logging.
    /// <param name="gameManager">probably not needed</param>
    // public GameManager gameManager { get; set; }


    /// <param name="playerGameObject">The player's Rigidbody.</param>
    public GameObject playerGameObject { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        playerGameObject = GameObject.Find("Player");
        // gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
        if (!actor)
        {
            return;
        }
        else if (actor.CompareTag("Actor"))
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
            if (ActorVolume <= 0)
            {
                DataManager.Instance.GoToGameOverScene();
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
                float radius = SetScale(ActorVolume);
                transform.localScale = new Vector3(radius, radius, radius);
            }
            else
            {
                // either the 2 actors are equal or the other one is bigger.
                // if they're equal, both will return. If the other is bigger, 
                // it will keep going.
                return;
            }

        }
    }

    /// <summary>SetScale(float volume) takes the volume of an actor and returns the 
    /// radius of a sphere with that volume. Spheres will model our actor since they have
    /// the smallest surface area to volume ratio.
    /// <param name="volume">float. Volume of the sphere to compute the radius of.</param>
    ///  </summary>
    public virtual float SetScale(float volume)
    {
        return (float)System.Math.Cbrt(3 * volume / 4 * System.Math.PI);
    }



    /// <summary>Trigger Consume() when a Rigidbody collision is entered.</summary>
    public void OnCollisionEnter(Collision other)
    {
        Debug.Log("OnCollisionEnter()");
        // gameManager.ShowMessage("Collision detected.");
        // Just a reminder how to get at our actor object
        // float volume = other.gameObject.GetComponent<Actor>().ActorVolume;
        if (other.gameObject.CompareTag("Actor"))
        {
            Consume(other);
        }
    }

}