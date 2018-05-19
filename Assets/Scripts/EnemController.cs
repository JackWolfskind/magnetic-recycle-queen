using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemController : MonoBehaviour
{
    public GameObject[] projectialArray;
    public Transform[] spawnpointArray;

    private Vector3 projectialDir;
    private int projectialSpeed;


    private float delta;
    void Start()
    {
        delta = 0.0f;
        projectialDir = new Vector3(-1, 0, 0);
        projectialSpeed = 20000;
    }

    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime;
       
        if (delta >= 2)
        {
            delta = 0.0f;
            spawnProjectial();
        }

    }

    private void spawnProjectial()
    {
       
        GameObject g = Instantiate(projectialArray[0], spawnpointArray[Random.Range(0, spawnpointArray.Length)]);
        g.GetComponent<Rigidbody2D>().AddForce(projectialDir * projectialSpeed);
    }
}
