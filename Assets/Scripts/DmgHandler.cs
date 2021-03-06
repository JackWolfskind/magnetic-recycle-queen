﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgHandler : MonoBehaviour {

    public GameObject player;
    private StateManager state;
    private int dmgValue;

    private void Start()
    {
        dmgValue = 10;
        state = player.GetComponent<StateManager>();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
         if(collision.tag == "Projectial")
        {
            Destroy(collision.gameObject);
            state.Damage(dmgValue);
        }
        else
        {
            Destroy(collision.gameObject);
        }

    }
}
