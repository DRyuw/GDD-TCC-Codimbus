using UnityEngine;
using UnityEngine.SceneManagement;

public class CenaAoInteragir : MonoBehaviour
{
    public string NomeCena;

    public void TrocarCena()
    {
        if (!string.IsNullOrEmpty(NomeCena))
        {
            SceneManager.LoadScene(NomeCena);
        }
        else
        {
            int cenaAtual = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(cenaAtual + 1);
        }
    }
}