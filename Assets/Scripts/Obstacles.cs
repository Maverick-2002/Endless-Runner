using System.Collections;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public static Obstacles Instance;
    public GameObject LevelGenerate;
    public PlayerMovement player;
    public UIManager high;
    private bool isDead = false;

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
        player = GetComponent<PlayerMovement>();
        isDead = false;
}

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            HandlePlayerDeath();
        }
    }

    private void Update()
    {
        if (UIManager.fuel <= 0 && !isDead)
        {
            HandlePlayerDeath();
        }
    }

    public void HandleCollision()
    {
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        high.UpdateHighScore((int)player.score);
        StartCoroutine(Death());
    }

    public void HandlePlayerDeath()
    {
        isDead = true;
        HandleCollision();
    }

    IEnumerator Death()
    {
        UIManager.Instance.SetPlayerAlive(false);
        LevelGenerator.Instance.StopMovement();
        AudioManager.Instance.StopMusic(SoundEnum.SoundTrack);
        AudioManager.Instance.PlaySFX(SoundEnum.Fall);
        yield return new WaitForSeconds(2.5f);
        UIManager.Instance.DeathUI();
    }
}
