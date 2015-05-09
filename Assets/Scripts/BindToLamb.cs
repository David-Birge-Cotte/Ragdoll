using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BindToLamb : MonoBehaviour {

    //public int SerialNumber;
	public Lamb LinkedObject;
    //bool playerIsChoosing = false;
    //int i;

	public Text inputTxt, placeHoler;


    /*public void PlayerClickedOnTheButton()
    {
        gameObject.GetComponentInChildren<Text>().text = "";
        playerIsChoosing = true;

	}*/

	void Start()
	{
		//Debug.Log( name );
		transform.SetParent(LinkedObject.transform, false);
		transform.localScale = new Vector3( 0.015f/LinkedObject.transform.localScale.x, 0.015f/LinkedObject.transform.localScale.y, 0.015f/LinkedObject.transform.localScale.z); ;
		placeHoler.text = LinkedObject.userKey;
		//Debug.Log("World to point" + Camera.main.WorldToScreenPoint(SelectedObject.transform.position));

		//GetComponent<RectTransform>().anchoredPosition = new Vector2(Camera.main.WorldToScreenPoint(SelectedObject.transform.position).x - ScreenWidth / 2, Camera.main.WorldToScreenPoint(SelectedObject.transform.position).y - ScreenHeight / 2);
		//Debug.Log("RectTransform" + (Binds[BindNumber].GetComponent<RectTransform>().anchoredPosition + new Vector2(ScreenWidth / 2, ScreenHeight / 2)));

		//Binds[BindNumber].GetComponent<BindToLamb>().SerialNumber = BindNumber;
	}

	public void KeyAsigned()
	{
		//if( (KeyCode)System.Enum.IsDefined(typeof(KeyCode), inputTxt.text.ToUpper() ) )
		if( inputTxt.text != "" )
			LinkedObject.userKey = inputTxt.text.ToLower();
		else
			LinkedObject.userKey = "a";
	}
}
