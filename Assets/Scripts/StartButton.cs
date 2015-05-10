using UnityEngine;
using System.Collections;
using DG.Tweening;

public class StartButton : MonoBehaviour 
{
	public GameObject player;
	public Vector3 startPos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadLevel()
	{
		transform.DOMoveX(2000, 1).SetEase(Ease.InBack);
        FindObjectsOfType<ButtonScript>()[0].transform.DOScale(Vector3.zero, 1).SetEase(Ease.OutBounce);
        FindObjectsOfType<ButtonScript>()[1].transform.DOScale(Vector3.zero, 1).SetEase(Ease.OutBounce);
        FindObjectsOfType<ButtonScript>()[2].transform.DOScale(Vector3.zero, 1).SetEase(Ease.OutBounce);
        GameObject.FindWithTag("Player").transform.DOKill();
        GameObject.FindWithTag("Player").transform.DOMoveY(-10, 1.0f).SetEase(Ease.InBack).OnStepComplete(goToNextLevel);
    }

	void goToNextLevel()
	{
		foreach( PivotScript ps in FindObjectsOfType<PivotScript>() )
		{
			ps.enabled = false;
			ps.GetComponent<SpriteRenderer>().enabled = false;
		}
		foreach( BindToLamb ps in FindObjectsOfType<BindToLamb>() )
		{
			ps.enabled = false;
			ps.GetComponent<Canvas>().enabled = false;
		}
		foreach( PivotTrigger pt in FindObjectsOfType<PivotTrigger>() )
			pt.enabled = false;
		foreach( LambsManager ps in FindObjectsOfType<LambsManager>() )
			ps.enabled = false;

        Application.LoadLevel(2);
	}
}
