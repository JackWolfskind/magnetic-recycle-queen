using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour
{
    public Slider healthSlider;
    public ParticleSystem[] pSystem;
    public GameObject panelGameOver;
    
    private int healthBarMax;
    private int trashCounter;

    PlayerController pController;
    PointController points;

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
        points = GetComponent<PointController>();
    }

    public void damage(int dmgValue)
    {
        healthSlider.value -= dmgValue;

        if(healthSlider.value <= 0)
        {
            //Game Over ausführen
            panelGameOver.SetActive(true);
            //Hauptmenü laden nach 2 Sekunden
            Invoke("MenuLaden", 2f);
            

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Projectial")
        {
            Destroy(collision.gameObject);
            // Punkte erhöhen sich und Text wird geupdated
            points.currpoints ++;
            points.TextUpdate();

            //Explosion wird abgespielt
            //pSystem[pController.lane].Play();
        }

        if(collision.tag == "BadProjectial")
        {
            Destroy(collision.gameObject);
            damage(20);
        }
    }

    void MenuLaden()
    {
        SceneManager.LoadScene(0);
    }
}
