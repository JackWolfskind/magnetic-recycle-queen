using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateManager : MonoBehaviour
{
    private int healthBarMax;
    private int trashCounter;
    public Slider healthSlider;

    // Use this for initialization
    void Start ()
    {
        healthBarMax = 100;
        trashCounter = 0;
        if (healthSlider != null)
            healthSlider.maxValue = healthBarMax;
    }
    public void damage(int dmgValue)
    {
        healthSlider.value -= dmgValue;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Projectial")
        {
            Destroy(collision.gameObject);
        }
    }
}
