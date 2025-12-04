using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;
    private CharacterController characterController;

    private Vector3 lastPosition;
    private float speed;

    [Header("Configuração do Ataque")]
    public float attackDuration = 0.3f; 

    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        lastPosition = transform.position;
    }

    void Update()
    {
       
        Vector3 displacement = transform.position - lastPosition;
        speed = displacement.magnitude / Time.deltaTime;

        
        bool isMoving = speed > 0.1f;
        animator.SetBool("isMoving", isMoving);

        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetBool("attack", true);
            StartCoroutine(ResetAttack());
        }

        lastPosition = transform.position;
    }

    private IEnumerator ResetAttack()
    {
       
        yield return new WaitForSeconds(attackDuration);

        animator.SetBool("attack", false);
    }
}
