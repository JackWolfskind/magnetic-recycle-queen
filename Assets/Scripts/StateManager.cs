using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateManager : MonoBehaviour
{
    public Slider healthSlider;
    public ParticleSystem[] pSystem;
    
    private int healthBarMax;
    private int trashCounter;

    PlayerController pController;

    void Start ()
    {
        healthBarMax = 100;
        trashCounter = 0;
        if (healthSlider != null)
            healthSlider.maxValue = healthBarMax;

        for(int i = 0; i < pSystem.Length; i++)
        {
            pSystem[i] = GetComponent<ParticleSystem>();
        }

        pController = GetComponent<PlayerController>();
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

            //Explosion wird abgespielt
            pSystem[pController.lane].Play();
        }
    }
}
