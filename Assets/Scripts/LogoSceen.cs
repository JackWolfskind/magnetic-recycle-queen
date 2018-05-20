using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoSceen : MonoBehaviour {

	float timer = 1;

	void Update () 
	{
		timer = timer - Time.deltaTime;

		if(timer <= 0)
			SceneManager.LoadScene(1);
	}
}
