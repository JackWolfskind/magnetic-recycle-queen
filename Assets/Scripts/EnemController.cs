using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemController : MonoBehaviour
{
    public GameObject[] projectialArray;
    public Transform[] spawnpointArray;

    private Vector3 projectialDir;
    private int projectialSpeed;

    private bool moveCharacter;


    private float deltaCharacter;
    private float deltaProjectial;
    void Start()
    {
        deltaCharacter = 0.0f;
        deltaProjectial = 0.0f;
        projectialDir = new Vector3(-1, 0, 0);
        projectialSpeed = 20000;
        moveCharacter = true;
        spawnCharacter();
    }

    // Update is called once per frame
    void Update()
    {
        deltaCharacter += Time.deltaTime;
        deltaProjectial += Time.deltaTime;

        if (deltaCharacter >= 0.5) 
        {
            deltaCharacter = 0.0f;
            spawnCharacter();
        }
        if (deltaProjectial >= 1)
        {
            deltaProjectial = 0.0f;
            if (deltaProjectial % Random.Range(1, 4) == 0)
            {
                spawnProjectial();
            }
        }

    }

    private void spawnCharacter(){
        transform.position = spawnpointArray[Random.Range(0, spawnpointArray.Length)].position;
    }

    private void spawnProjectial()
    {
        GameObject g = Instantiate(projectialArray[0], transform.position, Quaternion.identity);
        g.GetComponent<Rigidbody2D>().AddForce(projectialDir * projectialSpeed);
    }
}
