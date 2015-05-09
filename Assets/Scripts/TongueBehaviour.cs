using UnityEngine;

public class TongueBehaviour : MonoBehaviour {

	public GameObject head, cou;
	public Sprite[] mouths;

	public bool throwed, collided;

	float distance, velocityF;
	Vector3 velocity;

	RaycastHit2D hit;

	void Update ()
	{
		Debug.DrawRay( transform.position, transform.up );

		if( Input.GetKeyDown(KeyCode.Z) )
		{
			if( !throwed && !collided )
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
				GetComponent<DistanceJoint2D>().enabled = false;
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
				/*head.transform.localPosition = Vector3.SmoothDamp( head.transform.localPosition, new Vector3(0,20), ref velocity, 0.3f );
				cou.transform.localPosition = Vector3.SmoothDamp( cou.transform.localPosition, new Vector3(0,20), ref velocity, 0.3f );
				cou.transform.localScale = Vector3.SmoothDamp( cou.transform.localScale, new Vector3(1.5f,4), ref velocity, 0.3f );*/

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
					else if( head.transform.localPosition.y > distance )
					{
						GetComponent<DistanceJoint2D>().connectedAnchor = (Vector2)hit.point;
						GetComponent<DistanceJoint2D>().enabled = true;

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
					/*head.transform.localPosition = Vector3.SmoothDamp( head.transform.localPosition, new Vector3(0,2.2f), ref velocity, 0.3f );
					cou.transform.localPosition = Vector3.SmoothDamp( cou.transform.localPosition, Vector3.zero, ref velocity, 0.3f );
					cou.transform.localScale = Vector3.SmoothDamp( cou.transform.localScale, new Vector3(1.5f,1.5f), ref velocity, 0.3f );*/
					GetComponent<DistanceJoint2D>().distance = Mathf.SmoothDamp( GetComponent<DistanceJoint2D>().distance, 0, ref velocityF, 0.3f );

					head.transform.localPosition -= new Vector3(0,0.5f);
					cou.transform.localPosition -= new Vector3(0,0.25f);
					cou.transform.localScale -= new Vector3(0,0.4f);
					//GetComponent<HingeJoint2D>().anchor -= new Vector2(0,0.5f);
				}
				else if( !Input.GetKey(KeyCode.Z) )
				{
					GetComponent<DistanceJoint2D>().enabled = false;
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
}
