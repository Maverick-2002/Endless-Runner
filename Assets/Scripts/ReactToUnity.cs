using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class GameConfig
{
    //public string powerName;
    public int initialPower;
    public int maximumPower;
    //public int addPowerPerCorrectAnswer;
}

public class ReactToUnity : MonoBehaviour
{

#if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void AskQuestion_React();
    [DllImport("__Internal")]
    private static extern void StartGame_React();
    [DllImport("__Internal")]
    private static extern void GameOver_React(int score);
#endif

    public static ReactToUnity instance;

    public static Action OnUpdateEnergy;

    public static Action<int> OnUpdateQuizScore;

    public static Action OnOutOfEnergy;

    public static Action OnBonusRoundStart;

    public int _Energy = 0;
    public int _maxEnergy = 3;
    public int _timer;


    public GameConfig _config;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OnGameInitialized()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
            StartGame_React();
#endif
    }

    public void OnGameOver()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
            GameOver_React((int)GameManager.highScore);
#endif
    }

    public void AskQuestion_Unity()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
            AskQuestion_React();
#endif
    }

    public void GameConfig_Unity(string str)
    {
        _config = JsonUtility.FromJson<GameConfig>(str);
        SetupGame(_config);
    }

    void SetupGame(GameConfig config)
    {
        _Energy = config.initialPower;
        _maxEnergy = config.maximumPower;
        SetEnergy_Unity(_Energy);
    }

    public void GiveQuizScore_Unity(int score)
    {
        OnUpdateQuizScore?.Invoke(score);
    }

    public void GiveEnergy_Unity(int Energy)
    {
        _Energy += Energy;
        if (_Energy > _maxEnergy)
        {
            _Energy = _maxEnergy;
        }
        OnUpdateEnergy?.Invoke();
    }
    public void GiveEnergy_Unity()
    {
        GiveEnergy_Unity(6);
    }
    public void SetEnergy_Unity(int energy)
    {
        _Energy = energy;
        if (_Energy > _maxEnergy)
        {
            _Energy = _maxEnergy;
        }
        OnUpdateEnergy?.Invoke();
    }

    public void UseEnergy_Unity(int Energy)
    {
        if (_Energy - Energy > 0)
        {
            _Energy -= Energy;
            OnUpdateEnergy?.Invoke();
        }
        else
        {
            _Energy = 0;
            OnOutOfEnergy?.Invoke();
            AskQuestion_Unity();
        }
    }

    public void StartBonusRound_Unity()
    {
        OnBonusRoundStart?.Invoke();
        OnGameOver();
    }
}