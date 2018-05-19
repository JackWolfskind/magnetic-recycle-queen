using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBoom : MonoBehaviour {

	// Use this for initialization
	public GameObject Character;
	public Sprite BoomSprite;


	void Start () {

	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D collision) {
		if(collision.tag == "Player")
		{
			Debug.Log("Triggerd");
			gameObject.GetComponent<SpriteRenderer>().sprite = BoomSprite;
			Invoke("Destroy", 0.2f);
		}
	}

	void Destroy ()
	{
		Destroy(this.gameObject);
	}
}
