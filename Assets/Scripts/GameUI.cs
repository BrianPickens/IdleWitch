using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameUI : MonoBehaviour
{
    [SerializeField] private PurchaseConfirmation purchaseMenu;

    [SerializeField] private SoulsHolder soulsHolder;
    public void UpdateTotalSoulsDisplay(float _numSouls)
    {
        soulsHolder.UpdateSouls(_numSouls);
    }

    public PurchaseConfirmation GetPurchaseMenu()
    {
        return purchaseMenu;
    }

}
