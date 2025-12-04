using UnityEngine;

public class VidaInimigo : MonoBehaviour
{
    [Header("Vida do inimigo")]
    public int maxHits = 15;
    private int currentHits = 0;

    [Header("Dano no player")]
    public bool destruirAoEncostarNoPlayer = true; 
    public string tagPlayer = "Player";

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ArmaDano"))
        {
            Dano();
        }
        else if (other.CompareTag(tagPlayer))
        {
            Vida vidaPlayer = other.GetComponent<Vida>();
            if (vidaPlayer != null)
            {
                vidaPlayer.TomarDano();
                Debug.Log("Inimigo deu dano no player!");
            }

            if (destruirAoEncostarNoPlayer)
            {
                MorrerB();
            }
        }
    }

    void Dano()
    {
        currentHits++;

        Debug.Log("Inimigo tomou dano! Total de hits: " + currentHits);

        if (currentHits >= maxHits)
        {
            MorrerB();
        }
    }

    void MorrerB()
    {
        Debug.Log("Inimigo morreu!!!");
        gameObject.SetActive(false);   
    }
}
