using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_menu : MonoBehaviour
{
    // void Update()
    // {
    //     if (Input.GetButtonDown("Cancel"))
    //     {
    //         Debug.Log("escaped jack fresco trap");
    //         Cursor.lockState = CursorLockMode.None;
    //         Cursor.visible = true;
    //     }
    // }
    public void StartGame(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
