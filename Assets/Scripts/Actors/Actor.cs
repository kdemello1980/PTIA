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
        playerGameObject = GameObject.FindWithTag("Player");
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
    public virtual void Consume(Actor prey)
    {
        // Consumption rules:
        // • When both actors are non toxic
        //     ◦ The larger actor always consumes all of the smaller
        //     ◦ If they are exactly the same size they bounce off
        // • When one is toxic and the other is non - toxic
        //     ◦ If the larger one is non - toxic, then the volume of the toxic one is subtracted
        //     ◦ if they are the same size or the non - toxic one is smaller, the non-toxic one is annihilated.
        if ((!IsToxic && !prey.IsToxic) || (IsToxic && prey.IsToxic))
        {
            // Absorb the prey
            if (ActorVolume > prey.ActorVolume)
            {
                ActorVolume += prey.ActorVolume;

                // Destroy the prey object if it isn't the player
                if (!prey.gameObject.CompareTag("Player"))
                {
                    Destroy(prey.gameObject);
                }
            }
            else if (ActorVolume <= prey.ActorVolume)
            {
                // ActorVolume becomes 0. We destroy our object if we're not the player.
                // If we are the player, we go to game over.
                ActorVolume = 0;
                if (!prey.gameObject.CompareTag("Player"))
                {
                    DataManager.Instance.GoToGameOverScene();
                }
                else
                {
                    Destroy(prey.gameObject);
                }
            }
            // else if (ActorVolume == prey.ActorVolume)
            // {
            // }
        }
        else
        {
            // If our volume is greater than that of our toxic prey, take the hit.
            if (ActorVolume > prey.ActorVolume)
            {
                ActorVolume -= prey.ActorVolume;
            }
            // Otherwise, we drop to 0 or below, so it's game over.
            else
            {
                DataManager.Instance.GoToGameOverScene();
            }
        }
    }




    /// <summary>Trigger Consume() when a Rigidbody collision is entered.</summary>
    void OnCollisionEnter(Collision other)
    {
        // Just a reminder how to get at our actor object
        // float volume = other.gameObject.GetComponent<Actor>().ActorVolume;
        if (other.gameObject.CompareTag("Actor"))
        {
            Consume(other.gameObject.GetComponent<Actor>());
        }
    }

}