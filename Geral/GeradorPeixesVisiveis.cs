using UnityEngine;

public class GeradorPeixesVisiveis : MonoBehaviour
{
    public GameObject[] prefabsDePeixes; 
    public float intervaloSpawn = 2f; 
    public int maxPeixesNaCena = 20; 
    public float margemExtra = 1f; 
    public float velocidadeMin = 1f; 
    public float velocidadeMax = 3f; 

    private int peixesAtuais = 0;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
        InvokeRepeating(nameof(SpawnPeixeAleatorio), 0f, intervaloSpawn);
    }

    void SpawnPeixeAleatorio()
    {
        if (peixesAtuais >= maxPeixesNaCena) return;

        int index = Random.Range(0, prefabsDePeixes.Length);

        
        Vector3 posicaoTela = new Vector3(
            Random.Range(0f, 1f),
            Random.Range(0f, 1f),
            Mathf.Abs(cam.transform.position.z)
        );

        
        Vector3 posicaoMundo = cam.ViewportToWorldPoint(posicaoTela);

        
        posicaoMundo += new Vector3(
            Random.Range(-margemExtra, margemExtra),
            Random.Range(-margemExtra, margemExtra),
            0f
        );

        
        GameObject peixe = Instantiate(prefabsDePeixes[index], posicaoMundo, Quaternion.identity);
        peixesAtuais++;

       
        PeixeMovimento movimento = peixe.AddComponent<PeixeMovimento>();
        movimento.velocidade = Random.Range(velocidadeMin, velocidadeMax);
        movimento.direcao = Vector3.left;

       
        PeixeAutoDestroy autoDestroy = peixe.AddComponent<PeixeAutoDestroy>();
        autoDestroy.AoDestruir = () => peixesAtuais--;
    }
}

public class PeixeMovimento : MonoBehaviour
{
    public float velocidade = 2f;
    public Vector3 direcao = Vector3.left;

    void Update()
    {
        transform.Translate(direcao * velocidade * Time.deltaTime);
    }
}

public class PeixeAutoDestroy : MonoBehaviour
{
    public System.Action AoDestruir;
    private Renderer renderizador;

    void Start()
    {
        renderizador = GetComponent<Renderer>();
    }

    void Update()
    {
        
        if (renderizador != null && !renderizador.isVisible)
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        AoDestruir?.Invoke();
    }
}
