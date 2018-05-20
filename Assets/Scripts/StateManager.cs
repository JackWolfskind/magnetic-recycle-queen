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
    public Canvas endGameCanvas,uiCanvas;
    public Image gameover;

    public Sprite catchSprite;

    public Sprite damageSprite;

    public AudioSource catchSound;


    private Sprite defaultSprite;
    private int healthBarMax;
    private int trashCounter;

    PlayerController pController;
    PointController points;

    void Start()
    {

        healthBarMax = 100;
        trashCounter = 0;
        defaultSprite = GetSprite();
        if (healthSlider != null)
            healthSlider.maxValue = healthBarMax;

        for (int i = 0; i < pSystem.Length; i++)
        {
            pSystem[i] = GetComponent<ParticleSystem>();
        }
      
        pController = GetComponent<PlayerController>();
        points = GetComponent<PointController>();
    }

    public void Damage(int dmgValue)
    {

        healthSlider.value -= dmgValue;
        SetSprite(damageSprite);
        
        Invoke("SetDefaultSprite", 0.5f);
        if (healthSlider.value <= 0)
        {
            //Game Over ausführen
            GameOver();     
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Projectial")
        {
            SetSprite(catchSprite);
            Invoke("SetDefaultSprite", 0.5f);
            catchSound.Play();
            Destroy(collision.gameObject);
            // Punkte erhöhen sich und Text wird geupdated
            points.currpoints++;
            points.TextUpdate();

            //Explosion wird abgespielt
            //pSystem[pController.lane].Play();
        }

        if (collision.tag == "BadProjectial")
        {
            Damage(20);
        }
    }

    void MenuLaden()
    {
        SceneManager.LoadScene(0);
    }

    private Sprite GetSprite()
    {
        return gameObject.GetComponentInChildren<SpriteRenderer>().sprite;
    }

    private void SetSprite(Sprite sprite)
    {
        gameObject.GetComponentInChildren<SpriteRenderer>().sprite = sprite;
    }

    private void SetDefaultSprite()
    {
        SetSprite(defaultSprite);
    }
    private void GameOver()
    {
        endGameCanvas.enabled = true;
        gameover.enabled = true;
        uiCanvas.enabled = false;
        Time.timeScale = 0;
    }
}
