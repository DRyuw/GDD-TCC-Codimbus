using System.Collections;
using UnityEngine;

public class PedraCai : MonoBehaviour
{
    private Vector3 startPosition;
    private Rigidbody rb;

    public float intervaloQueda = 10f;
    public float tempoNoChao = 3f;

    public float minX = -5f; 
    public float maxX = 5f;

    [Header("Partículas de Aviso")]
    public ParticleSystem avisoParticulas; 
    public float tempoAviso = 1.5f;        

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogError("Rigidbody não encontrado na pedra!");
            return;
        }

        startPosition = transform.position;

       
        rb.useGravity = false;
        rb.linearVelocity = Vector3.zero;
        rb.isKinematic = true;

        if (avisoParticulas != null)
            avisoParticulas.Stop();

        StartCoroutine(CicloDeQueda());
    }

    IEnumerator CicloDeQueda()
    {
        while (true)
        {
            yield return new WaitForSeconds(intervaloQueda);

            
            float randomX = Random.Range(minX, maxX);
            transform.position = new Vector3(randomX, startPosition.y, startPosition.z);

            
            if (avisoParticulas != null)
            {
                avisoParticulas.Play();
            }

            
            yield return new WaitForSeconds(tempoAviso);

            
            if (avisoParticulas != null)
                avisoParticulas.Stop();

            rb.isKinematic = false;
            rb.useGravity = true;
            rb.AddForce(Vector3.down * 200f, ForceMode.Acceleration);

            yield return new WaitForSeconds(tempoNoChao);

            
            rb.useGravity = false;
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true;

            
            transform.position = new Vector3(randomX, startPosition.y, startPosition.z);
            transform.rotation = Quaternion.identity;
        }
    }
}