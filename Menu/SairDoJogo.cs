using UnityEngine;

public class SairDoJogo : MonoBehaviour
{
    public void Sair()
    {
        Debug.Log("SAINDO DO JOGO...");

        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
