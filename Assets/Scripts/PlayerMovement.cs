using System.Collections;
using System.Collections.Generic;
using Minifantasy;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool facingRight = true;
    private Vector2 movement = Vector2.zero;
    private Rigidbody2D rb;
    private Animator animator;

    public Canvas startScreen;
    public string animState = "Idle";
    public float moveSpeed = 500f;


    public SetAnimatorParameter setAnim;
    private bool isStarted = false;

    void Start()
    {
        // Initialize components
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        setAnim = GetComponent<SetAnimatorParameter>();
    }

    void Update()
    {
        // check if started
        if (Input.GetKeyDown(KeyCode.Return))
        {
            isStarted = true;
        }
        else if (isStarted)
        {
            startScreen.enabled = false;
            // Get input from player
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            // Set the movement vector to the user's input (xIn, yIn)
            movement = new Vector2(horizontal, vertical);
        }
    }

    void FixedUpdate()
    {
            // Necolai McIntosh - Stop player completely while attacking
            if (setAnim.parameterName != "Attack" && setAnim.parameterName != "ChargedAttack")
            {
                // Set the velocity to the normalized movement * speed * fixed delta time
                rb.velocity = movement.normalized * moveSpeed * Time.fixedDeltaTime;
            }

            // Flip the player based on their horizontal direction
            // Kevin - Fixed to face the correct direction
            if (facingRight && movement.x < 0)
                Flip();
            else if (!facingRight && movement.x > 0)
                Flip();

            /* If the player is moving any direction, set the walk animation,
                if not, then set the idle animation */
            // John - changed to use SAP instead of independent functions
            if (rb.velocity.magnitude != 0)
            {
                setAnim.TurnOffCurrentParameter();
                animState = "Walk";
                setAnim.ToggleAnimatorParameter(animState);
            }
            else if (rb.velocity.magnitude == 0)
            {
                setAnim.TurnOffCurrentParameter();
                animState = "Idle";
                setAnim.ToggleAnimatorParameter(animState);
            }
    }

    void Flip()
    {
        // Multiplies the local scale by -1 for flipping effect
        facingRight = !facingRight;
        Vector3 scale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        transform.localScale = scale;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);
    }
}
