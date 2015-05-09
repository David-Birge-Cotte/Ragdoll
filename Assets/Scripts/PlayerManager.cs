using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour 
{

	public GameObject particlePrefab;

	void OnCollisionEnter2D(Collision2D collision)
	{
		if( GetComponent<Rigidbody2D>().velocity.magnitude < 0.2)
		{
			for (int i = 0; i < Random.Range(5, 10); i++)
			{
				Vector3 pos = collision.contacts[0].point;
				GameObject particle = GameObject.Instantiate(particlePrefab, pos, Quaternion.identity) as GameObject;
				particle.GetComponent<Rigidbody2D>().AddTorque(1, ForceMode2D.Impulse);
				particle.GetComponent<Rigidbody2D>().AddForce(new Vector2( -5 + Random.value * 10, Random.value * 10) , ForceMode2D.Impulse);
			}
		}
	}
}
