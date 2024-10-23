using System.Collections;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public GameObject LevelGenerate;
    public PlayerMovement player;
    private PlatformMovement PlatformMovement;
    public UIManager high;
    private bool isDead = false;

    private void Start()
    {
        player = GetComponent<PlayerMovement>();
        isDead = false;
}

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            HandleCollision();
        }
    }

    private void Update()
    {
        if (UIManager.fuel <= 0 && !isDead)
        {
            HandlePlayerDeath();
        }
    }

    private void HandleCollision()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        LevelGenerate.GetComponent<LevelGenerator>().enabled = false;
        high.UpdateHighScore((int)player.score);
        StartCoroutine(Death());
    }

    private void HandlePlayerDeath()
    {
        isDead = true;
        HandleCollision();
    }

    IEnumerator Death()
    {
        UIManager.Instance.SetPlayerAlive(false);
        PlatformMovement.MoveSpeed = 0;
        AudioManager.Instance.StopMusic(SoundEnum.SoundTrack);
        AudioManager.Instance.PlaySFX(SoundEnum.Fall);
        yield return new WaitForSeconds(2.5f);
        UIManager.Instance.DeathUI();
    }
}
