using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryController : Actor
{
    // Start is called before the first frame update
    void Start()
    {
        IsMobile = false;
        ActorVolume = 1.0f;
    }

    // public void Consume(Collision other)
    // {
    //     StationaryConsume();
    // }

    // public virtual void StationaryConsume()
    // {

    // }
}
