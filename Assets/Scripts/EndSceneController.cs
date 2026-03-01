using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneController : MonoBehaviour
{
    public AudioSource musicSource;     // hudba z You Win scény
    public string nextSceneName = "MainMenu";  // cílová scéna

    // Tuhle funkci zavolá animace na konci (Animation Event)
    public void OnAnimationFinished()
    {
        if (musicSource != null)
        {
            musicSource.Stop();
        }

        SceneManager.LoadScene(nextSceneName);
    }
}
