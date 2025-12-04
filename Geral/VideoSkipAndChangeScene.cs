using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoSkipAndChangeScene : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string nextScene = "Menu";   
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
            Debug.LogWarning("VideoSkipAndChangeScene: nenhum VideoPlayer encontrado!");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space))
        {
            TrocarCena();
        }
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        TrocarCena();
    }

    void TrocarCena()
    {
        if (!string.IsNullOrEmpty(nextScene))
        {
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            Debug.LogWarning("VideoSkipAndChangeScene: nextScene não definido!");
        }
    }
}
