using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string nextScene;

    public void GoToNextScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
