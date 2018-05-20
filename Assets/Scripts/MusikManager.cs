using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusikManager : MonoBehaviour {

	public Slider lautstaerke;

	void Awake()
	{
		lautstaerke.value = PlayerPrefs.GetFloat("Volumen", 0.5f);
	}
	
	void Update () 
	{
		AudioListener.volume = lautstaerke.value;
		PlayerPrefs.SetFloat("Volumen", lautstaerke.value);
	}
}
