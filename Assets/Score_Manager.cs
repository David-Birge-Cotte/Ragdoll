using UnityEngine;
using System.Collections;

public class Score_Manager : MonoBehaviour {

    public int _numberOfADN ;
    public int _collectedADN;
    public int _numberOfBrains;
    public int _brainsCollected;
    GameObject[] ADNArray;

    public GameObject[] BrainsArray;

    public GameObject EmptyADNPrefab;
    Vector3 ScreenCenter;
    Vector3 scale;


	// Use this for initialization
	void Start () {

	ADNArray = new GameObject[_numberOfADN];
    int SquaredArrayNumber = Mathf.CeilToInt(Mathf.Sqrt(_numberOfADN));
       // ScreenCenter = (Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)))/2;
        scale = new Vector3(0.5f, 0.5f, 1);
    for (int y = 0; y < SquaredArrayNumber; y++)
    {
        for (int x = 0; x < SquaredArrayNumber; x++)
        {
            
            if ((y * SquaredArrayNumber + x )< _numberOfADN){
            ADNArray[y * SquaredArrayNumber + x] = Instantiate(EmptyADNPrefab);
            ADNArray[y * SquaredArrayNumber + x].transform.position = /*ScreenCenter +*/ (new Vector3(x +0.5f, SquaredArrayNumber / 2f, 0) - new Vector3(SquaredArrayNumber / 2f, y +0.5f, 0)) * ((float)scale.x * 1.5f);
            //ADNArray[y * SquaredArrayNumber + x].transform.localScale = new Vector3(0.5f, 0.5f, 1);
            if (y * SquaredArrayNumber + x < _collectedADN)
            {
                ADNArray[y * SquaredArrayNumber + x].GetComponent<SpriteRenderer>().color = Color.white;
            }
            else
            {
                ADNArray[y * SquaredArrayNumber + x].GetComponent<SpriteRenderer>().color = Color.grey;
            }
            }
        }
    }

    for (int i = 0; i < _numberOfBrains; i++)
    {
        if (i < _brainsCollected)
        {
            
            BrainsArray[i].GetComponent<SpriteRenderer>().color = Color.white;
        }
        else
        {
            
            BrainsArray[i].GetComponent<SpriteRenderer>().color = Color.grey;
        } 
        
    }

	}

 
	
	// Update is called once per frame
	void Update () {
	
	}
}
