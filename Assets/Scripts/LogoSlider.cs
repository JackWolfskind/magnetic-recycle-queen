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
		currentPos = new Vector2(0f, 9f);
		targetPos = new Vector2(0f, 2.7f);
	}
	
	void Update () 
	{
		//Bewege Logo zu Endposition
		transform.position = Vector2.Lerp(currentPos, targetPos, Time.deltaTime * logoSpeed);
		//Spiele Sound ab
		//Zeige Startbutton an
	}
}
