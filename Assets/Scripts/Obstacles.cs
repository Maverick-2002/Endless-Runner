using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public GameObject Model;
    public GameObject LevelGenerate;
    [SerializeField] private AudioSource fall;
    public PlayerMovement player;
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
            Model.GetComponent<Animator>().SetTrigger("Death");
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
