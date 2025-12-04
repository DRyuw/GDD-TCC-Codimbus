using UnityEngine;

public class LightningHitbox : MonoBehaviour
{
    [HideInInspector] public float lifeTime = 0.5f;
    [HideInInspector] public LayerMask layersToHit;

    private void OnTriggerEnter(Collider other)
    {
        
        if (((1 << other.gameObject.layer) & layersToHit) != 0)
        {
            Debug.Log($"{other.name} foi atingido pelo raio!");
            
        }
    }
}
