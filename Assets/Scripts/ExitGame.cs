using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void QuitGame()
    {
        // Ukonèí hru v buildu
        Application.Quit();

        // Ukáže zprávu v editoru (protože Application.Quit tam nic nedìlá)
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
