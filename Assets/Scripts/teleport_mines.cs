using UnityEngine;
using UnityEngine.SceneManagement;

public class teleport_mines : MonoBehaviour
{
    public string sceneName = "mines";

    public void TeleportToMines()
    {
        SceneManager.LoadScene(sceneName);
    }
}
