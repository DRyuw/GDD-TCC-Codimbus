using UnityEngine;
using UnityEngine.UI;

public class VidaUI : MonoBehaviour
{
    public Image[] vidas;
    private int vidaAtual;

    void Start()
    {
        vidaAtual = vidas.Length;
    }

    public void TomarDano()
    {
        if (vidaAtual > 0)
        {
            vidaAtual--;
            vidas[vidaAtual].gameObject.SetActive(false);
        }
    }

    public void ResetarVidas()
    {
        foreach (Image vida in vidas)
        {
            vida.gameObject.SetActive(true);
        }

        vidaAtual = vidas.Length;
    }
}
