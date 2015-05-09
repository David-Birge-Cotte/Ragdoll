using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class _Manager : MonoBehaviour {

	public int Score;	
	public Text ScoreUI;
	GameObject[] listeCollectibles;

	GameObject player;
	Vector3 initialPlayerPos;


	void Start(){
		player = GameObject.Find("Player");
		initialPlayerPos = player.transform.position;
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
		player.transform.position = initialPlayerPos;
		Application.LoadLevel(Application.loadedLevel);
	}
}
