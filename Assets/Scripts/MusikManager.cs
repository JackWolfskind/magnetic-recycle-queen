using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusikManager : MonoBehaviour {

	public Slider lautstaerke;

	void Start()
	{
		AudioListener.volume = PlayerPrefs.GetFloat("Volumen");
	}
	
	void Update () 
	{
		AudioListener.volume = lautstaerke.value;
		PlayerPrefs.SetFloat("Volumen", AudioListener.volume);
	}
}
