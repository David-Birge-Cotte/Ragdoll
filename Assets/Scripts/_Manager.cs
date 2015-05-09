using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class _Manager : MonoBehaviour {

	public int Score;	
	public Text ScoreUI;
	private GameObject[] listeCollectibles;

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
