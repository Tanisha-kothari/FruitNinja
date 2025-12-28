using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePlayMenu : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameTimer gameTimer;

    [SerializeField] string sceneName = "HomePage";

    private void Awake()
    {
        menu.SetActive(false);
    }

    public void OpenMenu()
    {
        menu.SetActive(true);
        Time.timeScale = 0f;
        gameTimer.StopTimer();
    }

    public void CloseMenu()
    {
        menu.SetActive(false);
        Time.timeScale = 1f;
        gameTimer.StartTimer();
    }

    public void GoHome()
    {
        menu.SetActive(false);
        Time.timeScale = 0f;
        gameTimer.StopTimer();
        SceneManager.LoadScene(sceneName);
    }
}
