using UnityEngine;
using System.Collections;

public class RaioPisca : MonoBehaviour
{
    [Header("Intervalo de tempo (segundos)")]
    public float tempoLigado = 2f;
    public float tempoDesligado = 2f;

    private Renderer[] renderers; 

    private void Start()
    {
        
        renderers = GetComponentsInChildren<Renderer>(true);
        StartCoroutine(CicloDeRaio());
    }

    IEnumerator CicloDeRaio()
    {
        while (true)
        {
           
            foreach (Renderer r in renderers)
                r.enabled = true;

            yield return new WaitForSeconds(tempoLigado);

            
            foreach (Renderer r in renderers)
                r.enabled = false;

            yield return new WaitForSeconds(tempoDesligado);
        }
    }
}
