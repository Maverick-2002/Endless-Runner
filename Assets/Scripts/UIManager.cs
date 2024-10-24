using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    private int coin = 0;
    public static int fuel = 50;
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
    public Slider fuelSlider;
    public static bool isPlayerAlive = true;
    private ReactToUnity reactToUnity;

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
        reactToUnity = ReactToUnity.instance;
        ReactToUnity.OnUpdateEnergy += SetStamina;
        ReactToUnity.OnOutOfEnergy += SetStamina;
        highScore = PlayerPrefs.GetFloat("HighScore", 0);
        highScoreText.text = ": " + highScore.ToString();
        fuelSlider.maxValue = reactToUnity._maxEnergy;
        reactToUnity._Energy = reactToUnity._maxEnergy;
        fuelSlider.value = reactToUnity._Energy;
        isPlayerAlive = true;
        
    }
    void SetStamina()
    {
        fuelSlider.value = reactToUnity._Energy;
        if (reactToUnity._Energy<=0)
        {
            LevelGenerator.Instance.StopMovement();
            UIManager.isPlayerAlive = false; 
        }
        else
        {
            LevelGenerator.Instance.StartMovement();
            UIManager.isPlayerAlive=true;
        }
    }

    void Update()
    {
        int score = playerController.CalculateScore();
        scoreText.text = ": " + score.ToString();
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReactToUnity.instance.GiveEnergy_Unity(50);
        }
    }

    public void Coin()
    {
        coin++;
        coinText.text = ": " + coin;
    }
    public void FuelDecrease(int decreaseFuel)
    {
        if (isPlayerAlive)
        {
            reactToUnity?.UseEnergy_Unity(Energy: (int)decreaseFuel);
            print(reactToUnity._Energy);
        }
    }

    public void SetPlayerAlive(bool status)
    {
        isPlayerAlive = status;
    }

    public void DifficultyUI()
    {
        print(Dif);
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
        AudioManager.Instance.StopMusic(SoundEnum.SoundTrack);
    }

    public void HomeUI()
    {
        pausemenu.SetActive(false);
        resumemenu.SetActive(true);
        Deathmenu.SetActive(false);
        AudioManager.Instance.PlayMusic(SoundEnum.SoundTrack);
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
