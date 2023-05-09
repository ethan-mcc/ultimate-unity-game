using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Minifantasy;

public class PlayerAttack : MonoBehaviour
{
    // John Ixcoy
    private SetAnimatorParameter setAnim;
    private Rigidbody2D rb;

    public GameObject attackHitbox;
    public int enemDestroy;

    private void Start()
    {
        setAnim = gameObject.GetComponent<SetAnimatorParameter>();
        rb = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude == 0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                ChargedAttack();
            }
            else if (Input.GetKey(KeyCode.Space))
            {
                Attack();
            }
            
        }
    }

    void Attack()
    {
        // Stop player completely and perform attack animation
        setAnim.TurnOffCurrentParameter();
        rb.velocity = new Vector2(0, 0);
        setAnim.ToggleAnimatorParameter("Attack");

        // Activates hitbox that destroys enemies
        Invoke("attackHitboxActive", .2f);
    }
    void ChargedAttack()
    {
        // Stop player completely and perform charged attack animation
        setAnim.TurnOffCurrentParameter();
        rb.velocity = new Vector2(0, 0);
        setAnim.ToggleAnimatorParameter("ChargedAttack");

        Invoke("attackHitboxActive", 1.5f);

    }



    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            Destroy(col.gameObject);
            enemDestroy++;
        }
    }

    // Makes attack hitbox active and deactivates when not holding space - Jacob M.
    private void attackHitboxActive()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.LeftShift))
        {
            attackHitbox.SetActive(true);
        }
        else
        {
            attackHitbox.SetActive(false);
            CancelInvoke();
        }

    }
}