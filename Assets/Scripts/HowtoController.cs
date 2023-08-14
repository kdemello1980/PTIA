using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowtoController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Return to main menu.
    public void ReturnToMenu()
    {
        DataManager.Instance.GoToMainScene();
        // DataManager.Instance.GoToTitleScene();
    }
}
