using UnityEngine;

public class jeskyne2 : MonoBehaviour
{
    public float moveSpeed = 3f;
    public string walkStateName = "mc_walk";
    public Vector2 startPoint = new Vector2(-3.0518f, -3.0518f);
    public Vector2 endPoint = new Vector2(0f, -1.5259f);

    private Animator animator;
    private RectTransform rectTransform;
    private bool hasReachedEnd;

    void Awake()
    {
        animator = GetComponent<Animator>();
        rectTransform = GetComponent<RectTransform>();
    }

    void Start()
    {
        SetCurrentPosition(startPoint);

        Vector3 localScale = transform.localScale;
        localScale.x = Mathf.Abs(localScale.x);
        transform.localScale = localScale;

        if (animator != null)
        {
            animator.Play(walkStateName, 0, 0f);
            animator.speed = 1f;
        }
    }

    void Update()
    {
        if (hasReachedEnd)
        {
            return;
        }

        Vector2 currentPosition = GetCurrentPosition();
        Vector2 nextPosition = Vector2.MoveTowards(currentPosition, endPoint, moveSpeed * Time.deltaTime);
        SetCurrentPosition(nextPosition);

        if (Vector2.Distance(nextPosition, endPoint) <= 0.01f)
        {
            SetCurrentPosition(endPoint);
            hasReachedEnd = true;

            if (animator != null)
            {
                animator.speed = 0f;
            }
        }
    }

    private Vector2 GetCurrentPosition()
    {
        if (rectTransform != null)
        {
            return rectTransform.anchoredPosition;
        }

        return new Vector2(transform.localPosition.x, transform.localPosition.y);
    }

    private void SetCurrentPosition(Vector2 position)
    {
        if (rectTransform != null)
        {
            rectTransform.anchoredPosition = position;
            return;
        }

        Vector3 current = transform.localPosition;
        transform.localPosition = new Vector3(position.x, position.y, current.z);
    }
}
