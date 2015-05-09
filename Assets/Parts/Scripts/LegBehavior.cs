using UnityEngine;
using System.Collections;

public class LegBehavior : MonoBehaviour {

	private Vector3 m_scale;
	private Vector3 m_newScale;


	// Use this for initialization
	void Start () 
	{
		m_scale = transform.localScale;
		m_newScale = new Vector3(m_scale.x, m_scale.y * 3, m_scale.z);

	
	}
	
	// Update is called once per frame
	void FixedUpdate () {


		if(Input.GetKey(KeyCode.Space)) //NiceToHave : Utiliser l'Input Manager pour pouvoir le regler in-game / dans le launcher Unity.
		{
			transform.localScale = m_newScale;
		} else {
			transform.localScale = m_scale;
		}
	
	}
}
