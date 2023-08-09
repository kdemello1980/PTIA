using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class TitleManager : MonoBehaviour
{
    // Buttons to navigate to settings, maing game and to quit.
    [SerializeField] private Button startButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button settingsButton;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Quit the application, or exit play mode if in the editor.
    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
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
        // Load the settings scene.
        SceneManager.LoadScene(DataManager.Instance.SettingsScene);
    }

    // Load the game howto scene.
    public void LoadHowtoScene()
    {
        SceneManager.LoadScene(DataManager.Instance.HowtoScene);
    }

    // Load main game scene.
    public void LoadMainScene()
    {
        SceneManager.LoadScene(DataManager.Instance.MainScene);
    }
}
