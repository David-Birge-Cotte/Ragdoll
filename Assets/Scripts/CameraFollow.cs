using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject target;
	public Vector3 offset;


	// Use this for initialization
	void Start () {
		transform.position = target.transform.position + offset;
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 pos;
		pos = target.transform.position;
		pos.y = 0;
		pos += offset;

		transform.position = pos;
	
	}
}
