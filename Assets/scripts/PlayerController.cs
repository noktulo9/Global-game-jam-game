using System;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

	public Rigidbody2D Player;
	public Text HorAx;
	public Text VerAx;
	public Text Dist;
	public int Speed = 5;
	public int JumpPower = 20;
	public bool Ground = true;
	public LayerMask PlatformMask;
	public Animation Anim;
		
	private bool _flipSide = false;
	private SpriteRenderer _spriteRenderer;
	                                 

	private float distance = 20f;

	// Use this for initialization
	void Start ()
	{ 
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		
		
		RaycastHit2D hit = Physics2D.Raycast(Player.position, Vector2.down, distance, PlatformMask);
		
		Vector2 move = new Vector2(Input.GetAxis("Horizontal"),0f);
		Vector2 jump = new Vector2(0f, Player.velocity.y);
		if (hit.collider == null) hit.distance = 0;
		if (Input.GetButtonDown("Jump") && hit.distance < 0.9f)
		{
			//Debug.Log((Ground));
			jump = Vector2.up * JumpPower;
			//InvokeRepeating("Falsing",0.5f,0.1f);
			//Debug.Log((Ground));

			//Debug.Log(Ground);
		}
		
		Player.velocity = move * Speed + jump;

		transform.localRotation = move.x < 0 ? Quaternion.Euler(0, 0, 0) : Quaternion.Euler(0, 180, 0);
		

//		_flipSide = (_spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.01f));
//		if (_flipSide)
//		{
//			_spriteRenderer.flipX = !_spriteRenderer.flipX;
//		}

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
