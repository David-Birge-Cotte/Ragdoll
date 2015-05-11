using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class resetButton : MonoBehaviour 
{
	public Parts_GUI_Manager_Script UIManager;

	// Use this for initialization
	void Start () 
    {
		if ( !UIManager )
		{
			Debug.LogError("reset button need UIManager");
		}
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void ResetStats()
    {
        //PlayerPrefs.DeleteAll();
		Destroy(GameObject.FindWithTag("Player"));
		UIManager.GeneratePlayer();
        //Application.LoadLevel(Application.loadedLevel);
    }

    public void TurnToRed()
    {
        GetComponentInChildren<Text>().DOColor(Color.red, 0.5f);
    }
    public void TurnToWhite()
    {
        GetComponentInChildren<Text>().DOColor(Color.white, 2f);
    }
}
