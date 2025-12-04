using System.Collections;
using UnityEngine;

public class LightningManager : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject warningPrefab;
    public GameObject lightningPrefab;
    public GameObject HitBox;

    [Header("Pontos de impacto")]
    public Transform[] lightningPoints; 

    [Header("Tempos")]
    public float warningDuration = 1.5f;
    public float delayBetweenStrikes = 3f;

    [Header("Configuração dos raios")]
    public int minLightningLayers = 3;
    public int maxLightningLayers = 5;
    public float layerHeightOffset = 0.5f;
    public float rotationVariation = 15f;
    public float sizeVariation = 0.2f;
    public Vector2 lifetimeRange = new Vector2(0.3f, 0.8f);
    public float delayBetweenLayers = 0.1f;

    [Header("Collider (Hitbox)")]
    public Vector3 colliderSize = new Vector3(1f, 2f, 1f); 
    public LayerMask hitLayers; 
    public bool showColliderGizmo = false; 

    void Start()
    {
        StartCoroutine(SpawnLightningLoop());
    }

    private IEnumerator SpawnLightningLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(delayBetweenStrikes);

           
            Transform targetPoint = lightningPoints[Random.Range(0, lightningPoints.Length)];
            Vector3 spawnPosition = targetPoint.position;

            
            GameObject warning = Instantiate(warningPrefab, spawnPosition + Vector3.up * 2f, Quaternion.identity);
            yield return new WaitForSeconds(warningDuration);
            Destroy(warning);

            
            yield return StartCoroutine(SpawnSequentialLightning(spawnPosition));
        }
    }

    private IEnumerator SpawnSequentialLightning(Vector3 basePosition)
    {
        int lightningCount = Random.Range(minLightningLayers, maxLightningLayers + 1);

        for (int i = 0; i < lightningCount; i++)
        {
            
            Vector3 pos = basePosition + Vector3.up * (i * layerHeightOffset);

            
            Quaternion randomRot = Quaternion.Euler(
                Random.Range(-rotationVariation, rotationVariation),
                Random.Range(0f, 360f),
                Random.Range(-rotationVariation, rotationVariation)
            );

            float randomScale = 1f + Random.Range(-sizeVariation, sizeVariation);

           
            GameObject lightning = Instantiate(lightningPrefab, pos, randomRot);
            lightning.transform.localScale *= randomScale;

           
            float life = Random.Range(lifetimeRange.x, lifetimeRange.y);

            
            GameObject hitbox = new GameObject("LightningHitbox");
            hitbox.transform.position = pos;
            hitbox.transform.rotation = randomRot;
            hitbox.tag = "Inimigo";

           
            BoxCollider box = hitbox.AddComponent<BoxCollider>();
            box.isTrigger = true;
            box.size = colliderSize;

            
            LightningHitbox lh = hitbox.AddComponent<LightningHitbox>();
            lh.lifeTime = life;
            lh.layersToHit = hitLayers;

            
            Destroy(lightning, life);
            Destroy(hitbox, life);

            
            yield return new WaitForSeconds(delayBetweenLayers);
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        if (!showColliderGizmo || lightningPoints == null)
            return;

        Gizmos.color = Color.cyan;
        foreach (var point in lightningPoints)
        {
            if (point != null)
                Gizmos.DrawWireCube(point.position, colliderSize);
        }
    }
#endif
}
