using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class DogController : MonoBehaviour
{


	public Rigidbody2D Player;
	public Rigidbody2D Dog;
	public Rigidbody2D Beacon;
	public Animator Animator =  null;
	
	public float DistanceToPlayer;
	public float DistanceToBeacon;
	public float Speed = 0.5f;
	
	
	// Use this for initialization
	void Start ()
	{
		Animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		
		
		Vector2 DogPosition = Dog.position;
		Vector2 PlayerPosition = Player.transform.position;
		Vector2 jump = new Vector2(1f, 0f);
		
		DistanceToPlayer = Math.Abs(DogPosition.x - PlayerPosition.x);
		
		Vector2 Direction = PlayerPosition - DogPosition;

		if (Math.Abs(Dog.velocity.x) > 0.5f)
		{
			Animator.SetBool("walk",true);
		}
		else
		{
			Animator.SetBool("walk", false);
		}
		if (Math.Abs(Dog.velocity.y) > 0.5f)
		{
			Animator.SetTrigger("jump");
		}

		if((int)(Dog.position.y - Player.position.y) != 0)
		{
			jump = new Vector2(0f,18f);
		}
		else jump = new Vector2(0f,0f);
		
		
		if (DistanceToPlayer > 3)
		{
			Dog.velocity = new Vector2(Direction.x * Speed, jump.y);
		}

		transform.localRotation = Dog.velocity.x < 0 ? Quaternion.Euler(0, 0, 0) : Quaternion.Euler(0, 180, 0);

		Debug.DrawLine(DogPosition, PlayerPosition, Color.red, 0.5f);
	}
}
