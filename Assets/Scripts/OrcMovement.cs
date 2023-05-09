using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcMovement : MonoBehaviour
{
    private bool facingRight = true;
    private bool waiting = false;
    private Vector2 movement = Vector2.zero;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 startPos;
    public Vector2 targetPos;

    public float moveSpeed = 300f;
    public float wanderRange = 3f;

    void Start()
    {
        // Initialize components
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();

        startPos = transform.position;
        targetPos = GetNewWanderPosition(startPos);
    }

    void Update()
    {
        // Get input from player
        float horizontal = targetPos.x - transform.position.x;
        float vertical = targetPos.y - transform.position.y;

        // Set the movement vector to the direction to the wander point
        movement = new Vector2(horizontal, vertical);
    }

    void FixedUpdate()
    {
        // Set the velocity to the normalized movement * speed * fixed delta time
        if (!waiting)
        {
            rb.velocity = movement.normalized * moveSpeed * Time.fixedDeltaTime;

            // If destination reached, find new destination
            if (movement.magnitude < 0.1)
            {
                rb.velocity = Vector2.zero;
                waiting = true;
                StartCoroutine(WaitThenGetNewWanderPosition(3));
            }
        }

        // Flip the orc based on their horizontal direction
        if (facingRight && movement.x < 0)
            Flip();
        else if (!facingRight && movement.x > 0)
            Flip();
    }

    void Flip()
    {
        // Multiplies the local scale by -1 for flipping effect
        facingRight = !facingRight;
        Vector3 scale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        transform.localScale = scale;
    }

    private Vector2 GetNewWanderPosition(Vector2 center)
    {
        float newPosX = Random.Range(center.x - wanderRange, center.x + wanderRange);
        float newPosY = Random.Range(center.y - wanderRange, center.y + wanderRange);

        return new Vector2(newPosX, newPosY);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);
    }

    IEnumerator WaitThenGetNewWanderPosition(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        targetPos = GetNewWanderPosition(startPos);

        waiting = false;
    }
}
