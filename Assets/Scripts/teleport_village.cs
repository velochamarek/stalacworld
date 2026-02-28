using UnityEngine;
using UnityEngine.SceneManagement;

public class teleport_village : MonoBehaviour
{
    public string sceneName = "vesnice";

    public void TeleportToVillage()
    {
        SceneManager.LoadScene(sceneName);
    }
}
