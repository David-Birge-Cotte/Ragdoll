﻿using UnityEngine;
using System.Collections;

public class LegBehavior_2 : Lamb {

	public float speedExtend = 12.0f;
	public float speedRetract = 20.0f;
	public float speedRetractPivot = 10.0f;


	public GameObject piston;
	public GameObject foot;
	public bool IsOnFloor;
	private GameObject player;

	public float maxYPiston = 2.0f;
	private Vector3 firstPos;
	private float speed;
	private float coolDown = 0;


	void Start()
	{
		player = GameObject.Find("Player");
	}

	void Update () {

		if(coolDown > 0)
			coolDown -= Time.deltaTime;

		IsOnFloor = foot.GetComponent<FootTestCollision>().IsOnFloor;


		if(Input.GetKey(KeyCode.Space))
		{
			if(piston.transform.localPosition.y < maxYPiston)
			{
				if(GetComponent<HingeJoint2D>() != null)
				{
					GetComponent<HingeJoint2D>().anchor += new Vector2(0, Time.deltaTime * speedRetractPivot);
				}
				piston.transform.Translate( 0, Time.deltaTime * speedRetract, 0 );
				if(IsOnFloor && coolDown <= 0)
				{
					coolDown = 0.1f;
					player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 800));
				}
			} 
		}
		else if(piston.transform.localPosition.y > 0.1f)
		{
			if(GetComponent<HingeJoint2D>() != null)
			{
				GetComponent<HingeJoint2D>().anchor += new Vector2(0, Time.deltaTime * -speedRetractPivot);
			}
			piston.transform.Translate( 0, Time.deltaTime * -speedRetract, 0 );
		}
	}
}
