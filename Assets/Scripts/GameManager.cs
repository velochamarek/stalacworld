using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Text diamondText;
    private int diamonds = 0;

    private void Awake()
    {
        Instance = this;
        UpdateUI();
    }

    public void AddDiamond()
    {
        diamonds++;
        UpdateUI();

        if (diamonds >= 3)
        {
            Debug.Log("Quest splnìn!");
        }
    }

    private void UpdateUI()
    {
        diamondText.text = diamonds + "/3";
    }
}
