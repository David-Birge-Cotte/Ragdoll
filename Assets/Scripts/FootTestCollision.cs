using UnityEngine;
using System.Collections;

public class FootTestCollision : MonoBehaviour {

	public bool isOnFloor;
	private float distanceToGround = 0;

	void Start()
	{
		distanceToGround = GetComponent<BoxCollider2D>().bounds.extents.y;
	}

	public bool IsOnFloor()
	{
		Debug.Log(Physics2D.Raycast(transform.position, -Vector2.up, distanceToGround + 0.1f));
		Debug.DrawRay(transform.position,-Vector2.up, Color.cyan, distanceToGround );
		return Physics2D.Raycast(transform.position, -Vector2.up, distanceToGround + 0.1f);
	}

	void OnCollisionStay2D(Collision2D other)
	{
		if(other.collider.tag == "Platform")
		{
			isOnFloor = true;
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
		isOnFloor = false;
		//Debug.Log("IsOnFloor false");
	}
}
