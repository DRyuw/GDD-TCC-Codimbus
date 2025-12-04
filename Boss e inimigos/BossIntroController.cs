using UnityEngine;
using UnityEngine.Video;

public class BossIntroController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject boss; 

    void Start()
    {
        boss.SetActive(false); 
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        boss.SetActive(true);   
        gameObject.SetActive(false); 
    }
}