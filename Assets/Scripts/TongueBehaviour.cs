using UnityEngine;

public class TongueBehaviour : Lamb {


	public GameObject head, neckPivot;
	public Sprite[] mouths;
	public float speed;
	public float maxScale = 10;

	private bool throwed, collided;
	private Vector3 contactPoint = Vector3.zero;
	private GameObject contactObject = null;
	private bool isIn = false;

	private Vector3 initialHeadPos = Vector3.zero;
	
	void Start()
	{
		initialHeadPos = head.transform.localPosition;
		userKey = "v";
	}

	void Update ()
	{
		Debug.DrawRay( head.transform.position, transform.up );

		if( Input.GetKeyDown(userKey) )
		{
			GetComponent<AudioSource>().PlayOneShot(SFX[0]);
			throwed = true;
		}
		else if( Input.GetKeyUp(userKey) )
		{
			GetComponent<DistanceJoint2D>().connectedBody = null;
			GetComponent<DistanceJoint2D>().enabled = false;			
			head.transform.localPosition = initialHeadPos;
			throwed = false;
		}

		if (throwed)
			GetOut();
		else if (!isIn)					
			GetIn();
	}

	void GetOut()
	{
//		Debug.Log("get out");
		if( !Input.GetKey(userKey) )
			throwed = false;

		if ( head.GetComponent<SpriteRenderer>().sprite == mouths[0])
			head.GetComponent<SpriteRenderer>().sprite = mouths[1];
		isIn = false;

		if (collided)
		{
			if ( !GetComponent<DistanceJoint2D>().enabled )
			{
				head.transform.position = contactPoint;
				GetComponent<DistanceJoint2D>().connectedAnchor = head.transform.position;
				GetComponent<DistanceJoint2D>().enabled = true;

				if ( contactObject.GetComponent<Rigidbody2D>() != null )
					GetComponent<DistanceJoint2D>().connectedBody = contactObject.GetComponent<Rigidbody2D>();
				throwed = false;
			}
		}
		else
		{
//			Debug.Log("aggrandir");
			neckPivot.transform.localScale += new Vector3(0,speed, 0) * Time.deltaTime;
			head.transform.localScale = new Vector2 ( 1 / neckPivot.transform.localScale.x, 1 / neckPivot.transform.localScale.y );
		}
	}

	void GetIn()
	{
//		Debug.Log("get in");
		if ( head.GetComponent<SpriteRenderer>().sprite == mouths[1])
			head.GetComponent<SpriteRenderer>().sprite = mouths[0];

		if ( collided )
		{
			float velocity = 0;
			GetComponent<DistanceJoint2D>().distance = Mathf.SmoothDamp( GetComponent<DistanceJoint2D>().distance, 0, ref velocity, 0.3f );
		}

		if ( neckPivot.transform.localScale.y > 1)
		{
			isIn = false;
			neckPivot.transform.localScale -= new Vector3(0,speed, 0) * Time.deltaTime;
			head.transform.localScale = new Vector2 ( 1 / neckPivot.transform.localScale.x, 1 / neckPivot.transform.localScale.y );
		}
		else
		{
			neckPivot.transform.localScale = Vector3.one;
			throwed = false;
			isIn = true;
		}
	}


	void OnCollisionEnter2D( Collision2D col )
	{
		if ( col.collider.tag == "Player" || col.collider.tag == "Lambs" || col.collider.tag == "Pivots"  )
			return;
		collided = true;
		contactPoint = col.contacts[0].point;
	}
	void OnCollisionExit2D( Collision2D col )
	{
		collided = false;
		contactPoint = Vector3.zero;
		contactObject = col.gameObject;
	}
}
