using UnityEngine;
using System.Collections;

public class DashCamarao : MonoBehaviour
{
    [Header("Configurações")]
    public float dashSpeed = 30f;
    public float dashDuration = 0.25f;
    public float delayBetweenDashes = 0.4f;

    public Transform leftPoint;
    public Transform rightPoint;

    private Rigidbody rb;
    private bool isDashing = false;      
    private Coroutine dashCoroutine = null;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("DashCamarao: Rigidbody não encontrado no GameObject.");
            enabled = false;
            return;
        }

        if (leftPoint == null || rightPoint == null)
        {
            Debug.LogError("DashCamarao: leftPoint ou rightPoint não atribuídos.");
            enabled = false;
            return;
        }

        transform.position = rightPoint.position;
        
        dashCoroutine = StartCoroutine(DashLoop());
    }

   
    public void StartDash()
    {
        if (dashCoroutine == null)
        {
            dashCoroutine = StartCoroutine(DashLoop());
        }
    }

    
    public void StopDash()
    {
        if (dashCoroutine != null)
        {
            StopCoroutine(dashCoroutine);
            dashCoroutine = null;
            rb.linearVelocity = Vector3.zero;
            isDashing = false;
        }
    }

    private IEnumerator DashLoop()
    {
        
        while (true)
        {
           
            isDashing = true;
            Vector3 dashDir = (leftPoint.position - transform.position).normalized;
            rb.linearVelocity = dashDir * dashSpeed;
            yield return new WaitForSeconds(dashDuration);

            rb.linearVelocity = Vector3.zero;
            isDashing = false;

            yield return new WaitForSeconds(delayBetweenDashes);

           
            isDashing = true;
            dashDir = (rightPoint.position - transform.position).normalized;
            rb.linearVelocity = dashDir * dashSpeed;
            yield return new WaitForSeconds(dashDuration);

            rb.linearVelocity = Vector3.zero;
            isDashing = false;

           
            yield return new WaitForSeconds(15f);
        }
    }
}
