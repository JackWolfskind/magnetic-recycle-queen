using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoSlider : MonoBehaviour {

	public GameObject logo;
	public GameObject btnStartGame;
	public float logoSpeed;
	public AudioSource audioLogo;

	private Vector3 currentPos;
	private Vector3 targetPos;

	void Start()
	{
		targetPos = new Vector3(0f, 2.7f, 0f);
	}
	
	void Update () 
	{
		//Bewege Logo zu Endposition
		if(transform.position != targetPos)
		{
			transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * logoSpeed);
		}
		else
		{
			//Spiele Sound ab

			//Zeige Startbutton an
			btnStartGame.SetActive(true);
		}
		
		
	}
}
