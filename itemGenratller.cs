using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemGenratller : MonoBehaviour {

	public GameObject kinokoPrefab;
	GameObject item;

	void Start(){
		this.item = GameObject.Find ("item");
	}

	public void goitem(){
		GameObject go = Instantiate (kinokoPrefab) as GameObject;
		go.transform.position = item.transform.position;
	}
}
