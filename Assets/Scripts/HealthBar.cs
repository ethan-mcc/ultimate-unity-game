using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private RectTransform bar;
    private Image barImage;
    // a reference to the health bar - Thaddeus Reimer
    public Health health;

    // Start is called before the first frame update
    void Start()
    {
        // Setting the health bar correctly - Aidan McClaughrey
        bar = GetComponent<RectTransform>();
        barImage = GetComponent<Image>();
        if (health.totalHealth < 0.3f)
        {
            barImage.color = Color.red;
        }
        SetSize();
    }
    // Update is called once per frame
    void Update()
    {

    }
    // Caculates the damage taken and applies it to the bar - Aidan McClaughrey
    public void Damage(float damage)
    {
        if ((health.totalHealth - damage) > 0f)
        {
            health.totalHealth -= damage;
        }
        else
        {
            // game should quit when health is 0, doesn't work in editor for some reason - Thaddeus Reimer
            Debug.Log("dead");
            health.totalHealth = 0f;
            Application.Quit();
        }

        if (health.totalHealth < 0.3f)
        {
            barImage.color = Color.red;
        }

        Debug.Log(health.totalHealth);

        SetSize();
    }
    // Sets how much health the player has - Aidan McClaughrey
    public void SetSize()
    {
        bar.sizeDelta = new Vector2(90 * health.totalHealth, bar.sizeDelta.y);
    }
}
