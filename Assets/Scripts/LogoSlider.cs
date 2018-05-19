using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoSlider : MonoBehaviour {

	public GameObject logo;
	public int logoSpeed;

	private Vector2 currentPos;
	private Vector2 targetPos;

	void Start()
	{
		currentPos = transform.position;
	}
	
	void Update () 
	{
		//Bewege Logo zu Endposition
		transform.position = Vector2.Lerp(transform.position, targetPos, Time.deltaTime * logoSpeed);
		//Spiele Sound ab
		//Zeige Startbutton an
	}
}
