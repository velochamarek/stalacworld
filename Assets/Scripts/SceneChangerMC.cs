using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerMC : MonoBehaviour
{
    public Vector2 endPoint = new Vector2(138f, -48f);
    public float reachThreshold = 0.01f;
    public string nextScene;

    private bool switched;

    void Update()
    {
        if (switched)
        {
            return;
        }

        Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
        if (Vector2.Distance(currentPosition, endPoint) <= reachThreshold)
        {
            switched = true;
            LoadScene();
        }
    }

    private void LoadScene()
    {
        if (!string.IsNullOrWhiteSpace(nextScene))
        {
            if (!Application.CanStreamedLevelBeLoaded(nextScene))
            {
                Debug.LogError("SceneChangerMC: Scene '" + nextScene + "' není v Build Settings.", this);
                return;
            }

            SceneManager.LoadScene(nextScene);
            return;
        }

        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = currentIndex + 1;
        if (nextIndex >= SceneManager.sceneCountInBuildSettings)
        {
            Debug.LogError("SceneChangerMC: Není další scéna po indexu " + currentIndex + ".", this);
            return;
        }

        SceneManager.LoadScene(nextIndex);
    }
}
