using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	private GameObject target;
	public Vector3 offset;
	public float smoothiness = 0.2f;


	void Start(){
		target = GameObject.Find("Player");
	}


	// Update is called once per frame
	void Update () {

		Vector3 pos = new Vector3( target.transform.position.x, target.transform.position.y, -10);
		// pos.y = 0;
		// pos += offset;

		Vector3 zero = Vector3.zero;
		transform.position = Vector3.SmoothDamp(transform.position, pos, ref zero, smoothiness);
	
	}
}
