using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class resetButton : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void ResetStats()
    {
        PlayerPrefs.DeleteAll();
        Destroy(GameObject.FindWithTag("Player"));
        Application.LoadLevel(Application.loadedLevel);
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
