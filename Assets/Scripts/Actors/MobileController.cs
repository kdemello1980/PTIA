using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileController : MonoBehaviour
{
    // Rigidbody that will be on all mobile actors
    Rigidbody playerRb;

    // Force multiplier.
    protected virtual float ForceMultiplier { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void Move()
    {

    }
}
