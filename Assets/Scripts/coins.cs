using UnityEngine;


public class coins : MonoBehaviour
{
    [SerializeField] private AudioSource coin;
    

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Collectables"))
        {
            UIManager.Instance.Score();
            coin.Play();
            Destroy(collision.gameObject);
        }
    }
}
