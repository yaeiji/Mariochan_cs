using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour {
	public float speed = 1.0f;
	// Use this for initialization
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "player") {
			Destroy (gameObject);
		
		}
	}

	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (-speed, GetComponent<Rigidbody2D> ().velocity.y);	
	}
}
