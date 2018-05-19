﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemController : MonoBehaviour
{
    public GameObject[] goodProjectialArray;

    public GameObject[] badProjectialArray;

    public Transform projectialSpawnPoint;

    public Transform[] spawnpointArray;

    public AudioSource shootingSound;

    private Vector3 projectialDir,curr,tar;
    private int projectialSpeed;

    private bool isMoving;
    private float delta,factor;



    private float strifeDelta;
    void Start()
    {
        delta= 0.0f;
        factor = 1.0f;
        strifeDelta = 0.0f;
        projectialDir = new Vector3(-1, 0, 0);
        projectialSpeed = 20000;
        isMoving =false;
        transform.position = spawnpointArray[Random.Range(0, spawnpointArray.Length)].position;
        moveCharacter();
    }

    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime* factor;

        if (delta >= 1f && !isMoving)
        {
            if (Random.Range(0, 100) >= 40)
            {
                spawnProjectial();
                isMoving = true;
                
                delta = 0.0f;
                moveCharacter();
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

    private void moveCharacter()
    {
        curr = this.transform.position;
        tar = spawnpointArray[Random.Range(0, spawnpointArray.Length)].position;
    }

    private void spawnProjectial()
    {
        this.shootingSound.Play();
        GameObject projectial = this.getRandomProjecial();
        GameObject g = Instantiate(projectial, projectialSpawnPoint.position, Quaternion.identity);
        g.GetComponent<Rigidbody2D>().AddForce(projectialDir * projectialSpeed);
    }

    private GameObject getRandomProjecial()
    {
        int randIndex = 0;
        switch (Random.Range(0, 100)  >= 30)
        {
            case true:
                randIndex = Random.Range(0, goodProjectialArray.Length - 1);
                return goodProjectialArray[randIndex];
            default:
                randIndex = Random.Range(0, badProjectialArray.Length - 1);
                return badProjectialArray[randIndex];
        }
    }
}