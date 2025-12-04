using UnityEngine;

public class SeguirPlayer : MonoBehaviour
{
    private Transform alvo;
    private Rigidbody rb;

    public float velocidade = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

       
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }

    void FixedUpdate()
    {
        if (alvo != null)
        {
            Vector3 direcao = (alvo.position - transform.position).normalized;

           
            rb.MovePosition(rb.position + direcao * velocidade * Time.fixedDeltaTime);
        }
    }

    public void DefinirAlvo(Transform novoAlvo)
    {
        alvo = novoAlvo;
    }
}
