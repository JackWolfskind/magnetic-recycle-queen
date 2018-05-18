using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgHandler : MonoBehaviour {

    public GameObject player;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "projectial")
        {
            Destroy(other.gameObject);
        }
    }
}
