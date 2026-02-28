using UnityEngine;
using UnityEngine.SceneManagement;

public class teleport_ruins : MonoBehaviour
{
    public string sceneName = "ruins";

    public void TeleportToRuins()
    {
        SceneManager.LoadScene(sceneName);
    }
}
