﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemController : MonoBehaviour
{
    public GameObject[] goodProjectialArray;

    public GameObject[] badProjectialArray;

    public Transform projectialSpawnPoint;

    public Transform[] spawnpointArray;

    private Vector3 projectialDir;
    private int projectialSpeed;

    private bool isMoving;



    private float deltaCharacter;
    private int deltaProjectial;


    private float strifeDelta;
    void Start()
    {
        deltaCharacter = 0.0f;
        deltaProjectial = 0;
        strifeDelta = 0.0f;
        projectialDir = new Vector3(-1, 0, 0);
        projectialSpeed = 20000;
        isMoving = true;
        transform.position = spawnpointArray[Random.Range(0, spawnpointArray.Length)].position;
        moveCharacter();
    }

    // Update is called once per frame
    void Update()
    {
        deltaCharacter += Time.deltaTime;
        int spawnRate = 7;

        if (deltaCharacter >= 0.35f)
        {

            deltaProjectial += Random.Range(1, spawnRate);
            if (deltaProjectial % Random.Range(1, spawnRate) == 0)
            {
                spawnProjectial();
                deltaProjectial = 0;
            }
            moveCharacter();
            deltaCharacter = 0.0f;
        }
    }

    private void moveCharacter()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, spawnpointArray[Random.Range(0, spawnpointArray.Length)].position, deltaProjectial);
    }

    private void spawnProjectial()
    {
        GameObject projectial = this.getRandomProjecial();
        GameObject g = Instantiate(projectial, projectialSpawnPoint.position, Quaternion.identity);
        g.GetComponent<Rigidbody2D>().AddForce(projectialDir * projectialSpeed);
    }

    private GameObject getRandomProjecial()
    {
        int randIndex = 0;
        switch (Random.Range(0, 50) % 2 == 0)
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