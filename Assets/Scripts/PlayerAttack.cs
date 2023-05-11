using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Minifantasy;
using TMPro;

public class PlayerAttack : MonoBehaviour
{
    // John Ixcoy
    private SetAnimatorParameter setAnim;
    private Rigidbody2D rb;

    public GameObject attackHitbox;
    public int enemDestroy;
    private bool isStart = false;
    //Kaden Blanch
    //TODO: FIX SCORE TEXT
    /*update player score in ui
    public TextMeshProUGUI ScoreText;
    public int score;
    */

    private void Start()
    {
        setAnim = gameObject.GetComponent<SetAnimatorParameter>();
        rb = gameObject.GetComponent<Rigidbody2D>();

        //score ui
        //score = 0;
        //TODO: FIX SCORE TEXT
        //ScoreText.text
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            isStart = true;
        }
        // Necolai McIntosh - The player does not need to stop moving in order to attack
        // (Note: I did not write the code below, I just removed the condition that
        //  prevents the player from initiating an attack while moving)
        if (Input.GetKey(KeyCode.LeftShift) && isStart)
        {
            ChargedAttack();
        }
        else if (Input.GetKey(KeyCode.Space) && isStart)
        {
            Attack();
        }
    }

    void Attack()
    {
        // Stop player completely and perform attack animation
        setAnim.TurnOffCurrentParameter();
        rb.velocity = Vector2.zero;
        setAnim.ToggleAnimatorParameter("Attack");

        // Activates hitbox that destroys enemies
        Invoke("attackHitboxActive", .2f);
    }
    void ChargedAttack()
    {
        // Stop player completely and perform charged attack animation
        setAnim.TurnOffCurrentParameter();
        rb.velocity = Vector2.zero;
        setAnim.ToggleAnimatorParameter("ChargedAttack");

        // Activates hitbox that destroys enemies
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
