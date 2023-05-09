using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlTp : MonoBehaviour
{
    public GameObject tp;
    public PlayerAttack pa;
    // Start is called before the first frame update
    void Start()
    {
        tp.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //sets the teleporter on when 2 enemies are killed
        if(pa.enemDestroy == 2)
        {
            tp.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && pa.enemDestroy == 2)
        {
            SceneManager.LoadScene("Development");
        }
    }
}
