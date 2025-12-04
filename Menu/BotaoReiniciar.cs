using UnityEngine;
using UnityEngine.SceneManagement;

public class BotaoReiniciar : MonoBehaviour
{
    public void Reiniciar()
    {
        int cena = PlayerPrefs.GetInt("UltimaCenaViva", -1);

        if (cena >= 0)
        {
            SceneManager.LoadScene(cena);
        }
        else
        {
            Debug.LogWarning("Nenhuma cena viva encontrada! Carregando cena 0.");
            SceneManager.LoadScene(0);
        }
    }
}
