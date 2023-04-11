using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffersObject : MonoBehaviour
{

    private bool isBuilt;
    [SerializeField] private PurchaseItemType myItemType;

    public void InitializeOfferTaken()
    {
        isBuilt = PlayerPrefsSavingLoading.Instance.LoadBool(ConstantStrings.Instance.GetItemID(myItemType) + ConstantStrings.built);
        if (isBuilt)
        {
            TakeOffer();
        }
    }

    public void TakeOffer()
    {
        isBuilt = true;
        PlayerPrefsSavingLoading.Instance.SaveBool(ConstantStrings.Instance.GetItemID(myItemType) + ConstantStrings.built, true);
    }

    public void SetOfferAvailableInStore()
    {
        PlayerPrefsSavingLoading.Instance.SaveBool(ConstantStrings.Instance.GetItemID(myItemType) + ConstantStrings.available, true);
    }

    public string GetID()
    {
        return ConstantStrings.Instance.GetItemID(myItemType);
    }

    public PurchaseItemType GetItemType()
    {
        return myItemType;
    }

    public bool IsBuilt()
    {
        return isBuilt;
    }

    public bool IsAvailableInStore()
    {
        return PlayerPrefsSavingLoading.Instance.LoadBool(ConstantStrings.Instance.GetItemID(myItemType) + ConstantStrings.available);
    }

}
