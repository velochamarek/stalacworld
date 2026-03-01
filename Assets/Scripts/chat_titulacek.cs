using UnityEngine;

public class chat_titulacek : MonoBehaviour
{
    public Animator speechBubbleAnimator;
    public string speechBubbleState = "speech_bubbles";

    public void ActivateChat()
    {
        gameObject.SetActive(true);

        if (speechBubbleAnimator != null && !string.IsNullOrEmpty(speechBubbleState))
        {
            speechBubbleAnimator.Play(speechBubbleState, 0, 0f);
        }
    }
}
