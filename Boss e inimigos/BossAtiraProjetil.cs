using UnityEngine;

public class BossAtiraProjetil : MonoBehaviour
{
    public GameObject projetilPrefab;

    public Transform pontoDeSpawn;

    public float intervaloEntreTiros = 10f; 

    private float timer;
        
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= intervaloEntreTiros)
        {
            Atirar();
            timer = 0f;
        }
    }

    void Atirar()
    {
        if (projetilPrefab == null || pontoDeSpawn == null)
        {
            Debug.LogWarning("? Boss sem prefab ou ponto de spawn configurado!");
            return;
        }

        Instantiate(projetilPrefab, pontoDeSpawn.position, pontoDeSpawn.rotation);
    }
}
