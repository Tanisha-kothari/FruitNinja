using UnityEngine;
using UnityEngine.SceneManagement;

public class HomePageManager : MonoBehaviour
{
    [SerializeField] string sceneName = "MainGame";
    public void OnPressPlay()
    {
        SceneManager.LoadScene(sceneName);

    }
}
