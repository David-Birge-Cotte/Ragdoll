using UnityEngine;
using System.Collections;

public class CharacterCreationCamera : MonoBehaviour 
{

	// Update is called once per frame
	void Update () 
	{
		if ( GetComponent<Camera>().orthographicSize - Input.GetAxis("Mouse ScrollWheel")  > 2 && GetComponent<Camera>().orthographicSize - Input.GetAxis("Mouse ScrollWheel") < 15)
		{
			GetComponent<Camera>().orthographicSize -= Input.GetAxis("Mouse ScrollWheel");			
		}
	}
}
