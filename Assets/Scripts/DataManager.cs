using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

/// <summary>
/// The DataManager is a singleton that manages game state and save data.
/// </summary> 
public class DataManager : MonoBehaviour
{
    /// <summary>The <c>Instance</c> property is a static reference to the DataManager</summary>
    public static DataManager Instance { get; private set; }

    /// <value><c>SkipHowtoScene</c> specifies whether a how to play screen should be shown in between the title scene and the main game scene.</value>
    public bool SkipHowtoScene { get; set; } = true; // ENCAPSULATION
    public bool IsGameActive { get; set; } = true; // ENCAPSULATION
    public string TitleSceneName { get; protected set; } = "TitleScene"; // ENCAPSULATION
    public string MainScene { get; protected set; } = "MainScene"; // ENCAPSULATION
    public string GameOverScene { get; protected set; } = "GameOverScene"; // ENCAPSULATION
    public string SettingsScene { get; protected set; } = "SettingsScene"; // ENCAPSULATION
    public string HowtoScene { get; protected set; } = "HowtoScene"; // ENCAPSULATION

    // This has been pissing me off because Start() doesn't propogate down the inheritance chain
    public GameObject PlayerGameObject;// { get; set; }

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
        PlayerGameObject = GameObject.Find("Player");
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
