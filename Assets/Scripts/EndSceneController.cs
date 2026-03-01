using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneController : MonoBehaviour
{
    public string nextSceneName = "MainMenu";
    public float delay = 10f;   // 10 sekund

    // Tuhle funkci zavolá Animation Event
    public void OnAnimationFinished()
    {
        StartCoroutine(LoadAfterDelay());
    }

    private System.Collections.IEnumerator LoadAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(nextSceneName);
    }
}
