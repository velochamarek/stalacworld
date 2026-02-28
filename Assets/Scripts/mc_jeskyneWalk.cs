using UnityEngine;

public class mc_jeskyneWalk : MonoBehaviour
{
    public float speed = 3f;
    public Vector2 startPoint = new Vector2(-33f, -27f);
    public Vector2 endPoint = new Vector2(-4.5f, -10f);

    private bool hasReachedEnd;

    void Start()
    {
        Vector3 current = transform.position;
        transform.position = new Vector3(startPoint.x, startPoint.y, current.z);
    }

    void Update()
    {
        if (hasReachedEnd)
        {
            return;
        }

        Vector3 target = new Vector3(endPoint.x, endPoint.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) <= 0.01f)
        {
            transform.position = target;
            hasReachedEnd = true;
            gameObject.SetActive(false);
        }
    }
}
