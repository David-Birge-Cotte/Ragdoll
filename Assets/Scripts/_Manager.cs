using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class _Manager : MonoBehaviour {

	public int Score;	
	public Text ScoreUI, soundButton;
	public GameObject pausePanel;
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

	public void RestartLevel()
	{
		Debug.Log("Restart level");
		player.transform.position = initialPlayerPos;
		Application.LoadLevel(Application.loadedLevel);
	}

	public void SetPause()
	{
		Time.timeScale = 0;
		pausePanel.SetActive(true);
	}
	public void Resume()
	{
		Time.timeScale = 1;
		pausePanel.SetActive(false);
	}

	public void GoToEditor()
	{
		Destroy( player );
		Application.LoadLevel("CharacterCreation");
	}

	bool soundActive = true;
	public void SwitchSound()
	{
		if( soundActive )
		{
			Camera.main.GetComponent<AudioSource>().mute = soundActive = false;
			soundButton.text = "Sound : OFF";
		}
		else
		{
			Camera.main.GetComponent<AudioSource>().mute = soundActive = true;
			soundButton.text = "Sound : ON";
		}
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
