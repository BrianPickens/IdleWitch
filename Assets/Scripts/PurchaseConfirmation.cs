using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PurchaseConfirmation : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI purchaseNameText;
    [SerializeField] private TextMeshProUGUI purchaseText;
    [SerializeField] private TextMeshProUGUI purchasePriceText;

    public Action OnConfirmPurchase;

    public void DisplayPurchase(PurchaseItemType _type, Action _purchaseCallback)
    {

    }
}
