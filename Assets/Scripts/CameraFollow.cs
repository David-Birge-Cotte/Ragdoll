﻿using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	private GameObject target;
	public Vector3 offset;
	public float smoothiness = 0.2f;


	void Start()
    {
		target = GameObject.FindGameObjectWithTag("Player");
	}


	// Update is called once per frame
	void Update () 
    {
        if(!target)
        {
			target = GameObject.FindGameObjectWithTag("Player");
			Debug.Log("Pas de Player");
            return;
        }

		Vector3 pos = new Vector3( target.transform.position.x, target.transform.position.y, -10);
		// pos.y = 0;
		// pos += offset;

		Vector3 zero = Vector3.zero;
		transform.position = Vector3.SmoothDamp(transform.position, pos, ref zero, smoothiness);
	
	}
}
