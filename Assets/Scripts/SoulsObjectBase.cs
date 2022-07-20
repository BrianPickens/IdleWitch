using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class SoulsObjectBase : MonoBehaviour
{
    protected bool isBuilt;

    [SerializeField] protected PurchaseItemType myItemType;

    [SerializeField] private bool startBuilt;

    public virtual void Initialize()
    {
        isBuilt = PlayerPrefsSavingLoading.Instance.LoadBool(ConstantStrings.Instance.GetItemID(myItemType) + ConstantStrings.built);

        if (!isBuilt && startBuilt)
        {
            BuildAttraction();
        }
        else if (!isBuilt)
        {
            
        }
    }

    public virtual void BuildAttraction()
    {
        Debug.LogError(ConstantStrings.Instance.GetDisplayName(myItemType) + "Built");

        isBuilt = true;
        PlayerPrefsSavingLoading.Instance.SaveBool(ConstantStrings.Instance.GetItemID(myItemType) + ConstantStrings.built, true);

    }

    public string GetID()
    {
        return ConstantStrings.Instance.GetItemID(myItemType);
    }

    public bool IsBuilt()
    {
        return isBuilt;
    }
}
