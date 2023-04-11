using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public enum PurchaseButtonType { Contruction, Detection, Offer }

public class PurchaseButton : MonoBehaviour
{

    private bool isBuilt;
    private bool isOnFire;
    private bool isDestroyed;

    [SerializeField] private PurchaseButtonType myButtonType;
    [SerializeField] private PurchaseItemType myItemType;

    private PurchaseConfirmation purchaseConfirmationMenu;

    private int purchasePrice;

    [SerializeField] private Button myButton;

    [SerializeField] private TextMeshProUGUI displayText;
    [SerializeField] private TextMeshProUGUI requirementText;

    [SerializeField] private List<PurchaseButton> prerequisites = new List<PurchaseButton>();

    public Action<int, string> OnPurchaseMade;

    public void Initialize(Action<int, string> _purchaseCallback, PurchaseConfirmation _purchaseConfirmationMenu)
    {

        purchaseConfirmationMenu = _purchaseConfirmationMenu;

        purchasePrice = ConstantStrings.Instance.GetItemPrice(myItemType);

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
        isOnFire = PlayerPrefsSavingLoading.Instance.LoadBool(ConstantStrings.Instance.GetItemID(myItemType) + ConstantStrings.onFire);
        isDestroyed = PlayerPrefsSavingLoading.Instance.LoadBool(ConstantStrings.Instance.GetItemID(myItemType) + ConstantStrings.destroyed);

        if (myButtonType == PurchaseButtonType.Contruction || myButtonType == PurchaseButtonType.Detection)
        {
            if (isBuilt)
            {
                myButton.interactable = false;
                displayText.text = ConstantStrings.Instance.GetDisplayName(myItemType);
                requirementText.text = "Purchased!";
            }
            else if (!isBuilt && _currentSouls >= purchasePrice && PrerequisitesBuilt())
            {
                myButton.interactable = true;
                displayText.text = ConstantStrings.Instance.GetDisplayName(myItemType);
                requirementText.text = purchasePrice.ToString();
            }
            else if (!isBuilt && _currentSouls >= purchasePrice && !PrerequisitesBuilt())
            {
                myButton.interactable = false;
                displayText.text = ConstantStrings.Instance.GetDisplayName(myItemType);
                requirementText.text = "Requires: " + GetPrerequisiteName();
            }
            else if (!isBuilt && _currentSouls < purchasePrice && PrerequisitesBuilt())
            {
                myButton.interactable = false;
                displayText.text = ConstantStrings.Instance.GetDisplayName(myItemType);
                requirementText.text = purchasePrice.ToString();
            }
            else if (!isBuilt && _currentSouls < purchasePrice && !PrerequisitesBuilt())
            {
                myButton.interactable = false;
                displayText.text = ConstantStrings.Instance.GetDisplayName(myItemType);
                requirementText.text = "Requires: " + GetPrerequisiteName();
            }
            else
            {
                myButton.interactable = false;
                displayText.text = ConstantStrings.Instance.GetDisplayName(myItemType);
                requirementText.text = purchasePrice.ToString();
            }

            if (!isBuilt && IsPrerequisiteOnFire())
            {
                myButton.interactable = false;
                displayText.text = ConstantStrings.Instance.GetDisplayName(myItemType);
                requirementText.text = "Put Out Fire!";
            }
            else if (!isBuilt && IsPrerequisiteDestroyed())
            {
                myButton.interactable = false;
                displayText.text = ConstantStrings.Instance.GetDisplayName(myItemType);
                requirementText.text = "Rebuild First!";
            }
        }
        else if (myButtonType == PurchaseButtonType.Offer)
        {
            bool isAvailable = PlayerPrefsSavingLoading.Instance.LoadBool(ConstantStrings.Instance.GetItemID(myItemType) + ConstantStrings.available);
            gameObject.SetActive(isAvailable);
            
            if (isBuilt)
            {
                myButton.interactable = false;
                displayText.text = ConstantStrings.Instance.GetDisplayName(myItemType);
                requirementText.text = "Purchased!";
            }
            else
            {
                myButton.interactable = true;
                displayText.text = ConstantStrings.Instance.GetDisplayName(myItemType);
                requirementText.text = "";
            }
        }

    }

    public void OnClick()
    {
        if (myButtonType == PurchaseButtonType.Contruction || myButtonType == PurchaseButtonType.Detection)
        {
            purchaseConfirmationMenu.DisplayPurchase(myItemType, OnPurchasePressed);
        }
        else if (myButtonType == PurchaseButtonType.Offer)
        {
            purchaseConfirmationMenu.DisplayOfferPurchase(myItemType, OnPurchasePressed);
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

    private bool IsPrerequisiteOnFire()
    {
        bool prerequisiteOnFire = false;
        for (int i = 0; i < prerequisites.Count; i++)
        {
            if (prerequisites[i].IsOnFire())
            {
                prerequisiteOnFire = true;
            }
        }

        return prerequisiteOnFire;
    }

    private bool IsPrerequisiteDestroyed()
    {
        bool prerequisiteDestroyed = false;
        for (int i = 0; i < prerequisites.Count; i++)
        {
            if (prerequisites[i].IsDestroyed())
            {
                prerequisiteDestroyed = true;
            }
        }

        return prerequisiteDestroyed;
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

    public bool IsOnFire()
    {
        return isOnFire;
    }

    public bool IsDestroyed()
    {
        return isDestroyed;
    }
    public string GetDisplayName()
    {
        return ConstantStrings.Instance.GetDisplayName(myItemType);
    }

}
