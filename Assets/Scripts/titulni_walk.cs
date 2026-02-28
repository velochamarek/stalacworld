using UnityEngine;
using System.Collections;
 
public class TitulniPanacek : MonoBehaviour
{
    public float rychlost = 2f;
    public Vector2 start = new Vector2(1.573f, 1.491f);
    public Vector2 cil = new Vector2(42f, -17f);
    public float endScaleFactor = 0.5f;
    public float delayPoZmizeni = 0f;

    private Vector2 startPosition;
    private Vector3 startScale;
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = transform as RectTransform;
        startPosition = start;
        SetCurrentPosition(startPosition);
        startScale = transform.localScale;
        StartCoroutine(PohybovaSmycka());
    }

    void OnValidate()
    {
        if (Application.isPlaying)
        {
            return;
        }

        SetCurrentPosition(start);
    }

    IEnumerator PohybovaSmycka()
    {
        while (true)
        {
            float totalDistance = Mathf.Max(0.0001f, Vector2.Distance(startPosition, cil));

            while (Vector2.Distance(GetCurrentPosition(), cil) > 0.01f)
            {
                Vector2 nextPosition = Vector2.MoveTowards(
                    GetCurrentPosition(),
                    cil,
                    rychlost * Time.deltaTime
                );
                SetCurrentPosition(nextPosition);

                float remainingDistance = Vector2.Distance(nextPosition, cil);
                float t = Mathf.Clamp01(1f - (remainingDistance / totalDistance));
                float scaleFactor = Mathf.Lerp(1f, endScaleFactor, t);
                transform.localScale = startScale * scaleFactor;

                yield return null;
            }

            transform.localScale = Vector3.zero;
            yield return new WaitForSeconds(delayPoZmizeni);

            SetCurrentPosition(startPosition);
            transform.localScale = startScale;
        }
    }

    private Vector2 GetCurrentPosition()
    {
        RectTransform currentRectTransform = rectTransform != null ? rectTransform : transform as RectTransform;
        if (currentRectTransform != null)
        {
            return currentRectTransform.anchoredPosition;
        }

        return new Vector2(transform.position.x, transform.position.y);
    }

    private void SetCurrentPosition(Vector2 position)
    {
        RectTransform currentRectTransform = rectTransform != null ? rectTransform : transform as RectTransform;
        if (currentRectTransform != null)
        {
            currentRectTransform.anchoredPosition = position;
            return;
        }

        Vector3 current = transform.position;
        transform.position = new Vector3(position.x, position.y, current.z);
    }
}