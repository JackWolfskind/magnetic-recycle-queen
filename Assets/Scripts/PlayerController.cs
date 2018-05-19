using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	public Transform[] lanePoint;
    [Range(0,1)]
    private float delta;
    private bool onMove;
    private Vector3 currentPos;
    private Vector3 targetPos;

    // Use this for initialization
    void Start () 
	{
        int startLane = Random.Range(0,lanePoint.Length);
        transform.position = lanePoint[startLane].position;
        delta = 0.0f;
        onMove = false;
        
	}
	
	// Update is called once per frame
	void Update() 
	{
            if (!onMove)
                GetInput();
            else
            {
               delta += Time.deltaTime*6;
               this.transform.position = Vector3.Lerp(currentPos, targetPos, delta);
                Debug.Log(delta);
                if(delta >= 1)
                {
                    onMove = false;
                    delta = 0.0f;
                }

            }
        
    }

    void GetInput()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            targetPos = lanePoint[0].position;
            currentPos = this.transform.position;
            onMove = true;
        }
            

		if(Input.GetKeyDown(KeyCode.W))
        {
            targetPos = lanePoint[1].position;
            currentPos = this.transform.position;
            onMove = true;
        }
            

		if(Input.GetKeyDown(KeyCode.E))
        {
            targetPos = lanePoint[2].position;
            currentPos = this.transform.position;
            onMove = true;
        }
            
    }
}
