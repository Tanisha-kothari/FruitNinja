using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    public float timer;

    private bool isRunning = true;

    void Update()
    {
        if (!isRunning) return;

        timer += Time.deltaTime;
        timerText.text = ((int)timer).ToString();
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public void StartTimer()
    {
        isRunning = true;
    }

    public void ResetTimer()
    {
        timer = 0f;
        timerText.text = "0";
    }
}
