using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float spawnRateSeconds { get; set; } = 0.05f;
    [SerializeField]
    private GameObject pauseScreen;

    [SerializeField]
    private Button resumeButton;

    [SerializeField]
    private Button menuButton;

    [SerializeField]
    private Button quitButton;

    [SerializeField]
    private int startingActorCount { get; set; } = 5000;

    [SerializeField] private TMP_Text messageWindow;
    // Start is called before the first frame update
    void Start()
    {
        InitializePlayfield();
        StartCoroutine(RespawnActors());
    }

    public List<GameObject> prefabs = new List<GameObject>();
    public Terrain ground;

    // Set the cursor lockstate on load
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Check for ESC press and pause if detected.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    // Pause
    public void TogglePause()
    {
        if (DataManager.Instance.IsGameActive)
        {
            DataManager.Instance.IsGameActive = false;
            pauseScreen.gameObject.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            DataManager.Instance.IsGameActive = true;
            pauseScreen.gameObject.SetActive(false);
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    // Main Menu
    public void GoToMainMenu()
    {
        DataManager.Instance.GoToTitleScene();
    }

    // Quit
    public void Quit()
    {
        DataManager.Instance.QuitGame();
    }

    // Initialize the playfield
    public void InitializePlayfield()
    {
        for (int i = 0; i < startingActorCount; i++)
        {
            // Find the starting vector.
            SpawnActor();
        }
    }

    void SpawnActor()
    {
        Vector3 starting = new Vector3(Random.Range(-DataManager.Instance.GameFieldSize, DataManager.Instance.GameFieldSize),
            0.0f,
            Random.Range(-DataManager.Instance.GameFieldSize, DataManager.Instance.GameFieldSize));

        starting.y = ground.SampleHeight(starting) + 1;
        GameObject newThing = Instantiate(prefabs[Random.Range(0, prefabs.Count)]);
        newThing.transform.position = starting;
    }

    // Periodically add new actors
    IEnumerator RespawnActors()
    {
        while (DataManager.Instance.IsGameActive)
        {
            yield return new WaitForSeconds(Random.Range(0.0f, spawnRateSeconds));
            SpawnActor();
        }
    }
}