using UnityEngine;
using DG.Tweening;

public class PlayerManager : MonoBehaviour 
{
	public GameObject particlePrefab;
    bool DontRecreate;

    void Awake()
    {
        if (!DontRecreate)
        {
            DontDestroyOnLoad(transform.gameObject);
        }
		else if( PlayerPrefs.HasKey("Sound") )
		{
			foreach( AudioSource AS in FindObjectsOfType<AudioSource>() )
			{
				if( PlayerPrefs.GetInt("Sound") == 0 )
					AS.mute = true;
				else
					AS.mute = false;
			}
		}
    }

    void Start()
    {
    	transform.position = new Vector3(0, -5, 0);
        DontRecreate = true;
        transform.DOMove(Vector3.zero, 3).SetEase(Ease.OutElastic);
    }

	void OnCollisionEnter2D(Collision2D collision)
	{
		if( GetComponent<Rigidbody2D>().velocity.magnitude < 0.2)
		{
			for (int i = 0; i < Random.Range(5, 10); i++)
			{
				Vector3 pos = collision.contacts[0].point;
				GameObject particle = (GameObject)Instantiate(particlePrefab, pos, Quaternion.identity);
				particle.GetComponent<Rigidbody2D>().AddTorque(1, ForceMode2D.Impulse);
				particle.GetComponent<Rigidbody2D>().AddForce(new Vector2( -5 + Random.value * 10, Random.value * 10) , ForceMode2D.Impulse);
			}
		}

		if( collision.collider.tag == "ADN" )
		{
			FindObjectOfType<_Manager>().AddScore();
			Destroy(collision.gameObject);
		}
		else if( collision.collider.tag == "EndLevel" )
		{
			Application.LoadLevel("CharacterCreation");
			Destroy( gameObject );
		}
	}
}
