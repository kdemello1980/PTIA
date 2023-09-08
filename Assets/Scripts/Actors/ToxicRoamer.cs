using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicRoamer : Roamer // INHERITANCE/POLYMORPHISM
{
    // Start is called before the first frame update
    void Start()
    {
        IsToxic = true;
        playerGameObject = GameObject.Find("Player");
    }
}
