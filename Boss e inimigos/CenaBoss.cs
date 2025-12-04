using UnityEngine;
using UnityEngine.Video;

public class VideoUIController : MonoBehaviour
{
    [Header("Referência do VideoPlayer")]
    public VideoPlayer videoPlayer;

    [Header("Raiz da UI do jogo")]
    public GameObject uiRoot; 

    void Awake()
    {
        
        if (videoPlayer == null)
            videoPlayer = GetComponent<VideoPlayer>();
    }

    void OnEnable()
    {
        if (videoPlayer != null)
        {
            
            videoPlayer.started += OnVideoStarted;
            
            videoPlayer.loopPointReached += OnVideoFinished;
        }
    }

    void OnDisable()
    {
        if (videoPlayer != null)
        {
            videoPlayer.started -= OnVideoStarted;
            videoPlayer.loopPointReached -= OnVideoFinished;
        }
    }

    void Start()
    {
       
        UpdateUIState();
    }

    void OnVideoStarted(VideoPlayer vp)
    {
        SetUIVisible(false); 
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        SetUIVisible(true); 
    }

    void UpdateUIState()
    {
        if (videoPlayer != null && videoPlayer.isPlaying)
            SetUIVisible(false);
        else
            SetUIVisible(true);
    }

    void SetUIVisible(bool visible)
    {
        if (uiRoot != null)
            uiRoot.SetActive(visible);
    }
}
