using UnityEngine;

public class ProjetilSeguir : MonoBehaviour
{
    [Header("Configurações")]
    public float velocidade = 8f;
    public float velocidadeDeGiro = 360f;
    public float tempoDeVida = 5f;

    private Transform alvo;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.freezeRotation = true;

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            alvo = playerObj.transform;

        Destroy(gameObject, tempoDeVida);
    }

    void FixedUpdate()
    {
        if (alvo == null) return;

        Vector3 alvoPos = alvo.position;
        alvoPos.z = transform.position.z;

        Vector3 direcao = (alvoPos - transform.position).normalized;

        float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;
        Quaternion rotacaoDesejada = Quaternion.Euler(0, 0, angulo);

        transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            rotacaoDesejada,
            velocidadeDeGiro * Time.fixedDeltaTime
        );

        rb.MovePosition(transform.position + transform.right * velocidade * Time.fixedDeltaTime);
    }
}
