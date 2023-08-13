using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class representing an instance of an ammo prefab.
public class AmmoBaseController : MonoBehaviour
{
    // Ammo impulse force
    [SerializeField] protected float ammoImpulseForce;
    protected Rigidbody ammoRb;

    // Player object, so you can get the orientation for fire
    // direction
    // public GameObject playerOrientation;


    // Start is called before the first frame update
    void Start()
    {
        ammoRb = GetComponent<Rigidbody>();
        // ammoRb.AddForce(playerOrientation.GetComponent<Transform>().forward * ammoImpulseForce, ForceMode.Impulse);
        ammoRb.AddForce(transform.forward * ammoImpulseForce, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}