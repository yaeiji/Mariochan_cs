using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	
	public float speed = 7.0f;
	public Sprite[] walk;
    float jumpForce=7.0f;
	int animeIndex;
	bool walkcheck;
	int jumpcheck;






	// Use this for initialization
	void Start () {
		animeIndex = 0;
		walkcheck = false;
		jumpcheck = 0;
	}
	
	// Update is called once per frame
	void Update () {

		int key = 0;
		if (GetComponent<Rigidbody2D> ().velocity.y != 0) {
			animeIndex = 3;
			GetComponent<SpriteRenderer> ().sprite = walk [animeIndex];

		} else if (walkcheck) {
			animeIndex++;
			if (animeIndex >= walk.Length) {
				animeIndex = 0;
			}
			GetComponent<SpriteRenderer> ().sprite = walk [animeIndex];
		} else if (GetComponent<Rigidbody2D> ().velocity.y == 0) {
			animeIndex = 0;
			GetComponent<SpriteRenderer> ().sprite = walk [animeIndex];
		}

		if (Input.GetKey (KeyCode.RightArrow)) {
			key = 1;
			walkcheck = true;
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed * key, GetComponent<Rigidbody2D> ().velocity.y);
		} else if (Input.GetKeyUp (KeyCode.RightArrow) && walkcheck) {
			GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			walkcheck = false;
			key = 0;
			animeIndex = 0;
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			key = -1;
			walkcheck = true;
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed * key, GetComponent<Rigidbody2D> ().velocity.y);
		} else if (Input.GetKeyUp (KeyCode.LeftArrow) && walkcheck) {
			GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			key = 0;
			animeIndex = 0;
			walkcheck = false;
		}

		if (Input.GetKeyDown (KeyCode.Space)&&jumpcheck<2) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jumpForce);
			jumpcheck++;
		}


		if (key != 0) {
			transform.localScale = new Vector2 (key, 1);
		}

		if (GetComponent<Rigidbody2D> ().velocity.y == 0) {
			jumpcheck = 0;
		}
	}

}
