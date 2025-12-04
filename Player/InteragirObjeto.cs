using UnityEngine;

public class InteragirObjeto : MonoBehaviour
{
    public float raioInteracao = 5f;
    public LayerMask camadaInterativa;
    public Transform pontoRaio;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            VerificarObjetoProximo();
        }
    }

    void VerificarObjetoProximo()
    {
        Collider[] objetos = Physics.OverlapSphere(pontoRaio.position, raioInteracao, camadaInterativa);

        foreach (Collider col in objetos)
        {
            
            aparecerinimigo scriptInimigo = col.GetComponent<aparecerinimigo>();
            if (scriptInimigo != null)
            {
                scriptInimigo.Quebrar();
            }
            else
            {
                
                CenaAoInteragir trocaCena = col.GetComponent<CenaAoInteragir>();
                if (trocaCena != null)
                {
                    trocaCena.TrocarCena(); 
                }

                Destroy(col.gameObject); 
            }

            Debug.Log("Objeto destruído: " + col.name);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (pontoRaio != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(pontoRaio.position, raioInteracao);
        }
    }
}