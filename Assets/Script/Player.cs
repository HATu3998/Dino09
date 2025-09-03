using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float jumpForce = 15f;
    private Rigidbody2D rb;
    private bool isGround;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] LayerMask groundLayer;
    private Animator anim;
    [SerializeField] private BoxCollider2D normalCollider;
    [SerializeField] private CapsuleCollider2D duckCollider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        normalCollider.enabled = true;
        duckCollider.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        isGround = CheckIfGrounded();
        HandleJump();
        HandleDuck(); 
    }
    private bool CheckIfGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
    private void HandleJump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rb.linearVelocity = Vector2.up * jumpForce;
        }
    }
    private void HandleDuck()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            normalCollider.enabled = false;
            duckCollider.enabled = true;
            anim.SetBool("isDuck", true);
        }else if (Input.GetKeyUp(KeyCode.S))
        {
            normalCollider.enabled = true;
            duckCollider.enabled = false;
            anim.SetBool("isDuck", false);
        }
    }
}
