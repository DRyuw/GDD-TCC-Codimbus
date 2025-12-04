using UnityEngine;

public class Thunder : MonoBehaviour
{
    public float lifetime = 1f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Trovão atingiu o jogador!");
           
        }

        Destroy(gameObject); 
    }
}
