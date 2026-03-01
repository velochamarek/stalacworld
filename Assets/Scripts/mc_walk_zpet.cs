using UnityEngine;

public class mc_walk_zpet : MonoBehaviour
{
    public float speed = 10f;
    public Vector2 startPoint = new Vector2(53f, -48f);
    public Vector2 endPoint = new Vector2(138f, -48f);

    private bool hasReachedEnd;

    void Start()
    {
        Vector3 position = transform.position;
        transform.position = new Vector3(startPoint.x, startPoint.y, position.z);
    }

    void OnValidate()
    {
        if (Application.isPlaying)
        {
            return;
        }

        Vector3 position = transform.position;
        transform.position = new Vector3(startPoint.x, startPoint.y, position.z);
    }

    void Update()
    {
        if (hasReachedEnd)
        {
            return;
        }

        transform.position += Vector3.right * speed * Time.deltaTime;

        if (transform.position.x >= endPoint.x)
        {
            Vector3 position = transform.position;
            transform.position = new Vector3(endPoint.x, endPoint.y, position.z);
            hasReachedEnd = true;
            gameObject.SetActive(false);
        }
    }
}
