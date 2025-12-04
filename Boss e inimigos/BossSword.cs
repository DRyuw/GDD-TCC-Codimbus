using UnityEngine;
using System.Collections;

public class BossSword : MonoBehaviour
{
    [Header("Configuração do ataque")]
    public GameObject SwordPrefab;
    public Transform spawnPoint;
    public float warningTime = 1.5f;
    public float SwordSpeed = 30f;
    public float SwordLifetime = 3f;
    public float attackInterval = 6f;

    private float attackTimer;
    private bool isAttacking;

    private void Start()
    {
        attackTimer = attackInterval;
    }

    private void Update()
    {
        attackTimer -= Time.deltaTime;

        if (attackTimer <= 0f && !isAttacking)
        {
            StartCoroutine(FireSword());
            attackTimer = attackInterval;
        }
    }

    private IEnumerator FireSword()
    {
        isAttacking = true;

        GameObject Sword = Instantiate(SwordPrefab, spawnPoint.position, Quaternion.identity);
        Sword.SetActive(false);

        yield return new WaitForSeconds(warningTime);

        if (Sword != null)
        {
            Sword.SetActive(true);

            Vector3 escala = Sword.transform.localScale;
            if (escala.x > 0)
                escala.x *= -1;
            Sword.transform.localScale = escala;

            Rigidbody rb = Sword.GetComponent<Rigidbody>();
            Rigidbody2D rb2D = Sword.GetComponent<Rigidbody2D>();

            if (rb != null)
                rb.linearVelocity = Vector3.left * SwordSpeed; 
            else if (rb2D != null)
                rb2D.linearVelocity = Vector2.left * SwordSpeed;

            Destroy(Sword, SwordLifetime);
        }

        isAttacking = false;
    }
}