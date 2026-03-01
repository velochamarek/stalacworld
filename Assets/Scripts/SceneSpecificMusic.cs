using UnityEngine;

public class SceneSpecificMusic : MonoBehaviour
{
    public AudioClip music;

    private void Start()
    {
        AudioSource audio = FindObjectOfType<AudioSource>();
        if (audio != null && music != null)
        {
            audio.clip = music;
            audio.Play();
        }
    }
}
