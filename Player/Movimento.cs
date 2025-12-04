using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController controller;
    private Collider[] colliders;

    [Header("Movimento")]
    public float moveSpeed = 15f;

    [Header("Dash")]
    public float dashSpeed = 40f;
    public float dashTime = 0.25f; 
    public float dashCooldown = 1f;

    public bool isDashing = false;
    private bool canDash = true;
    private Vector3 dashDirection;
    private float dashTimer = 0f;
    private float cooldownTimer = 0f;

    
    public bool isInvulnerable = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        colliders = GetComponents<Collider>();
    }

    public void TakeDamage(float dmg)
    {
        if (isInvulnerable)
        {
            Debug.Log("Dano ignorado (invulnerável no dash)");
            return;
        }

        Debug.Log("Player levou dano: " + dmg);
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 move = new Vector3(horizontal, vertical, 0).normalized;

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && move != Vector3.zero)
        {
            isDashing = true;
            canDash = false;
            isInvulnerable = true; 
            dashDirection = move;
            dashTimer = dashTime;

            foreach (var col in colliders)
            {
                if (!(col is CharacterController))
                    col.enabled = false;
            }
        }

        if (isDashing)
        {
            controller.Move(dashDirection * dashSpeed * Time.deltaTime);
            dashTimer -= Time.deltaTime;

            if (dashTimer <= 0f)
            {
                isDashing = false;
                cooldownTimer = dashCooldown;
                isInvulnerable = false; 

                foreach (var col in colliders)
                {
                    if (!(col is CharacterController))
                        col.enabled = true;
                }
            }
        }
        else
        {
            controller.Move(move * moveSpeed * Time.deltaTime);

            if (!canDash)
            {
                cooldownTimer -= Time.deltaTime;
                if (cooldownTimer <= 0f)
                    canDash = true;
            }
        }
    }
}
