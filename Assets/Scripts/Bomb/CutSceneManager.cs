using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CutsceneManager : MonoBehaviour
{
    public static CutsceneManager Instance;

    [Header("UI Panel")]
    [SerializeField] private GameObject cutscenePanel;              // Panel with Image component
    [SerializeField] private Animator cutscenePanelAnimator;        // Animator controlling bomb animation

    [Header("Settings")]
    public float cutsceneDuration = 10.5f;

    private void Awake()
    {
        // Singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        // Validation
        if (cutscenePanel == null)
            Debug.LogError("CutscenePanel NOT assigned in Inspector!");
        if (cutscenePanelAnimator == null)
            Debug.LogError("CutscenePanelAnimator NOT assigned in Inspector!");

        cutscenePanel.SetActive(false);
    }

    /// <summary>
    /// Call this when player cuts a bomb
    /// </summary>
    public void PlayBombCutscene()
    {
        StartCoroutine(PlayCutsceneRoutine());
    }

    private IEnumerator PlayCutsceneRoutine()
    {
        // Pause the game menu or player input
        PausePlayMenu.Pause();

        // Show the panel
        cutscenePanel.SetActive(true);

        // Trigger the bomb animation
        if (cutscenePanelAnimator != null)
            cutscenePanelAnimator.SetTrigger("PlayBombAnim");


        // Wait for cutscene duration
        yield return new WaitForSecondsRealtime(cutsceneDuration);

        // Resume the game
        PausePlayMenu.Resume();

        // Load HomePage
        SceneManager.LoadScene("HomePage");
    }
}
