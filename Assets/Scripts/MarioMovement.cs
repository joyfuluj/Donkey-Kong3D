using UnityEngine;

public class MarioMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed = 5f;  // Speed for moving left and right
    public float jumpForce = 5f;  // Force applied when jumping
    private bool isGrounded;      // Check if Mario is on the ground
    private Vector3 originalPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();  // Get the Rigidbody component
        //store Mario's original position
        originalPosition= gameObject.transform.position;
    }

    void Update()
    {
        // Horizontal movement using InputManager
        float moveDirection = 0f;
        if (InputManager.Instance.GetLeftPressed())
        {
            moveDirection = -1f;  // Move left
        }
        else if (InputManager.Instance.GetRightPressed())
        {
            moveDirection = 1f;   // Move right
        }

        Vector3 movement = new Vector3(moveDirection * moveSpeed, rb.linearVelocity.y, 0);  // Move along X-axis only
        rb.linearVelocity = movement;  // Apply velocity directly

        // Jumping using InputManager
        if (InputManager.Instance.GetJumpPressed() && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);  // Jump upward
            isGrounded = false;  // Prevent double jumping
        }
    }

    // Detect if Mario is grounded
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")||collision.gameObject.CompareTag("GroundOne"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")||collision.gameObject.CompareTag("GroundOne"))
        {
            isGrounded = false;
        }
    }

    public void ResetPosition(){
        gameObject.transform.position=originalPosition;
    }
}