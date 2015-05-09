using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TongueBehaviour : MonoBehaviour {

	public GameObject tongue;

	bool throwed, collided;

	int counter = 0;

	public GameObject objPrefab;
	List<GameObject> objs = new List<GameObject>();

	GameObject lastObj;

	void Update ()
	{
		if( Input.GetKeyDown(KeyCode.Z) )
		{
			if( !throwed )
			{
				throwed = true;
				GetComponent<HingeJoint2D>().enabled = false;
				tongue.GetComponent<SliderJoint2D>().enabled = false;
				tongue.GetComponent<SliderJoint2D>().useMotor = true;
				InvokeRepeating( "Do", 0.1f, 0.12f );
			}
		}
		else if( Input.GetKeyUp(KeyCode.Z) )
		{
			if( throwed )
			{
				collided = true;
				tongue.GetComponent<SliderJoint2D>().useMotor = false;
			}
		}
	}

	void Do()
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

				/*if( counter > 1 )
					objs[0].GetComponent<HingeJoint2D>().connectedBody = GetComponent<Rigidbody2D>();
				else
					tongue.GetComponent<HingeJoint2D>().connectedBody = GetComponent<Rigidbody2D>();*/
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
	}
}
