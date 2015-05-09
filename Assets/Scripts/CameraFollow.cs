using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	private GameObject target;
	public Vector3 offset;


	void Start(){
		target = GameObject.Find("Player");
	}


	// Update is called once per frame
	void Update () {

		if(target)
		{
			Vector3 pos;
			pos = target.transform.position;
			pos.y = 0;
			pos += offset;
			
			Vector3 zero = Vector3.zero;
			transform.position = Vector3.SmoothDamp(transform.position, pos, ref zero, 0.2f);
		}

	
	}
}
