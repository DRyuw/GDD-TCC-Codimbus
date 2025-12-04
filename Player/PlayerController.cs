using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;
    private Animator anim;

    private Vector3 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
        float moveX = Input.GetAxisRaw("Horizontal");
        moveInput = new Vector3(moveX, 0f, 0f);

       
        bool isMoving = Mathf.Abs(moveX) > 0.1f;
        anim.SetBool("isMoving", isMoving);

        
        if (moveX > 0)
            transform.rotation = Quaternion.Euler(0f, 180f, 0f); 
        else if (moveX < 0)
            transform.rotation = Quaternion.Euler(0f, 0f, 0f); 
    }

    void FixedUpdate()
    {
        
        rb.linearVelocity = moveInput * speed + new Vector3(0, rb.linearVelocity.y, 0);
    }
}
