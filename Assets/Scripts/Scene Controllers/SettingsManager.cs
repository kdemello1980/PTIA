using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    // [SerializeField] private Button TitleButton;
    // Start is called before the first frame update

    public void ReturnToMenu()
    {
        DataManager.Instance.GoToTitleScene();
    }



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
