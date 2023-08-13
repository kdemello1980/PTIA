using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCrawler : Enemy
{
    // Enemy center of mass
    [SerializeField] private GameObject centerOfMass;

    // Rigidbody
    // private Rigidbody enemyRb;
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        // enemyRb = GetComponent<Rigidbody>();
        // enemyRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }
}
