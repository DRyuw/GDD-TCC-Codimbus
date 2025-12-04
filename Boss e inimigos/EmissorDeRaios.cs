using UnityEngine;
using System.Collections;

public class EmissorDeRaios : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject raioPrefab;
    public GameObject indicadorPrefab;

    [Header("Ponto de spawn")]
    public Transform pontoDeSaida;

    [Header("Configurações")]
    public int quantidadeDeRaios = 6;     
    public float intervalo = 3f;         
    public float tempoDeAviso = 1f;       
    public float incrementoPorAtaque = 15f; 

    private float timer;
    private float offsetDeRotacao = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= intervalo)
        {
            StartCoroutine(DispararRaiosComAviso());
            timer = 0f;
        }
    }

    IEnumerator DispararRaiosComAviso()
    {
        float anguloEntre = 360f / quantidadeDeRaios;

       
        for (int i = 0; i < quantidadeDeRaios; i++)
        {
            float angulo = i * anguloEntre + offsetDeRotacao;
            Quaternion rot = Quaternion.Euler(0, 0, angulo);

            GameObject indicador = Instantiate(indicadorPrefab, pontoDeSaida.position, rot);
            Destroy(indicador, tempoDeAviso); 
        }

        yield return new WaitForSeconds(tempoDeAviso);

       
        for (int i = 0; i < quantidadeDeRaios; i++)
        {
            float angulo = i * anguloEntre + offsetDeRotacao;
            Quaternion rot = Quaternion.Euler(0, 0, angulo);

            Instantiate(raioPrefab, pontoDeSaida.position, rot);
        }

        
        offsetDeRotacao += incrementoPorAtaque;
    }
}
