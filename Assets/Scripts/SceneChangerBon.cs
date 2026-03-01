using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneChangerBon : MonoBehaviour
{
    public string nextScene;
    public float minimumFadeWaitSeconds = 0.25f;
    public float bubbleTextAnimationDuration = 1f; // nová proměnná pro animaci textu
    public BubbleFade bubbleFade;

    private bool isTransitioning;

    void Awake()
    {
        if (bubbleFade == null)
        {
            bubbleFade = FindFirstObjectByType<BubbleFade>();
        }
    }

    public void GoToNextScene()
    {
        if (isTransitioning)
        {
            return;
        }

        StartCoroutine(GoToNextSceneRoutine());
    }

    private IEnumerator GoToNextSceneRoutine()
    {
        isTransitioning = true;

        // Čekání na animaci textové bubliny
        if (bubbleTextAnimationDuration > 0f)
        {
            yield return new WaitForSeconds(bubbleTextAnimationDuration);
        }

        // Spuštění fade efektu
        if (bubbleFade != null)
        {
            bubbleFade.FadeOut();

            float fadeDuration = bubbleFade.fadeSpeed > 0f ? 1f / bubbleFade.fadeSpeed : 0f;
            float waitTime = Mathf.Max(minimumFadeWaitSeconds, fadeDuration);
            if (waitTime > 0f)
            {
                yield return new WaitForSeconds(waitTime);
            }
        }

        LoadConfiguredScene();
    }

    private void LoadConfiguredScene()
    {
        if (!string.IsNullOrWhiteSpace(nextScene))
        {
            if (!Application.CanStreamedLevelBeLoaded(nextScene))
            {
                Debug.LogError("SceneChangerBon: Scene '" + nextScene + "' není v Build Settings.", this);
                return;
            }

            SceneManager.LoadScene(nextScene);
            return;
        }

        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = currentIndex + 1;

        if (nextIndex >= SceneManager.sceneCountInBuildSettings)
        {
            Debug.LogError("SceneChanger: Není další scéna po indexu " + currentIndex + ".", this);
            return;
        }

        SceneManager.LoadScene(nextIndex);
    }
}