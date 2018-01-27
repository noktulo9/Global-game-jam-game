using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class yVelController : MonoBehaviour {

	
	public Text yVel;

	public Rigidbody2D Player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		yVel.text = "Player Alt: " + Player.position.y;
	}
}
