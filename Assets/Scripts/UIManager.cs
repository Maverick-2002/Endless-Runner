using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
   // public static UIManager _Instance { get; private set; }
    public static UIManager Instance;
    private int score = 0;
    private int Dif = 1;
    public Text coinText;
    public Text scoreText;
    public PlayerMovement playerController;
    public Text highScoreText;
    public Text DifText;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
        float highScore = PlayerPrefs.GetFloat("HighScore", 0);
        highScoreText.text = ": " + highScore.ToString();
    }
    void Update()
    {
        int score = playerController.CalculateScore();
        scoreText.text = ": " + score.ToString();
    }
    public void Score()
    {
        score++;
        coinText.text = ": " + score;
    }
    public void DifficultyUI()
    {
        Dif++;
        DifText.text = ": " + Dif;
    }
    public void UpdateHighScore(float newScore)
    {
        float oldHighScore = PlayerPrefs.GetFloat("HighScore", 0);
        if (newScore > oldHighScore)
        {
            PlayerPrefs.SetFloat("HighScore", newScore);
            PlayerPrefs.Save();
            highScoreText.text = "High Score: " + newScore.ToString();
        }
    }
}
