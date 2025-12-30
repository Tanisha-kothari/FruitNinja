using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using System.Collections;

public class CutsceneManager : MonoBehaviour
{
    public static CutsceneManager Instance;

    [Header("UI Panel")]
    [SerializeField] private GameObject cutscenePanel;

    [Header("Video")]
    [SerializeField] private VideoPlayer videoPlayer;

    [Header("Settings")]
    public float cutsceneDuration = 10.5f;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        cutscenePanel.SetActive(false);

        if (videoPlayer == null)
            Debug.LogError("VideoPlayer NOT assigned!");
    }

    public void PlayBombCutscene()
    {
        StartCoroutine(PlayCutsceneRoutine());
    }

    private IEnumerator PlayCutsceneRoutine()
    {
        PausePlayMenu.Pause();

        cutscenePanel.SetActive(true);

        videoPlayer.Stop();   // safety first
        videoPlayer.Play();   // BOOM 💣🎬

        yield return new WaitForSecondsRealtime(
            (float)videoPlayer.length
        );

        PausePlayMenu.Resume();
        SceneManager.LoadScene("HomePage");
    }


}