using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Menu : MonoBehaviour
{
    private bool animating;

    [SerializeField] private Animator myAnimator;

    [SerializeField] private List<PurchaseButton> purchaseButtons = new List<PurchaseButton>();

    public void InitializeMenu(Action<int, string> _purchaseCallback, PurchaseConfirmation _purchaseConfirmationMenu)
    {
        for (int i = 0; i < purchaseButtons.Count; i++)
        {
            purchaseButtons[i].Initialize(_purchaseCallback, _purchaseConfirmationMenu);
        }
    }

    public void UpdateButtons(int _currentSouls)
    {
        for (int i = 0; i < purchaseButtons.Count; i++)
        {
            purchaseButtons[i].UpdateUI(_currentSouls);
        }
    }

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
