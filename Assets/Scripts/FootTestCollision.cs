using UnityEngine;
using System.Collections;

public class FootTestCollision : MonoBehaviour {

	public bool IsOnFloor;

	void Update(){
		Debug.Log(IsOnFloor);
	}

	void OnCollisionStay2D(Collision2D other)
	{
		if(other.gameObject.tag == "platform")
			IsOnFloor = true;

	}

	void OnCollisionExit2D()
	{
		IsOnFloor = false;
	}
}
