using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameoverManager : MonoBehaviour
{
    // Go back to the main menu.
    public void MainManu()
    {
        DataManager.Instance.GoToTitleScene();
    }

    // Quit the game.
    public void Quit()
    {
        DataManager.Instance.QuitGame();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    void Update() { }
}