using UnityEngine;
using UnityEngine.InputSystem;

public class mc_movement : MonoBehaviour
{
    public float moveSpeed = 75f;
    public string walkStateName = "mc_walk";
    public Vector2 chatTriggerPoint = new Vector2(32f, -26f);
    public float chatTriggerRadius = 1f;
    public chat_titulacek chatTarget;

    private Animator animator;
    private bool chatTriggered;
    private SceneChanger sceneChanger;

    void Awake()
    {
        animator = GetComponent<Animator>();
        sceneChanger = FindFirstObjectByType<SceneChanger>();

        if (chatTarget == null)
        {
            chatTarget = FindFirstObjectByType<chat_titulacek>();
        }

        if (animator != null)
        {
            animator.Play(walkStateName, 0, 0f);
            animator.speed = 0f;
        }
    }

    void Update()
    {
        float horizontalInput = 0f;
        Keyboard keyboard = Keyboard.current;

        if (keyboard != null && (keyboard.leftArrowKey.isPressed || keyboard.aKey.isPressed))
        {
            horizontalInput = -1f;
        }
        else if (keyboard != null && (keyboard.rightArrowKey.isPressed || keyboard.dKey.isPressed))
        {
            horizontalInput = 1f;
        }

        transform.position += Vector3.right * horizontalInput * moveSpeed * Time.deltaTime;

        if (horizontalInput != 0f)
        {
            Vector3 localScale = transform.localScale;
            localScale.x = Mathf.Abs(localScale.x) * Mathf.Sign(horizontalInput);
            transform.localScale = localScale;
        }

        if (animator != null)
        {
            animator.speed = horizontalInput == 0f ? 0f : 1f;
        }

        if (!chatTriggered)
        {
            Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
            if (Vector2.Distance(currentPosition, chatTriggerPoint) <= chatTriggerRadius)
            {
                chatTriggered = true;

                if (chatTarget != null)
                {
                    chatTarget.ActivateChat();
                }
            }
        }
    }

    public void GoToNextScene()
    {
        if (sceneChanger != null)
        {
            sceneChanger.GoToNextScene();
        }
    }
}
