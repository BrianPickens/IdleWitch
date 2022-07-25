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
        purchaseNameText.text = ConstantStrings.Instance.GetDisplayName(_type);
        purchasePriceText.text = ConstantStrings.Instance.GetItemPrice(_type).ToString() + " Souls";
        purchaseText.text = ConstantStrings.Instance.GetDisplayDescription(_type);
        OnConfirmPurchase = _purchaseCallback;
        gameObject.SetActive(true);
    }

    public void CloseMenu()
    {
        gameObject.SetActive(false);
    }

    public void ConfirmPurchase()
    {
        OnConfirmPurchase?.Invoke();
        CloseMenu();
    }

    public void CancelPurchase()
    {
        CloseMenu();
    }

}
