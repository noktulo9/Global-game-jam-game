using System;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

	public Rigidbody2D Player;
	public float Speed = 5f;
	public float JumpPower = 20f;
	public bool Ground = true;
	public LayerMask PlatformMask;
	public Animator Animator = null;

	
	private bool _flipSide = false;
	private SpriteRenderer _spriteRenderer;
	private float distance = 20f;

	
	// Use this for initialization
	void Start ()
	{
		Animator = GetComponent<Animator>();
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
			
			jump = Vector2.up * JumpPower;
			Animator.SetTrigger("jump");
		}
		
		
		Player.velocity = move * Speed + jump;

		transform.localRotation = move.x < 0 ? Quaternion.Euler(0, 0, 0) : Quaternion.Euler(0, 180, 0);
		if (Math.Abs(Player.velocity.x) > 0.01f)
		{
			Animator.SetBool("walk", true);
		}
		else if (Player.velocity.x == 0)
		{
			Animator.SetBool("walk", false);
		}
		
		
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
