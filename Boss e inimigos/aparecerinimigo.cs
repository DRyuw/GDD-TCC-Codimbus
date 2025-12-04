using UnityEngine;

public class aparecerinimigo : MonoBehaviour
{
    [Header("Spawn de inimigos")]
    public GameObject prefabInimigo;
    public Transform[] pontosDeSpawn;
    private Transform jogador;

    [Header("Interação")]
    public GameObject textoInteragir;     
    public bool jogadorPerto = false;

    private void Start()
    {
        jogador = GameObject.FindGameObjectWithTag("Player")?.transform;

        if (textoInteragir != null)
            textoInteragir.SetActive(false);
    }

    private void Update()
    {
        if (jogadorPerto && Input.GetKeyDown(KeyCode.E))
        {
            Quebrar();
        }
    }

    public void Quebrar()
    {
        foreach (Transform ponto in pontosDeSpawn)
        {
            GameObject inimigo = Instantiate(prefabInimigo, ponto.position, prefabInimigo.transform.rotation);
            SeguirPlayer seguirScript = inimigo.GetComponent<SeguirPlayer>();
            if (seguirScript != null && jogador != null)
            {
                seguirScript.DefinirAlvo(jogador);
            }
        }

        Destroy(gameObject);

        if (textoInteragir != null)
            textoInteragir.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = true;
            if (textoInteragir != null)
                textoInteragir.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = false;
            if (textoInteragir != null)
                textoInteragir.SetActive(false);
        }
    }
}
