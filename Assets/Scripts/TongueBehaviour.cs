using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TongueBehaviour : MonoBehaviour {

	public GameObject head, cou;
	public Sprite[] mouths;

	bool throwed, collided;

	float distance;

	RaycastHit2D hit;

	void Update ()
	{
		Debug.DrawRay( transform.position, transform.up );

		if( Input.GetKeyDown(KeyCode.Z) )
		{
			if( !throwed )
			{
				throwed = true;
				head.GetComponent<SpriteRenderer>().sprite = mouths[1];
				Debug.Log("begin");
			}
		}
		else if( Input.GetKeyUp(KeyCode.Z) )
		{
			if( throwed && !collided )
			{
				head.GetComponent<SpriteRenderer>().sprite = mouths[0];
				collided = true;
				Debug.Log("collided");
			}
			else if( !throwed )
			{
				GetComponent<HingeJoint2D>().enabled = false;
				throwed = false;
				collided = false;
				hit = new RaycastHit2D();
				Debug.Log("end");
			}
		}

		if( throwed )
		{
			if( !collided )
			{
				head.transform.localPosition += new Vector3(0,0.5f);
				cou.transform.localPosition += new Vector3(0,0.25f);
				cou.transform.localScale += new Vector3(0,0.4f);

				hit = Physics2D.Raycast( transform.position, transform.up );
				if( hit.collider != null && hit.collider.tag == "platform" )
				{
					distance = Vector3.Distance( transform.position, hit.point )/0.3f;
					//Debug.Log( distance);
					if( distance > 10 )
					{
						head.GetComponent<SpriteRenderer>().sprite = mouths[0];
						collided = true;
						Debug.Log("collided");
					}
					else if( head.transform.localPosition.y > distance/0.3f )
					{
						GetComponent<HingeJoint2D>().anchor = new Vector2(0,distance)/0.3f;
						GetComponent<HingeJoint2D>().connectedAnchor = (Vector2)hit.point;
						GetComponent<HingeJoint2D>().enabled = true;

						head.GetComponent<SpriteRenderer>().sprite = mouths[0];
						collided = true;
						Debug.Log("collided");
					}
				}
				else if( head.transform.localPosition.y > 20 )
				{
					head.GetComponent<SpriteRenderer>().sprite = mouths[0];
					collided = true;
					Debug.Log("collided");
				}
			}
			else
			{
				if( head.transform.localPosition.y > 2.3f )
				{
					head.transform.localPosition -= new Vector3(0,0.5f);
					cou.transform.localPosition -= new Vector3(0,0.25f);
					cou.transform.localScale -= new Vector3(0,0.4f);
					GetComponent<HingeJoint2D>().anchor -= new Vector2(0,0.5f);
				}
				else if( !Input.GetKey(KeyCode.Z) )
				{
					GetComponent<HingeJoint2D>().enabled = false;
					throwed = false;
					collided = false;
					hit = new RaycastHit2D();
					Debug.Log("end");
				}
				else
				{
					throwed = false;
					collided = false;
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
