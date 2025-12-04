using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class BossVida : MonoBehaviour
{
    [Header("Vida do Boss")]
    public int maxHits = 15;
    private int currentHits = 0;

    public Slider sliderVida;

    [Header("Flash de Dano")]
    public Renderer bossRenderer;
    public float flashTime = 0.1f;
    public float flashIntensity = 3f;

    [Header("Invulnerabilidade")]
    public float tempoInvulnerabilidade = 0.5f;
    private bool invulneravel = false;

    private Material bossMat;
    private Color originalEmission;

    [Header("Cena ao morrer")]
    public bool usarCenaPorNome = false;
    public string nomeCenaAoMorrer = "Final";  

    void Start()
    {
        if (bossRenderer == null)
            bossRenderer = GetComponentInChildren<Renderer>();

        bossMat = bossRenderer.material;

        if (bossMat.HasProperty("_EmissionColor"))
            originalEmission = bossMat.GetColor("_EmissionColor");
        else
            originalEmission = Color.black;

        if (sliderVida != null)
        {
            sliderVida.minValue = 0;
            sliderVida.maxValue = maxHits;
            sliderVida.value = maxHits;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ArmaDano") && !invulneravel)
        {
            Dano();
        }
    }

    void Dano()
    {
        currentHits++;

        if (sliderVida != null)
            sliderVida.value = maxHits - currentHits;

        StartCoroutine(FlashDano());
        StartCoroutine(Invulnerabilidade());

        if (currentHits >= maxHits)
        {
            MorrerB();
        }
    }

    IEnumerator FlashDano()
    {
        if (bossMat.HasProperty("_EmissionColor"))
        {
            bossMat.EnableKeyword("_EMISSION");

            Color flash = Color.white * flashIntensity;
            bossMat.SetColor("_EmissionColor", flash);

            yield return new WaitForSeconds(flashTime);

            bossMat.SetColor("_EmissionColor", originalEmission);
        }
    }

    IEnumerator Invulnerabilidade()
    {
        invulneravel = true;
        yield return new WaitForSeconds(tempoInvulnerabilidade);
        invulneravel = false;
    }

    void MorrerB()
    {
        if (usarCenaPorNome && !string.IsNullOrEmpty(nomeCenaAoMorrer))
        {
            Debug.Log("Boss morreu, carregando cena por nome: " + nomeCenaAoMorrer);
            SceneManager.LoadScene(nomeCenaAoMorrer);
        }
        else
        {
            Debug.Log("Boss morreu, carregando próxima cena do Build Settings");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
