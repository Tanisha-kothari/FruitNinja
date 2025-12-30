using UnityEngine;
using UnityEngine.SceneManagement;

public class HomePageManager : MonoBehaviour
{
    [SerializeField] string sceneName = "MainGame";
    [SerializeField] GameObject uiPanel;

    private void Awake()
    {
        uiPanel.SetActive(false);
    }
    public void OnPressPlay()
    {
        SceneManager.LoadScene(sceneName);

    }

    public void onPressTutorial()
    {
        uiPanel.SetActive(true);
    }
    public void onPressCloseTutorial()
    {
        uiPanel.SetActive(false);
    }
    public void ExitGame()
    {
        Application.Quit();
    }




}
