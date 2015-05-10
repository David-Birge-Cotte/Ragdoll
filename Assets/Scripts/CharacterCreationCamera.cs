using UnityEngine;
using System.Collections;

public class CharacterCreationCamera : MonoBehaviour 
{
	public GameObject BG;
	public float adaptation;


	// Update is called once per frame
	void Update () 
	{
		if ( GetComponent<Camera>().orthographicSize - Input.GetAxis("Mouse ScrollWheel")  > 2 && GetComponent<Camera>().orthographicSize - Input.GetAxis("Mouse ScrollWheel") < 15)
		{
			GetComponent<Camera>().orthographicSize -= Input.GetAxis("Mouse ScrollWheel");
			BG.transform.localScale = new Vector3(GetComponent<Camera>().orthographicSize * adaptation, GetComponent<Camera>().orthographicSize * adaptation, 1);


		}
	}
}
