using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BossMultiPunch : MonoBehaviour
{
    [Header("Punch Settings")]
    public GameObject punchPrefab;              
    public List<Transform> punchPoints;         
    public float timeBetweenPunches = 1f;       
    public float punchSpeed = 20f;              
    public float punchLifetime = 0.5f;          

    
    public void StartPunchSequence()
    {
        StartCoroutine(DoPunchSequence());
    }

    private IEnumerator DoPunchSequence()
    {
        foreach (Transform point in punchPoints)
        {
            SpawnPunch(point);
            yield return new WaitForSeconds(timeBetweenPunches);
        }
    }

    private void SpawnPunch(Transform point)
    {
        GameObject punch = Instantiate(punchPrefab, point.position, point.rotation);
        Rigidbody rb = punch.GetComponent<Rigidbody>();

        if (rb != null)
        {
            
            Vector3 direction = -point.right;
            rb.linearVelocity = direction * punchSpeed;
        }

        Destroy(punch, punchLifetime);
    }
}
