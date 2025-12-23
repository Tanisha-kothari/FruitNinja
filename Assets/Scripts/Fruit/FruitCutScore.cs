using TMPro;
using UnityEngine;

public class FruitCutScore : MonoBehaviour
{
    public static FruitCutScore Instance;
    [SerializeField] TextMeshProUGUI Textscore;
    public int score;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddScore(int amount = 1)
    {
        score += amount;
        Textscore.text = "Fruits cut : " + score.ToString();
    }
}
