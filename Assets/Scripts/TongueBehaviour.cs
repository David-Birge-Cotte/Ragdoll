using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TongueBehaviour : MonoBehaviour {

	public GameObject poids;

	bool throwed, collided;

	int counter = 0;
	float distance;

	RaycastHit2D hit;

	void Update ()
	{
		Debug.DrawRay( transform.position, transform.right );

		if( Input.GetKeyDown(KeyCode.Z) )
		{
			if( !throwed )
			{
				throwed = true;
			}
		}
		else if( Input.GetKeyUp(KeyCode.Z) )
		{
			if( throwed )
			{
				collided = true;
			}
		}

		if( Input.GetKey(KeyCode.Z) )
		{
			if( throwed )
			{
				hit = Physics2D.Raycast( transform.position+transform.TransformPoint(10,0,0), transform.right );
				if( hit.collider != null )
				{
					if( !collided )
					{
						distance = Vector3.Distance( transform.position, hit.point );
						if( counter < distance )
						{
							counter++;
							transform.localScale += new Vector3(0.15f,0);
						}
						else
						{
							collided = true;
							GetComponent<HingeJoint2D>().connectedBody = ((GameObject)Instantiate( poids, hit.point, Quaternion.identity )).GetComponent<Rigidbody2D>();
							//hit.collider.GetComponent<HingeJoint2D>().anchor = (Vector2)hit.transform.InverseTransformPoint( hit.point );
							GetComponent<HingeJoint2D>().enabled = true;
						}
					}
					else
					{
						if( counter > 0 )
						{
							counter--;
							transform.localScale -= new Vector3(0.15f,0);
						}
						else
						{
							collided = false;
							throwed = false;
						}
					}
				}
			}
		}
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
