﻿using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject target;
	public Vector3 offset;

	// Update is called once per frame
	void Update () {

		Vector3 pos;
		pos = target.transform.position;
		pos.y = 0;
		pos += offset;

		Vector3 zero = Vector3.zero;
		transform.position = Vector3.SmoothDamp(transform.position, pos, ref zero, 0.2f);
	
	}
}