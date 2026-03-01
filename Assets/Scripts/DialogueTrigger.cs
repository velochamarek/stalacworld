using UnityEngine;
using System.Collections;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject dialog1;
    public GameObject dialog2;
    public GameObject defaultDialog;

    public GameObject minesButton;  

    public GameObject player;

    public Vector2 targetPosition = new Vector2(0f, 24f);

    private bool hasTriggered;

    private void Awake()
    {
        HideDialogue(dialog1);
        HideDialogue(dialog2);
        HideDialogue(minesButton);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasTriggered || collision == null) return;

        bool isConfiguredPlayer = player != null && collision.gameObject == player;
        bool hasMovementComponent = collision.GetComponent<mc_movement>() != null;

        if (isConfiguredPlayer || hasMovementComponent || collision.CompareTag("Player"))
        {
            hasTriggered = true;

            if (defaultDialog != null)
            {
                defaultDialog.SetActive(false);
            }

            mc_movement movement = collision.GetComponent<mc_movement>();
            if (movement != null)
            {
                movement.enabled = false;
            }

            StartCoroutine(ShowDialogue());
        }
    }

    IEnumerator ShowDialogue()
    {
        HideDialogue(dialog1);
        HideDialogue(dialog2);
        HideDialogue(minesButton);

        if (dialog1 != null)
        {
            MoveDialogueToTarget(dialog1);
            dialog1.SetActive(true);
        }

        yield return new WaitForSeconds(5f);

        HideDialogue(dialog1);

        if (dialog2 != null)
        {
            MoveDialogueToTarget(dialog2);
            dialog2.SetActive(true);
        }

        yield return new WaitForSeconds(5f);

        HideDialogue(dialog2);

        if (minesButton != null)
        {
            MoveDialogueToTarget(minesButton);
            minesButton.SetActive(true);
        }
    }

    private void HideDialogue(GameObject dialog)
    {
        if (dialog == null)
            return;

        dialog.SetActive(false);
    }

    private void MoveDialogueToTarget(GameObject dialog)
    {
        if (dialog == null)
            return;

        RectTransform rectTransform = dialog.GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            rectTransform.anchoredPosition = targetPosition;
            return;
        }

        Vector3 worldPosition = dialog.transform.position;
        dialog.transform.position = new Vector3(targetPosition.x, targetPosition.y, worldPosition.z);
    }
}
