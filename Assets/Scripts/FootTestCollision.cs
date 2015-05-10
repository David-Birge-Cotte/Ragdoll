using UnityEngine;
using System.Collections;

public class FootTestCollision : MonoBehaviour {

	public bool IsOnFloor;

	void OnCollisionStay2D(Collision2D other)
	{
		if(other.collider.tag == "Platform")
		{
			IsOnFloor = true;
			//Debug.Log("IsOnFloor true");
		}
		/*else
		{
			IsOnFloor = true;
			Debug.Log("IsOnFloor not platform true");
		}*/
	}

	void OnCollisionExit2D()
	{
		IsOnFloor = false;
		//Debug.Log("IsOnFloor false");
	}
}
