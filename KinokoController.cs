using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinokoController : MonoBehaviour {

	public float speed = 6.0f;
/*	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "player") {
			Destroy (other.gameObject);
		}
	}
*/
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed, GetComponent<Rigidbody2D> ().velocity.y);
	}
}
