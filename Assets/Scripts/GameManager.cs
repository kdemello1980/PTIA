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

    // Update is called once per frame
    void Update()
    {
        // Check for ESC press and pause if detected.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    // Pause
    public void Pause()
    {
        // Show the pause UI objects on the canvas.
        pauseScreen.gameObject.SetActive(true);

        // Pause execution of the game.
        Time.timeScale = 0;
    }

    // Resume
    public void Resume()
    {
        // Show the pause UI objects on the canvas.
        pauseScreen.gameObject.SetActive(false);

        // Resume execution of the game.
        Time.timeScale = 1;
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
