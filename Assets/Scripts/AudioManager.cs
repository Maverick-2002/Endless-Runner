using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public static AudioManager Instance { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            Instance = instance;
            DontDestroyOnLoad(gameObject); // Ensure that the AudioManager persists between scenes
        }
    }

    // Add any other audio-related variables here

    public void PlayAudio(AudioClip clip)
    {
        if (clip == null)
        {
            Debug.LogWarning("Trying to play a null AudioClip.");
            return;
        }

        AudioSource.PlayClipAtPoint(clip, transform.position);
        Debug.Log("Audio played.");
    }

}
