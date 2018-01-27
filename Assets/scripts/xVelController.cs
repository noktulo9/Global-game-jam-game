using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class xVelController : MonoBehaviour
{

	public Text xVel;

	public Rigidbody2D Player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		xVel.text = "Dog Alt: " + Player.position.y;
	}
}
