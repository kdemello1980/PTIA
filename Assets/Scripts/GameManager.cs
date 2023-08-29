using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseScreen;

    [SerializeField]
    private Button resumeButton;

    [SerializeField]
    private Button menuButton;

    [SerializeField]
    private Button quitButton;
    // Start is called before the first frame update
    void Start()
    {

    }

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
}
