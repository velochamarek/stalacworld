using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int diamondsCollected = 0;
    public int totalDiamonds = 3;

    public TextMeshProUGUI diamondText;

    private void Awake()
    {
        instance = this;
    }

    public void AddDiamond()
    {
        diamondsCollected++;
        diamondText.text = diamondsCollected + "/" + totalDiamonds;
    }
}