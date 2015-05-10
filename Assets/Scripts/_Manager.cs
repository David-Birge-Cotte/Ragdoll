using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using DG.Tweening;

public class _Manager : MonoBehaviour {
    
	public Text ADNText, soundButton;
	public GameObject pausePanel, inGamePanel;

    private int maxBrain;
    private int maxADN;
    private GameObject player;
    public Vector3 initialPlayerPos;
    public List<GameObject> brains;

	void Start()
	{
		player = GameObject.Find("Player");
        player.transform.position = initialPlayerPos;
		player.GetComponent<Rigidbody2D>().isKinematic = false; //au démarage du niveau
        maxADN = GameObject.FindGameObjectsWithTag("ADN").Length;
        ADNText.text = PlayerPrefs.GetInt("currentADN") + " / " + maxADN;

        if (PlayerPrefs.HasKey("Sound"))
        {
            if ( PlayerPrefs.GetInt("Sound") == 0)
                Camera.main.GetComponent<AudioSource>().mute = true;
            else
                Camera.main.GetComponent<AudioSource>().mute = false;
        }

        //Save "1" for each brain in the world
        if (!PlayerPrefs.HasKey("brains"))
        {
            Debug.Log("first time playing.");
            string save = "";
            maxBrain = GameObject.FindGameObjectsWithTag("Brain").Length;
            for ( var i = 0; i < maxBrain; i++)
            {
                save += "1";                
            }
            Debug.Log("saving state with this : " + save);
            PlayerPrefs.SetString("brains", save);
        }
        else
        {
            Debug.Log("has already played. this is the save state : "+PlayerPrefs.GetString("brains"));
        }

        //disable brains that has already been gained
        for (int i = 0; i < brains.Count; i++)
        {
            if ( PlayerPrefs.GetString("brains")[i] == '0')
            {
                brains[i].GetComponent<SpriteRenderer>().color = Color.gray;
                brains[i].GetComponent<CircleCollider2D>().enabled = false;
            }
        }
	}



	public void AddADN ( GameObject adn )
	{
        PlayerPrefs.SetInt("currentADN", PlayerPrefs.GetInt("currentADN") + 1);
        ADNText.text = PlayerPrefs.GetInt("currentADN") + " / " + maxADN;
        maxADN--;

        adn.transform.DORotate(new Vector3(0, 0, 3), 2);
        adn.transform.DOMoveY(adn.transform.position.y + 2, 2);
        adn.transform.DOScale(Vector3.zero, 2).OnComplete(() => { Destroy(adn); }); 
	}

    public void AddBrain( GameObject brain )
    {
        int id = brain.GetComponent<Brain>().id;
        char[] save = PlayerPrefs.GetString("brains").ToCharArray();
        save[id] = '0';
        Debug.Log("id getted = " + id);
        string newSave = new string(save);
        Debug.Log("save is now = " + newSave);
        PlayerPrefs.SetString("brains", newSave);

        PlayerPrefs.SetInt("currentBrains", PlayerPrefs.GetInt("currentBrains") + 1);
        brain.GetComponent<SpriteRenderer>().sortingOrder = 99;
        brain.transform.DOMove( Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f,1)), 3 );
        brain.transform.DOScale(Vector3.one * 3, 3).OnComplete(() => { Application.LoadLevel(0); });
        Destroy(player);
    }

	public void RestartLevel()
	{
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
		Time.timeScale = 1;
		Application.LoadLevel(0);
	}

	bool soundActive = true;
	public void SwitchSound()
	{
		if( soundActive )
		{
			Camera.main.GetComponent<AudioSource>().mute = soundActive = false;
			soundButton.text = "Sound : OFF";
			PlayerPrefs.SetInt("Sound", 0);
		}
		else
		{
			Camera.main.GetComponent<AudioSource>().mute = soundActive = true;
			soundButton.text = "Sound : ON";
			PlayerPrefs.SetInt("Sound", 1);
		}
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
