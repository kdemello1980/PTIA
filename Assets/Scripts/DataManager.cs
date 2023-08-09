using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{

    public static DataManager Instance;
    public bool SkipHowtoScene { get; set; } = false;
    public string TitleSceneName { get; protected set; } = "TitleScene";
    public string MainScene { get; protected set; } = "MainScene";
    public string GameOverScene { get; protected set; } = "GameOverScene";
    public string SettingsScene { get; protected set; } = "SettingsScene";
    public string HowtoScene { get; protected set; } = "HowtoScene";

    public void Awake()
    {
        if (Instance != null)
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

    // Class containing relevant data.
    class GameData
    {
        public bool SkipHowtoScene { get; protected set; }
        string TitleSceneName;
        string MainScene;
        string GameOverScene;
        string SettingsScene;
        string HowtoScene;
    }
}
