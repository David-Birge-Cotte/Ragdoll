using UnityEngine;
using System.Collections;

public class LegBehavior : MonoBehaviour {

	private float speed = 3f;

	private Vector3 m_scale;
	private Vector3 m_newScale;


	// Use this for initialization
	void Start () 
	{
		m_scale = transform.localScale;
		m_newScale = new Vector3(m_scale.x * 3, m_scale.y, m_scale.z);

	
	}
	
	// Update is called once per frame
	void Update () {


		if(Input.GetKey(KeyCode.Space)) //NiceToHave : Utiliser l'Input Manager pour pouvoir le regler in-game / dans le launcher Unity.
		{
			Vector3 tempScale = transform.localScale;

			if(transform.localScale.x < m_newScale.x)
			{
				tempScale.x += Time.deltaTime * speed;
				transform.localScale = tempScale;
			}

		} else 
		{
			transform.localScale = m_scale;
		}
	
	}
}
