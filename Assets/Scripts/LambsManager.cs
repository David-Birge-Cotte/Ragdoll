using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LambsManager : MonoBehaviour 
{
	public List<GameObject> pivots;

	public GameObject selectedLamb;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if ( selectedLamb == null )
		{

		}
		else
		{
			if( Input.GetKeyDown(KeyCode.W) ) 
			{

			}			
		}
	}
}
