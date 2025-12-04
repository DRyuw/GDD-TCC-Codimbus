using UnityEngine;
using System.Collections;

public class GolpePeixesDeCima : MonoBehaviour
{
    [Header("Spawns (coloque 4)")]
    public Transform[] pontosDeSpawn; 
    public GameObject prefabPeixe;

    [Header("Configurações do Ataque")]
    public float delayEntreSpawns = 0.15f;
    public float fallSpeed = 40f;         
    public float intervaloAtaque = 10f;   

    private float timer;

    private void Start()
    {
        timer = intervaloAtaque;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            Debug.Log("[GolpePeixesDeCima] Iniciando ataque automático.");
            StartCoroutine(SpawnarPeixesAleatorios());
            timer = intervaloAtaque;
        }
    }

    private IEnumerator SpawnarPeixesAleatorios()
    {
        if (pontosDeSpawn.Length < 4)
        {
            Debug.LogWarning("[GolpePeixesDeCima] Coloque 4 pontos de spawn no Inspector!");
            yield break;
        }

        
        int[] indices = new int[4] { 0, 1, 2, 3 };
        System.Random rnd = new System.Random();
        for (int i = 0; i < indices.Length; i++)
        {
            int r = rnd.Next(i, indices.Length);
            int tmp = indices[i];
            indices[i] = indices[r];
            indices[r] = tmp;
        }

        
        for (int i = 0; i < 3; i++)
        {
            Transform ponto = pontosDeSpawn[indices[i]];
            GameObject peixe = Instantiate(prefabPeixe, ponto.position, prefabPeixe.transform.rotation);

           



            Debug.Log($"[GolpePeixesDeCima] Spawn #{i + 1} em {ponto.name} (idx {indices[i]})");

            Rigidbody rb = peixe.GetComponent<Rigidbody>();
            Rigidbody2D rb2D = peixe.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.useGravity = false;
                rb.isKinematic = false;
                rb.linearVelocity = Vector3.down * fallSpeed;
            }
            else if (rb2D != null)
            {
                rb2D.gravityScale = 0f;
                rb2D.bodyType = RigidbodyType2D.Dynamic;
                rb2D.linearVelocity = Vector2.down * fallSpeed;
            }

            yield return new WaitForSeconds(delayEntreSpawns);
        }
    }
}
