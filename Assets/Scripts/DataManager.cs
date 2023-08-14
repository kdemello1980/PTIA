using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class DataManager : MonoBehaviour
{

    public static DataManager Instance { get; private set; }
    public bool SkipHowtoScene { get; set; } = true;
    public bool IsPaused { get; set; } = false;
    public string TitleSceneName { get; protected set; } = "TitleScene";
    public string MainScene { get; protected set; } = "MainScene";
    public string GameOverScene { get; protected set; } = "GameOverScene";
    public string SettingsScene { get; protected set; } = "SettingsScene";
    public string HowtoScene { get; protected set; } = "HowtoScene";

    // Save slots
    public string[] SaveSlots = new string[5];
    // public List<string> SaveSlots = new List<string>();

    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GoToTitleScene()
    {
        SceneManager.LoadScene(TitleSceneName);
    }

    public void GoToMainScene()
    {
        SceneManager.LoadScene(MainScene);
    }

    public void GoToGameOverScene()
    {
        SceneManager.LoadScene(GameOverScene);
    }

    public void GoToSettingsScene()
    {
        SceneManager.LoadScene(SettingsScene);
    }

    public void GoToHowToScene()
    {
        SceneManager.LoadScene(HowtoScene);
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


    // Class containing relevant data.
    public class GameData
    {
        public bool SkipHowtoScene { get; protected set; }
        public bool IsPaused { get; protected set; }
        string TitleSceneName;
        string MainScene;
        string GameOverScene;
        string SettingsScene;
        string HowtoScene;
    }
}
