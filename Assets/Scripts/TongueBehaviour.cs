using UnityEngine;

public class TongueBehaviour : Lamb {

	void Start()
	{
		userKey = "v";
	}

	public GameObject head, cou;
	public Sprite[] mouths;

	public bool throwed, collided;

	float distance, velocityF;
	Vector3 velocity;

	RaycastHit2D hit;

	void Update ()
	{
		Debug.DrawRay( head.transform.position, transform.up );

		if( Input.GetKeyDown(userKey) )
		{
			GetComponent<AudioSource>().PlayOneShot(SFX[0]);

			if( !throwed && !collided )
			{
				throwed = true;
				head.GetComponent<SpriteRenderer>().sprite = mouths[1];
				Debug.Log("begin");
			}
		}
		else if( Input.GetKeyUp(userKey) )
		{
			if( throwed && !collided )
			{
				head.GetComponent<SpriteRenderer>().sprite = mouths[0];
				collided = true;
				Debug.Log("key release");
			}
			else if( !throwed )
			{
				GetComponent<DistanceJoint2D>().enabled = false;
				throwed = false;
				collided = false;
				hit = new RaycastHit2D();
				Debug.Log("end key release");
			}
		}

		if( throwed )
		{
			if( !collided )
			{
				head.transform.localPosition += new Vector3(0,0.3f);
				cou.transform.localPosition += new Vector3(0,0.16f);
				cou.transform.localScale += new Vector3(0,0.24f);
				/*head.transform.localPosition = Vector3.SmoothDamp( head.transform.localPosition, new Vector3(0,20), ref velocity, 0.3f );
				cou.transform.localPosition = Vector3.SmoothDamp( cou.transform.localPosition, new Vector3(0,20), ref velocity, 0.3f );
				cou.transform.localScale = Vector3.SmoothDamp( cou.transform.localScale, new Vector3(1.5f,4), ref velocity, 0.3f );*/

				hit = Physics2D.Raycast( head.transform.position, transform.up );
				if( hit.collider != null /*&& hit.collider.tag == "Platform" */)
				{
					distance = Vector3.Distance( transform.localPosition, transform.InverseTransformPoint(hit.point) );
					Debug.Log(distance+" "+head.transform.localPosition.y);
					if( distance > 7 )
					{
						head.GetComponent<SpriteRenderer>().sprite = mouths[0];
						collided = true;
						Debug.Log("too long "+distance);
					}
					else if( head.transform.localPosition.y > distance )
					{
						GetComponent<DistanceJoint2D>().connectedAnchor = (Vector2)hit.point;
						GetComponent<DistanceJoint2D>().enabled = true;

						head.GetComponent<SpriteRenderer>().sprite = mouths[0];
						collided = true;
						//GetComponent<AudioSource>().PlayOneShot(SFX[1]);
						Debug.Log("true collided");
					}
					/*else
					{
						head.GetComponent<SpriteRenderer>().sprite = mouths[0];
						collided = true;
						GetComponent<AudioSource>().PlayOneShot(SFX[0]);
					}*/
				}
				else if( head.transform.localPosition.y > 12 )
				{
					head.GetComponent<SpriteRenderer>().sprite = mouths[0];
					collided = true;
					Debug.Log("not collided");
				}
			}
			else
			{
				if( head.transform.localPosition.y > 0.4f )
				{
					/*head.transform.localPosition = Vector3.SmoothDamp( head.transform.localPosition, new Vector3(0,2.2f), ref velocity, 0.3f );
					cou.transform.localPosition = Vector3.SmoothDamp( cou.transform.localPosition, Vector3.zero, ref velocity, 0.3f );
					cou.transform.localScale = Vector3.SmoothDamp( cou.transform.localScale, new Vector3(1.5f,1.5f), ref velocity, 0.3f );*/
					GetComponent<DistanceJoint2D>().distance = Mathf.SmoothDamp( GetComponent<DistanceJoint2D>().distance, 0, ref velocityF, 0.3f );

					head.transform.localPosition -= new Vector3(0,0.3f);
					cou.transform.localPosition -= new Vector3(0,0.16f);
					cou.transform.localScale -= new Vector3(0,0.24f);
					//GetComponent<HingeJoint2D>().anchor -= new Vector2(0,0.5f);
				}
				else if( !Input.GetKey(userKey) )
				{
					GetComponent<DistanceJoint2D>().enabled = false;
					throwed = false;
					collided = false;
					hit = new RaycastHit2D();
					Debug.Log("end");
				}
				/*else
				{
					throwed = false;
					collided = false;
				}*/
			}
		}
	}
}
