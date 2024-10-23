using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public GameObject Model;
    public GameObject LevelGenerate;
    [SerializeField] private AudioSource fall;
    public PlayerMovement player;
    public PlatformMovement PlatformMovement;
    public UIManager high;
    public AudioSource bgm;
    private void Start()
    {
        player = GetComponent<PlayerMovement>();

    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Obstacles")){
            gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.GetComponent<PlayerMovement>().enabled = false;
            PlatformMovement.MoveSpeed = 0; 
            //Model.GetComponent<Animator>().SetTrigger("Death");
            fall.Play();
            LevelGenerate.GetComponent<LevelGenerator>().enabled = false;
            high.UpdateHighScore((int)player.score);
            StartCoroutine(Death());
            bgm.Stop();
        }
    }
    private void Update()
    {
        if (UIManager.fuel <= 0)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.GetComponent<PlayerMovement>().enabled = false;
            PlatformMovement.MoveSpeed = 0;
            fall.Play();
            LevelGenerate.GetComponent<LevelGenerator>().enabled = false;
            high.UpdateHighScore((int)player.score);
            StartCoroutine(Death());
            bgm.Stop();
        }
    }
    IEnumerator Death()
    {
        yield return new WaitForSeconds(2.5f);
        UIManager.Instance.DeathUI();
    }
}
