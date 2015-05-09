using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TongueBehaviour : MonoBehaviour {

	//public GameObject poids;

	bool throwed, collided;

	int counter = 0;
	float distance;

	RaycastHit2D hit;

	void FixedUpdate ()
	{
		Debug.DrawRay( transform.position, transform.right );

		if( Input.GetKeyDown(KeyCode.Z) )
		{
			if( !throwed )
			{

				hit = Physics2D.Raycast( transform.position, -transform.right );
				if( hit.collider != null && hit.collider.tag == "platform" )
				{
					throwed = true;
				}
			}
		}
		else if( Input.GetKeyUp(KeyCode.Z) )
		{
			if( throwed && !collided )
			{
				collided = true;
				Debug.Log("collided");
			}
		}

		if( throwed )
		{
			if( !collided )
			{
				distance = Vector3.Distance( transform.position, hit.point );
				Debug.Log(distance);
				if( counter/20 < distance )
				{
					counter++;
					transform.localScale += new Vector3(0.05f,0);
				}
				else
				{
					collided = true;
					GetComponent<HingeJoint2D>().connectedAnchor = (Vector2)hit.point;
					GetComponent<HingeJoint2D>().enabled = true;
					Debug.Log("collided");
				}
			}
			else
			{
				if( counter > 0 )
				{
					counter--;
					transform.localScale -= new Vector3(0.05f,0);
				}
				else
				{
					collided = false;
					throwed = false;
					GetComponent<HingeJoint2D>().enabled = false;
					hit = new RaycastHit2D();
					Debug.Log("end");
				}
			}
		}
	}

	void DestroyPoids()
	{
		GetComponent<HingeJoint2D>().enabled = false;
		Destroy( GetComponent<HingeJoint2D>().connectedBody.gameObject );
	}

	/*void Do()
	{
		if( !collided )
		{
			if( counter < 10 )
			{
				lastObj = (GameObject)Instantiate( objPrefab, transform.TransformPoint( new Vector3( -0.3f,0) ), transform.rotation );
				lastObj.transform.parent = transform;

				if( counter == 0 )
					lastObj.GetComponent<HingeJoint2D>().connectedBody = tongue.GetComponent<Rigidbody2D>();
				else if( counter > 0 )
					lastObj.GetComponent<HingeJoint2D>().connectedBody = objs[ objs.Count-1 ].GetComponent<Rigidbody2D>();

				if( counter == 9 )
				{
					GetComponent<HingeJoint2D>().enabled = true;
					GetComponent<HingeJoint2D>().connectedBody = lastObj.GetComponent<Rigidbody2D>();
				}
				
				lastObj.GetComponent<HingeJoint2D>().anchor = new Vector2(-0.35f,0);
				lastObj.GetComponent<HingeJoint2D>().connectedAnchor = new Vector2(0.35f,0);
				//tongue.GetComponent<HingeJoint2D>().connectedBody = lastObj.GetComponent<Rigidbody2D>();
				//Debug.Log( objs[ objs.Count-1 ].name );
				objs.Add( lastObj );
				counter++;
			}
			else
			{
				collided = true;
				tongue.GetComponent<SliderJoint2D>().useMotor = false;
			}
		}
		else
		{
			if( counter > 0 )
			{
				counter--;
				Destroy( objs[0] );
				objs.RemoveAt(0);
			}
			else
			{
				tongue.GetComponent<SliderJoint2D>().enabled = false;
				GetComponent<HingeJoint2D>().enabled = true;
				GetComponent<HingeJoint2D>().connectedBody = tongue.GetComponent<Rigidbody2D>();
				collided = false;
				throwed = false;
				CancelInvoke( "Do" );
			}
		}
	}*/
}
