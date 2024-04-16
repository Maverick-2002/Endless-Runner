using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // public static UIManager _Instance { get; private set; }
    public static UIManager Instance;
    private int coin = 0;
    private int Dif = 1;
    public Text coinText;
    public Text scoreText;
    public PlayerMovement playerController;
    public Text highScoreText;
    public Text DifText;
    public float highScore;
    public GameObject pausemenu;
    public GameObject resumemenu;
    public GameObject Deathmenu;
    public Text FscoreText;
    public AudioSource bgmSource;
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
        highScore = PlayerPrefs.GetFloat("HighScore", 0);
        highScoreText.text = ": " + highScore.ToString();
    }
    void Update()
    {
        int score = playerController.CalculateScore();
        scoreText.text = ": " + score.ToString();
    }
    public void Coin()
    {
        coin++;
        coinText.text = ": " + coin;
    }
    public void DifficultyUI()
    {
        Dif++;
        DifText.text = ": " + Dif;
    }
    public void UpdateHighScore(float newScore)
    {
        float oldHighScore = highScore;
        if (newScore > oldHighScore)
        {
            PlayerPrefs.SetFloat("HighScore", newScore);
            PlayerPrefs.Save();
            highScoreText.text = ": " + newScore.ToString();
        }
    }
    public void PauseMenu()
    {
        pausemenu.SetActive(true);
        resumemenu.SetActive(false);
        Deathmenu.SetActive(false);
        bgmSource.Stop();
    }
    public void HomeUI()
    {
        pausemenu.SetActive(false);
        resumemenu.SetActive(true);
        Deathmenu.SetActive(false);
        bgmSource.Play();
    }

    public void DeathUI()
    {
        Deathmenu.SetActive(true);
        pausemenu.SetActive(false);
        resumemenu.SetActive(false);
        int score = playerController.CalculateScore();
        FscoreText.text = score.ToString();
    }
}
