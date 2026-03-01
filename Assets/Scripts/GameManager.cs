using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Text diamondText;
    public GameObject uiRoot;
    public GameObject levelCompleteText;
    public Image fadeImage;

    private int diamonds = 0;
    private bool levelFinished = false;

    private void Awake()
    {
        Instance = this;
        UpdateUI();

        if (levelCompleteText != null)
            levelCompleteText.SetActive(false);

        if (fadeImage != null)
            fadeImage.color = new Color(0, 0, 0, 0);
    }

    public void AddDiamond()
    {
        if (levelFinished)
            return;

        diamonds++;
        UpdateUI();

        if (diamonds >= 3)
        {
            levelFinished = true;
            StartCoroutine(LevelCompleteSequence());
        }
    }

    private void UpdateUI()
    {
        diamondText.text = diamonds + "/3";
    }

    private System.Collections.IEnumerator LevelCompleteSequence()
    {
        if (uiRoot != null)
            uiRoot.SetActive(false);

        if (levelCompleteText != null)
            levelCompleteText.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime;
            fadeImage.color = new Color(0, 0, 0, t);
            yield return null;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
