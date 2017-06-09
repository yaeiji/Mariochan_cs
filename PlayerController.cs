using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	
	public float speed = 12.0f;
	public Sprite[] walk;
    float jumpForce=9.0f;
	int animeIndex;

	bool walkcheck;
	int jumpcheck;
	float x=0,y=0;
	int key=0;

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "kinoko") {
			Destroy (other.gameObject);
			this.speed = this.speed +(float) 4.0;
			x++;
			y++;
		//	gameObject.transform.localScale += new Vector3(1,1,0) ;
		}
	}
		
	// Use this for initialization
	void Start () {
		x++;
		y++;
		animeIndex = 0;
		walkcheck = false;
		jumpcheck = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
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
			GetComponent<Rigidbody2D> ().velocity = new Vector2(0,GetComponent<Rigidbody2D> ().velocity.y);
			walkcheck = false;

			animeIndex = 0;
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			key = -1;
			walkcheck = true;
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed * key, GetComponent<Rigidbody2D> ().velocity.y);
		} else if (Input.GetKeyUp (KeyCode.LeftArrow) && walkcheck) {
			GetComponent<Rigidbody2D> ().velocity =new Vector2 (0,GetComponent<Rigidbody2D> ().velocity.y);

			animeIndex = 0;
			walkcheck = false;
		}

		if (Input.GetKeyDown (KeyCode.Space) && jumpcheck < 2) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jumpForce);
			jumpcheck++;
		}


		if (key != 0) {
			
			gameObject.transform.localScale =  new Vector3 (x*key, y);
		}

		if (GetComponent<Rigidbody2D> ().velocity.y == 0) {
			jumpcheck = 0;
		}

	
	
	}	
}
