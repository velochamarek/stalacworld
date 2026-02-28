using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void StartNewScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
