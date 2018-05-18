using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgHandler : MonoBehaviour {

    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
         if(collision.tag == "Projectial")
        {
            Debug.Log("triggert");
            Destroy(collision.gameObject);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
       
    }
}
