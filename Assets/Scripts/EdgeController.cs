using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Destroy anything that triggers us
    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
