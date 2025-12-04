using UnityEngine;
using UnityEngine.SceneManagement;

public class Vida : MonoBehaviour
{
    public int maxHits = 3;
    private int currentHits = 0;

    public float tempoInvulnerabilidade = 1f;
    private float tempoUltimoDano = -999f;

    private Movement movement;

    public VidaUI vidaUI;

    void Start()
    {
        movement = GetComponent<Movement>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Inimigo"))
        {
            TomarDano();
        }
    }

   public void TomarDano()
    {
        
        if (!CompareTag("Player"))
            return;

        
        if (movement != null && movement.isDashing)
        {
            Debug.Log("Dano ignorado (player está dashing)");
            return;
        }

        
        if (Time.time - tempoUltimoDano < tempoInvulnerabilidade)
            return;

        tempoUltimoDano = Time.time;
        currentHits++;

        if (vidaUI != null)
        {
            vidaUI.TomarDano();
        }

        Debug.Log("Player tomou dano! Total de hits: " + currentHits);

        if (currentHits >= maxHits)
        {
            Morrer();
        }
    }

    void Morrer()
    {
        Debug.Log("Player morreu!");

        int cenaAtual = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("UltimaCenaViva", cenaAtual);
        PlayerPrefs.Save();

        SceneManager.LoadScene("GameOver");
    }
}
