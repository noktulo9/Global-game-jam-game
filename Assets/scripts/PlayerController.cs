using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

	public Rigidbody2D Player;
	public Text HorAx;
	public Text VerAx;
	public int Speed = 5;
	public int JumpPower = 20;
	public bool Ground = true;

	// Use this for initialization
	void Start ()
	{ 
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		Vector2 move = new Vector2(Input.GetAxis("Horizontal"),0f);
		Vector2 jump = new Vector2(0f, Player.velocity.y);

		
		
		if (Input.GetButtonDown("Jump") && Ground == true)
		{
			Debug.Log((Ground));
			jump = Vector2.up * JumpPower;
			InvokeRepeating("Falsing",0.5f,0.1f);
			Debug.Log((Ground));


			//Debug.Log(Ground);
		}
		
		
		
		Player.velocity = move * Speed + jump;

		
		
		HorAx.text = "X Velocity: " + Player.velocity.x;
		VerAx.text = "Y Velocity: " + Player.velocity.y;
	}

	private void OnCollisionStay2D(Collision2D other)
	{
		Ground = true;
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Platform"))
		{
			//Debug.Log(Ground);
		}
	}

	void Falsing()
	{
		Ground = false;
		Debug.Log(Ground);
	}
}
