using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	public GameObject credits;


	public void StartGame()
	{
		SceneManager.LoadScene(1);
	}

	public void OpenCredits()
	{
		if(!credits.active)
		{
			credits.SetActive(true);
		}
		else
		{
			credits.SetActive(false);
		}
		
	}
}
