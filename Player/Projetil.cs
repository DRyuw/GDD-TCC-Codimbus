using UnityEngine;

public class Projetil : MonoBehaviour
{
    public float velocidade = 20f;
    public float tempoVida = 5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = transform.forward * velocidade;

        Destroy(gameObject, tempoVida);
    }

    void OnTriggerEnter(Collider other)
    {

        if (!other.CompareTag("Player"))
        {

            Destroy(gameObject);
        }
    }
}
