using System.Collections;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public GameObject Model;
    public GameObject LevelGenerate;
    public PlayerMovement player;
    public PlatformMovement PlatformMovement;
    public UIManager high;

    private void Start()
    {
        player = GetComponent<PlayerMovement>();
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.GetComponent<PlayerMovement>().enabled = false;
            PlatformMovement.MoveSpeed = 0;
            AudioManager.Instance.PlaySFX(SoundEnum.Fall);
            LevelGenerate.GetComponent<LevelGenerator>().enabled = false;
            high.UpdateHighScore((int)player.score);
            StartCoroutine(Death());
            AudioManager.Instance.StopMusic(SoundEnum.SoundTrack);
        }
    }

    private void Update()
    {
        if (UIManager.fuel <= 0)
        {
            HandlePlayerDeath();
        }
    }

    private void HandlePlayerDeath()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        PlatformMovement.MoveSpeed = 0;
        AudioManager.Instance.StopMusic(SoundEnum.SoundTrack);
        AudioManager.Instance.PlaySFX(SoundEnum.Fall);
        LevelGenerate.GetComponent<LevelGenerator>().enabled = false;
        high.UpdateHighScore((int)player.score);
        StartCoroutine(Death());
        
    }

    IEnumerator Death()
    {
        UIManager.Instance.SetPlayerAlive(false);
        yield return new WaitForSeconds(2.5f);
        UIManager.Instance.DeathUI();
    }
}
