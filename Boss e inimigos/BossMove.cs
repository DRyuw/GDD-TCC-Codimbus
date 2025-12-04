using UnityEngine;
using System.Collections;

public class BossMove : MonoBehaviour
{
    private float speed = 50f;
    private float moveDelay = 10f;
    private Rigidbody PolvoRb;

    private enum State { MovingToOtherSide, ReturningToOriginal }
    private State currentState = State.MovingToOtherSide;

    private Vector3 targetPosition;
    private Vector3 originalPosition;

    private Renderer bossRenderer;
    private Color originalColor;
    public Color dashColor = Color.red;

    void Start()
    {
        PolvoRb = GetComponent<Rigidbody>();
        bossRenderer = GetComponent<Renderer>();

        originalColor = bossRenderer.material.color;

        originalPosition = transform.position;
        targetPosition = new Vector3(originalPosition.x, originalPosition.y, originalPosition.z);

        StartCoroutine(MovementCycle());
    }

    void FixedUpdate()
    {
        Vector3 destination = Vector3.zero;

        switch (currentState)
        {
            case State.MovingToOtherSide:
                destination = targetPosition;
                break;
            case State.ReturningToOriginal:
                destination = originalPosition;
                break;
        }

        Vector3 direction = (destination - transform.position).normalized;

        PolvoRb.linearVelocity = direction * speed;
    }

    IEnumerator MovementCycle()
    {
        while (true)
        {
            bossRenderer.material.color = dashColor;
            yield return new WaitForSeconds(0.5f);

            currentState = State.MovingToOtherSide;
            targetPosition = new Vector3(-transform.position.x, transform.position.y, transform.position.z);

            yield return StartCoroutine(WaitUntilClose(targetPosition, 0.5f));

            bossRenderer.material.color = originalColor;
            
            currentState = State.ReturningToOriginal;
            yield return StartCoroutine(WaitUntilClose(originalPosition, 0.5f));

            yield return new WaitForSeconds(moveDelay);
        }
    }

    IEnumerator WaitUntilClose(Vector3 position, float threshold)
    {
        while (Vector3.Distance(transform.position, position) > threshold)
        {
            yield return null;
        }
    }
}