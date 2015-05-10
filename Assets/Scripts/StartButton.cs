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
        AnimStartButton();
        AnimLimbButton();
        AnimPlayer();
    }

    void AnimStartButton()
    {
        transform.DOMoveY(-150, 3).SetEase(Ease.OutCubic).OnStepComplete(goToNextLevel);
    }
    void AnimLimbButton()
    {
        FindObjectsOfType<ButtonScript>()[0].transform.DOScale(Vector3.zero, 1).SetEase(Ease.OutBounce);
        FindObjectsOfType<ButtonScript>()[1].transform.DOScale(Vector3.zero, 1).SetEase(Ease.OutBounce);
        FindObjectsOfType<ButtonScript>()[2].transform.DOScale(Vector3.zero, 1).SetEase(Ease.OutBounce);
    }
    void AnimPlayer()
    {
        GameObject.FindWithTag("Player").transform.DOKill();
        GameObject.FindWithTag("Player").transform.DOMoveY(10, 1.0f).SetEase(Ease.InBack);
    }

	void goToNextLevel()
	{
		foreach( PivotScript ps in FindObjectsOfType<PivotScript>() )
		{
			if( ps.GetComponent<SpriteRenderer>().enabled )
				ps.GetComponent<SpriteRenderer>().enabled = false;
			else
				ps.isDisable = true;
			ps.enabled = false;
		}
		foreach( BindToLamb ps in FindObjectsOfType<BindToLamb>() )
		{
			ps.enabled = false;
			ps.GetComponent<Canvas>().enabled = false;
		}
		foreach( PivotTrigger pt in FindObjectsOfType<PivotTrigger>() )
			Destroy( pt );
		foreach( LambsManager ps in FindObjectsOfType<LambsManager>() )
			ps.enabled = false;

        Application.LoadLevel(2);
	}
}
