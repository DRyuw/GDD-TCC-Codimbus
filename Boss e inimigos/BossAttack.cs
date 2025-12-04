using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public float Speed = 5f;        
    public float Timer = 3f;        

    private Rigidbody aneisRb;
    private GameObject Nebus;

    void Start()
    {
        aneisRb = GetComponent<Rigidbody>();
        Nebus = GameObject.Find("nebus");

        Destroy(gameObject, Timer);

        if (Nebus != null)
        {
            Vector3 direction = (Nebus.transform.position - transform.position).normalized;
            aneisRb.AddForce(direction * Speed, ForceMode.Impulse);

            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(direction);
            }
        }
        else
        {
            Debug.LogWarning("Objeto 'Nebus' não encontrado na cena!");
        }
    }

  
}
