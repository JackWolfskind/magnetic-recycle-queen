using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	public Transform[] lanePoint;


	// Use this for initialization
	void Start () 
	{
		int startLane = Random.Range(0,3);
		transform.position = lanePoint[startLane].position;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
        GetInput();
    }

    void GetInput()
    {
        if(Input.GetKey(KeyCode.Q))
		transform.position = lanePoint[0].position;

		if(Input.GetKeyDown(KeyCode.W))
		transform.position = lanePoint[1].position;

		if(Input.GetKeyDown(KeyCode.E))
		transform.position = lanePoint[2].position; 
    }
    private void OnTriggerEnter(Collider other)
    {
            if (other.tag == "projectial")
            {
                Destroy(other.gameObject);
            }
    }
}
