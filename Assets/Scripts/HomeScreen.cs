using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeScreen : MonoBehaviour
{
    public Text highScoreText;
    public GameObject highscore;
    public GameObject MainMenu;
    public AudioSource bgm;
    public Animator animator;
    public float time;
    public void Start()
    {
        bgm.Play();
        time = 0;
    }
    public void Update()
    {
        time += Time.deltaTime;
        if (time < 10)
        {
            animator.SetInteger("Trans",10);
        }
        if (time >= 10)
        {
            animator.SetInteger("Trans", 20);
        }
        if (time >=20)
        {
            animator.SetInteger("Trans", 30);
        }
        if (time >= 35)
        {
            time = 0;
        }
    }
    public void LevelLoaded()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void HighScore()
    {
        float highScore = PlayerPrefs.GetFloat("HighScore", 0);
        highScoreText.text = highScore.ToString();
    }
    public void HighScoreMenu()
    {
        highscore.SetActive(true);
        MainMenu.SetActive(false);
    }
    public void MainMenuPage()
    {
        highscore.SetActive(false);
        MainMenu.SetActive(true);
    }
}
