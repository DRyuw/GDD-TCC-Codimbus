using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoFinalMenu : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string cenaMenu = "Menu";

    void Start()
    {
        if (videoPlayer == null)
            videoPlayer = GetComponent<VideoPlayer>();

        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached += OnVideoFinished;

            videoPlayer.Play();
        }
        else
        {
            Debug.LogWarning("Nenhum VideoPlayer encontrado no VideoFinalMenu!");
        }
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        SceneManager.LoadScene(cenaMenu);
    }
}
