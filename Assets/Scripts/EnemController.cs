﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemController : MonoBehaviour
{
    public Options options;

    public GameObject[] goodProjectialArray;

    public GameObject[] badProjectialArray;

    public Transform projectialSpawnPoint;

    public Transform[] spawnpointArray;

    public AudioSource shootingSound;

    public Sprite shootingSprite;

    public Sprite shootSprite;

    private float Speed;

    private Sprite defaultSprite;

    private Vector3 projectialDir, curr, tar;
    private int projectialSpeed;

    private bool isMoving;

    private float delta,shootigCount,swapSpeed,spawnChance;




    private float strifeDelta;
    void Start()
    {
        swapSpeed = 0.5f;
        spawnChance = 30;
        delta = 0.0f;  
        strifeDelta = 0.0f;
        projectialDir = new Vector3(-1, 0, 0);
        projectialSpeed = 15000;
        isMoving = false;
        shootigCount = 0.5f;
        transform.position = spawnpointArray[Random.Range(0, spawnpointArray.Length)].position;
        defaultSprite = GetSprite();
        MoveCharacter();
    }

    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime* swapSpeed;

        if (delta >= options.speed && !isMoving)
        {
            if (Random.Range(0, 100) >= 40)
            {
                SpawnProjectial();
                isMoving = true;
                
                delta = 0.0f;
                MoveCharacter();
            }

        }
        else if (isMoving)
        {

            this.transform.position = Vector3.Lerp(curr,tar, delta);
            if (delta >= 1f)
            {
                delta = 0.0f;
                isMoving = false;

            }
                
        }
            
    }

    private void MoveCharacter()
    {
        curr = this.transform.position;
        tar = spawnpointArray[Random.Range(0, spawnpointArray.Length)].position;
    }

    private void SpawnProjectial()
    {
        SetSprite(shootingSprite);
        this.shootingSound.Play();
        GameObject projectial = this.GetRandomProjecial();
        GameObject g = Instantiate(projectial, projectialSpawnPoint.position, Quaternion.identity);
        g.GetComponent<Rigidbody2D>().AddForce(projectialDir * projectialSpeed);
        Invoke("SetDefaultSprite", 0.4f);
    }

    private void SetDefaultSprite()
    {
        SetSprite(defaultSprite);
    }

    private GameObject GetRandomProjecial()
    {
        int randIndex = 0;
        
        switch (Random.Range(0, 100) >= spawnChance)
        {
            case true:
                randIndex = Random.Range(0, goodProjectialArray.Length - 1);
                return goodProjectialArray[randIndex];
            default:
                randIndex = Random.Range(0, badProjectialArray.Length - 1);
                return badProjectialArray[randIndex];
        }
    }

    private void SetShootSprite()
    {

    }

    private void RemoveShootSprite()
    {
        
    }

    private Sprite GetSprite()
    {
        return gameObject.GetComponentInChildren<SpriteRenderer>().sprite;
    }

     private void SetSprite(Sprite sprite)
    {
        gameObject.GetComponentInChildren<SpriteRenderer>().sprite = sprite;
    }
    public void IncSpeed()
    {
        projectialSpeed += 2000;
        swapSpeed += .25f;

        spawnChance -= 5;

        if(spawnChance <= 15)
            spawnChance = 15;
    }
}