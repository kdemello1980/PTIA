using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roamer : MobileController // INHERITANCE
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeDirection());
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Borrow the MobileController's 
    public override void Move() // POLYMORPHISM
    {
        if (DataManager.Instance.IsGameActive)
        {
            float randomSpeed = Random.Range(10.0f, 20.0f);
            // Debug.Log("RandomSpeed: " + randomSpeed);
            float randomX = Random.Range(-10.0f, 10.0f);
            float randomZ = Random.Range(-10.0f, 10.0f);
            Vector3 leftRight = new Vector3(randomX, 0.0f, 0.0f);
            Vector3 forwardBackward = new Vector3(0.0f, 0.0f, randomZ);
            // gameController.gameObject.transform.Translate(Vector3.Normalize(leftRight + forwardBackward) 
            // * randomSpeed);
            GetComponent<Rigidbody>().AddForce(Vector3.Normalize(leftRight + forwardBackward) * randomSpeed,
                ForceMode.Impulse);
        }
    }

    public IEnumerator ChangeDirection()
    {
        // Debug.Log("ChangeDirection()");
        while (DataManager.Instance.IsGameActive)
        {
            float randomSeconds = Random.Range(.25f, 1.5f);
            // Debug.Log("Moving controller in randomSeconds" + randomSeconds);
            Move();
            yield return new WaitForSeconds(randomSeconds);
        }
    }
}
