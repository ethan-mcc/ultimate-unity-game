using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private RectTransform bar;
    private Image barImage;

    // Start is called before the first frame update
    void Start()
    {
        // Setting the health bar correctly - Aidan McClaughrey
        bar = GetComponent<RectTransform>();
        barImage = GetComponent<Image>();
        if (Health.totalHealth < 0.3f)
        {
            barImage.color = Color.red;
        }
        SetSize(Health.totalHealth);
    }
    // Update is called once per frame
    void Update()
    {

    }
    // Caculates the damage taken and applies it to the bar - Aidan McClaughrey
    public void Damage(float damage)
    {
        if ((Health.totalHealth -= damage) >= 0f)
        {
            Health.totalHealth -= damage;
        }
        else
        {
            Health.totalHealth = 0f;
        }

        if (Health.totalHealth < 0.3f)
        {
            barImage.color = Color.red;
        }

        SetSize(Health.totalHealth);
    }
    // Sets how much health the player has - Aidan McClaughrey
    public void SetSize(float size)
    {
        bar.localScale = new Vector3(size, 1f);
    }
}
