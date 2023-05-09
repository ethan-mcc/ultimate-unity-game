using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHits : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Destroys enemy objects when they hit the trigger - Jacob M.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
}
