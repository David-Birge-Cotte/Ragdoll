using UnityEngine;
using System.Collections;

public class FootTestCollision : MonoBehaviour {

	public bool IsOnFloor;

	void OnCollisionStay2D(Collision2D other)
	{
		if(other.gameObject.tag == "Platform")
			IsOnFloor = true;

	}

	void OnCollisionExit2D()
	{
		IsOnFloor = false;
	}
}
