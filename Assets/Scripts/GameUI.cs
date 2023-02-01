using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI totalSoulsDisplay;

    [SerializeField] private PurchaseConfirmation purchaseMenu;

    public void UpdateTotalSoulsDisplay(float _numSouls)
    {
        totalSoulsDisplay.text = Mathf.RoundToInt(_numSouls).ToString();
    }

    public PurchaseConfirmation GetPurchaseMenu()
    {
        return purchaseMenu;
    }

}
