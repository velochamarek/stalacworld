using UnityEngine;
using System.Collections;

public class BubbleFade : MonoBehaviour
{
    public float fadeSpeed = 10f;
    private CanvasGroup canvasGroup;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        if (canvasGroup == null) return;

        canvasGroup.alpha = 0f;   // začíná neviditelné
        FadeIn();                 // automaticky fade in po spuštění
    }

    public void FadeIn()
    {
        StartCoroutine(Fade(0f, 1f));
    }

    public void FadeOut()
    {
        StartCoroutine(Fade(1f, 0f));
    }

    IEnumerator Fade(float start, float end)
    {
        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime * fadeSpeed;
            canvasGroup.alpha = Mathf.Lerp(start, end, t);
            yield return null;
        }

        canvasGroup.alpha = end;
    }
}