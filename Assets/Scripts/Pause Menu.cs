using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                pause();
            }

        }
    }
    public void pause()
    {
        Time.timeScale = 0f;
        GamePaused = true;
        UIManager.Instance.PauseMenu();
    }
    public void Resume()
    {
        UIManager.Instance.HomeUI();
        Time.timeScale = 1f;
        GamePaused = false;
        
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
        UIManager.Instance.HomeUI();
        Time.timeScale = 1f;
        PlatformMovement.MoveSpeed = -8f;
    }
    public void Exit()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}
