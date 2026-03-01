using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;

    public AudioSource audioSource;   // nový audio systém
    public AudioClip musicClip;       // tvoje hudba

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
            return;
        }

        audioSource.clip = musicClip;
        audioSource.loop = true;
        audioSource.Play();
    }
}
