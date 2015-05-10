using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

public class credits : MonoBehaviour 
{

    void Start()
    {

        transform.GetChild(0).gameObject.SetActive(false);
    }
    public void DisplayCredit()
    {
        Debug.Log("show credits");
        //transform.GetChild(0).GetComponent<RectTransform>().DOMoveY(135, 1f).SetEase(Ease.OutBounce);
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public void HideCredit()
    {
        Debug.Log("hide");
        //transform.GetChild(0).GetComponent<RectTransform>().DOMoveY(500, 1f).SetEase(Ease.InBack);
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
