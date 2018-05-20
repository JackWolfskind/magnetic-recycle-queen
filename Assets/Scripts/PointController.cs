using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointController : MonoBehaviour {

	public int currpoints = 0;

	public Text txtPoints;
    public Text endScreenText;

	public void TextUpdate () 
	{      
        txtPoints.text = endScreenText.text = currpoints.ToString() + " Punkte";
	}
}
