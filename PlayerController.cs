﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

public float speed = 15.0f;
public float padding = 1f;

float xmin;
float xmax;

	// Use this for initialization
	void Start () {
	
	//Study this later for more in depth understanding
	// ViewportToWorldPoint contains an unorthodox Vecotr3 of 0 to 1 and is relative to the screen
	float distance = transform.position.z - Camera.main.transform.position.z;
	Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
	Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
	xmin = leftmost.x + padding;
	xmax = rightmost.x - padding;
	}
	
	// Update is called once per frame
	void Update () {
	if (Input.GetKey (KeyCode.LeftArrow)) {
	
			//Deltatime = Time between frame updates and multiplying speed by it makes the function frame rate indipendent
			//  Original more complex way = transform position += new Vector3 (-/+speed * Time.deltaTime;
			transform.position += Vector3.left * speed * Time.deltaTime;
		} else if (Input.GetKey (KeyCode.RightArrow)) {
		transform.position += Vector3.right * speed * Time.deltaTime;
		}
		
		
		//restrict the player to the game space
		float newX = Mathf.Clamp (transform.position.x, xmin, xmax);
		transform.position = new Vector3 (newX, transform.position.y, transform.position.z);
	}

}



