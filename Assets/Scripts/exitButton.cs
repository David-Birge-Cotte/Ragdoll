using UnityEngine;
using System.Collections;
using DG.Tweening;

public class exitButton : MonoBehaviour 
{


    public void FunnyMove()
    {
        transform.parent.localRotation = Quaternion.Euler( new Vector3(0, 0, 90) );
        transform.parent.DOLocalRotate(new Vector3(0,0,45), 1f).SetEase(Ease.OutElastic);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
