using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Quit()
    {
        DataManager.Instance.QuitGame();
    }


    // Kick off the game by loading the game scene.
    public void LoadGameScene()
    {
        if (DataManager.Instance.SkipHowtoScene)
        {
            LoadMainScene();
        }
        else
        {
            LoadHowtoScene();
        }
    }

    // Load the game settings scene.
    public void LoadSettingsScene()
    {
        DataManager.Instance.GoToSettingsScene();
    }

    // Load the game howto scene.
    public void LoadHowtoScene()
    {
        DataManager.Instance.GoToHowToScene();
    }

    // Load main game scene.
    public void LoadMainScene()
    {
        DataManager.Instance.GoToMainScene();
    }
}
