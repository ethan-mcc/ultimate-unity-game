using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public string direction;
    public GameObject room;
    public GameObject player;
    public GameObject cam;
    public GameObject teleportLocation;

    public void SetCameraPos(GameObject pos)
    {
        cam.transform.position = pos.transform.position;
    }

    public Vector3 ApplyDirection()
    {
        Vector2 value = Vector2.zero;
        
        switch (direction)
        {
            case "left": 
                value = new Vector2(-1.5f, 0); 
                break;

            case "right":
                value = new Vector2(1.5f, 0);
                break;

            default:
                value = new Vector3(0, 0, 0);
                break;
        }

        return value;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Human")
        {
            player.transform.position = teleportLocation.transform.position + ApplyDirection();
            SetCameraPos(room);
        }
    }
}
