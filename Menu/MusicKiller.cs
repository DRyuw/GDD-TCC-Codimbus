using UnityEngine;

public class StopMenuMusic : MonoBehaviour
{
    void Start()
    {
        MenuMusicManager music = FindObjectOfType<MenuMusicManager>();

        if (music != null)
        {
            Destroy(music.gameObject); 
        }
    }
}

