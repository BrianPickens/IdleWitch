using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour
{
    private bool animating;

    [SerializeField] private Animator myAnimator;

    public void OpenMenu()
    {
        animating = true;
        myAnimator.SetTrigger("Open");
    }

    public void CloseMenu()
    {
        animating = true;
        myAnimator.SetTrigger("Close");
    }


    public void FinishedAnimating()
    {
        animating = false;
    }

    public bool IsAnimating()
    {
        return animating;
    }

}
