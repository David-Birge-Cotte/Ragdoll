using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class _Manager : MonoBehaviour {

	public int Score;	
	public Text ScoreUI;
	private GameObject[] listeCollectibles;

	private GameObject player;


	void Start(){
		player = GameObject.Find("Player");
		player.GetComponent<Rigidbody2D>().isKinematic = false; //au démarage du niveau
	}



	void Update () 
	{
		listeCollectibles = GameObject.FindGameObjectsWithTag("Collectible");
		ScoreUI.text = "Score : " + Score.ToString() + "/" + listeCollectibles.Length.ToString();
	}

	public void restartLevel()
	{
		Debug.Log("Restart level");
		Application.LoadLevel(Application.loadedLevel);
	}
}
