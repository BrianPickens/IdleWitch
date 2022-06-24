using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PurchaseButton : MonoBehaviour
{

    private bool isBuilt;

    [SerializeField] private PurchaseItemType myItemType;

    [SerializeField] private int purchasePrice;

    [SerializeField] private Button myButton;

    [SerializeField] private TextMeshProUGUI displayText;

    [SerializeField] private List<PurchaseButton> prerequisites = new List<PurchaseButton>();

    public Action<int, string> OnPurchaseMade;

    public void Initialize(Action<int, string> _purchaseCallback)
    {
        OnPurchaseMade = _purchaseCallback;

        isBuilt = PlayerPrefsSavingLoading.Instance.LoadBool(ConstantStrings.Instance.GetItemID(myItemType) + ConstantStrings.built);

        if (isBuilt)
        {
            myButton.interactable = false;
        }
        else
        {
            myButton.interactable = true;
        }

    }

    public void UpdateUI(int _currentSouls)
    {
        if (isBuilt)
        {
            myButton.interactable = false;
            displayText.text = ConstantStrings.Instance.GetDisplayName(myItemType) + " - " + "Purchased!";
        }
        else if (!isBuilt && _currentSouls >= purchasePrice && PrerequisitesBuilt())
        {
            myButton.interactable = true;
            displayText.text = ConstantStrings.Instance.GetDisplayName(myItemType) + " - " + purchasePrice;
        }
        else if (!isBuilt && _currentSouls >= purchasePrice && !PrerequisitesBuilt())
        {
            myButton.interactable = false;
            displayText.text = ConstantStrings.Instance.GetDisplayName(myItemType) + " - " + "requires: " + GetPrerequisiteName();
        }
        else if (!isBuilt && _currentSouls < purchasePrice && PrerequisitesBuilt())
        {
            myButton.interactable = false;
            displayText.text = ConstantStrings.Instance.GetDisplayName(myItemType) + " - " + purchasePrice;
        }
        else if (!isBuilt && _currentSouls < purchasePrice && !PrerequisitesBuilt())
        {
            myButton.interactable = false;
            displayText.text = ConstantStrings.Instance.GetDisplayName(myItemType) + " - " + "requires: " + GetPrerequisiteName();
        }
        else
        {
            myButton.interactable = false;
            displayText.text = ConstantStrings.Instance.GetDisplayName(myItemType) + " - " + purchasePrice;
        }
    }

    public void OnPurchasePressed()
    {
        OnPurchaseMade?.Invoke(purchasePrice, ConstantStrings.Instance.GetItemID(myItemType));
        isBuilt = true;
        myButton.interactable = false;

    }

    private bool PrerequisitesBuilt()
    {
        bool prerequisitesBuilt = true;

        for (int i = 0; i < prerequisites.Count; i++)
        {
            if (!prerequisites[i].IsBuilt())
            {
                prerequisitesBuilt = false;
            }
        }

        return prerequisitesBuilt;
    }

    private string GetPrerequisiteName()
    {
        string preReqName = "";
        for (int i = 0; i < prerequisites.Count; i++)
        {
            if (!prerequisites[i].IsBuilt())
            {
                preReqName = prerequisites[i].GetDisplayName();
                break;
            }
        }
        return preReqName;
    }

    public bool IsBuilt()
    {
        return isBuilt;
    }

    public string GetDisplayName()
    {
        return ConstantStrings.Instance.GetDisplayName(myItemType);
    }

}
