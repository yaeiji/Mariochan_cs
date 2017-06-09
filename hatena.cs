using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hatena : MonoBehaviour {

	int animeIndex=0;
	public Sprite []box;

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "player") {
			if (animeIndex == 0) {
				animeIndex++;
				GetComponent<SpriteRenderer> ().sprite = box [animeIndex];
				GameObject director=GameObject.Find("itemGenratller");
				director.GetComponent<itemGenratller> ().goitem ();
			}
		}
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
