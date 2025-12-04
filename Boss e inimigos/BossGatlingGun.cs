using UnityEngine;
using System.Collections;

public class BossGatlingGun : MonoBehaviour
{
    public GameObject punchPrefab;
    public Transform punchOrigin;

    public float punchInterval = 0.1f;
    public float attackDuration = 2f;
    public int punchesPerWave = 4;
    public float spreadRangeX = 0.2f;
    public float spreadRangeY = 0.2f;

    public float punchLifetime = 0.15f;

    private bool isAttacking = false;

    public void StartGatlingAttack()
    {
        if (!isAttacking)
            StartCoroutine(GatlingGunAttack());
    }

    private IEnumerator GatlingGunAttack()
    {
        if (punchPrefab == null || punchOrigin == null)
        {
            Debug.LogError("punchPrefab ou punchOrigin não foi atribuído!");
            yield break;
        }

        isAttacking = true;

        float elapsedTime = 0f;

        while (elapsedTime < attackDuration)
        {
            for (int i = 0; i < punchesPerWave; i++)
            {
                Vector3 randomOffset = new Vector3(
                    Random.Range(-spreadRangeX, spreadRangeX),
                    Random.Range(-spreadRangeY, spreadRangeY)
                );

                GameObject punch = Instantiate(
                    punchPrefab,
                    punchOrigin.position + randomOffset,
                    punchPrefab.transform.rotation
                );

                var rendererClone = punch.GetComponent<MeshRenderer>();
                var rendererPrefab = punchPrefab.GetComponent<MeshRenderer>();

                if (rendererClone && rendererPrefab)
                    rendererClone.sharedMaterial = rendererPrefab.sharedMaterial;

                Destroy(punch, punchLifetime);
            }

            yield return new WaitForSeconds(punchInterval);
            elapsedTime += punchInterval;
        }

        isAttacking = false;
    }
}
