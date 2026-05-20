using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    //walking
    private float horizontalInput;
    public float currentSpeed;
    public float maxWalkSpeed;
    public float accelerationRate;
    public Rigidbody2D rb;
    
    //technical
    public GameObject player;
    public LayerMask whatIsGround; 
    public bool grounded;
    public bool isRunningCoroutine = false;
    public float playerHeight = 0.7f;
    

    //jumps
    public float jumpForce;
    public float CoyoteTime = 0.2f; // Time allowed to jump after

    void Start()
    {
        horizontalInput = 0f;
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        MoveInputs();
    }

    void LateUpdate()
    {
        // Cast downward to determine whether the player is grounded.
        if (Physics2D.Raycast(player.transform.position, new Vector2(0, -1), playerHeight, whatIsGround))
        {
            grounded = true;
        }
        else if (!isRunningCoroutine)
        {
            // Start coyote time if the player has just left the ground.
            StartCoroutine(CoyoteJump());
            isRunningCoroutine = true;
        }
    }

    public void MoveInputs()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                Jump();
            }
        }

        horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput != 0)
        {
            if (currentSpeed < 1f) currentSpeed = 1f;
            currentSpeed += accelerationRate * Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, 0, maxWalkSpeed);
        }
        else
        {
            if (currentSpeed > 0f)
            {
                currentSpeed -= ( 3f * currentSpeed + 2f ) * Time.deltaTime; // slows player when not moving
            }
            else if (currentSpeed < 0.1f)
            {
                currentSpeed = 0f; // Prevents speed from being negative
            }
        }
        transform.Translate(Vector2.right * horizontalInput * currentSpeed * Time.deltaTime);
    }

    private void Jump()
    {
        // Reset vertical velocity before jumping for consistent height.
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }
    
    IEnumerator CoyoteJump()
    {
        yield return new WaitForSeconds(CoyoteTime);
        grounded = false;
        isRunningCoroutine = false;
    }

    public void Moving()
    {
        rb.velocity = new Vector2(rb.velocity.x + currentSpeed * 10f, rb.velocity.y);
    }





}
