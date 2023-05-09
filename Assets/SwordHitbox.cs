using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitbox : MonoBehaviour
{
    // Functions used by events in player animations - John
    public GameObject swordHB;
    
    public void SwordHBEnabled()
    {
        swordHB.SetActive(true);
    }

    public void SwordHBDisabled()
    {
        swordHB.SetActive(false);
    }
}
