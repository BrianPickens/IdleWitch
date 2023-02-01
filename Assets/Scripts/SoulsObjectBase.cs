using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class SoulsObjectBase : MonoBehaviour
{
    protected bool isBuilt;
    protected bool onFire;
    protected bool isDestroyed;

    [SerializeField] protected PurchaseItemType myItemType;

    [SerializeField] private bool startBuilt;

    protected PurchaseConfirmation purchaseMenu;

    protected Action<int, string> rebuildCallback;

    public virtual void InitializeBuiltAttraction()
    {
        isBuilt = PlayerPrefsSavingLoading.Instance.LoadBool(ConstantStrings.Instance.GetItemID(myItemType) + ConstantStrings.built);

        if (!isBuilt && startBuilt)
        {
            BuildAttraction();
        }
    }

    public virtual void InitializeOnFireAttraction()
    {
        onFire = PlayerPrefsSavingLoading.Instance.LoadBool(ConstantStrings.Instance.GetItemID(myItemType) + ConstantStrings.onFire);
        if (onFire)
        {
            SetAttractionOnFire();
        }
    }

    public virtual void InitializeDestroyedAttraction()
    {
        isDestroyed = PlayerPrefsSavingLoading.Instance.LoadBool(ConstantStrings.Instance.GetItemID(myItemType) + ConstantStrings.destroyed);
        if (isDestroyed)
        {
            DestroyAttraction();
        }
    }

    public virtual void InitializeRebuild(Action<int, string> _rebuildCallback, PurchaseConfirmation _purchaseMenu)
    {
        rebuildCallback = _rebuildCallback;
        purchaseMenu = _purchaseMenu;
    }

    public virtual void BuildAttraction()
    {
        isBuilt = true;
        PlayerPrefsSavingLoading.Instance.SaveBool(ConstantStrings.Instance.GetItemID(myItemType) + ConstantStrings.built, true);
    }

    public virtual void RebuildAttraction()
    {
        PlayerPrefsSavingLoading.Instance.SaveBool(ConstantStrings.Instance.GetItemID(myItemType) + ConstantStrings.destroyed, false);

    }

    public virtual void SetAttractionOnFire()
    {
        Debug.LogError(ConstantStrings.Instance.GetDisplayName(myItemType) + " on Fire");

        onFire = true;

        PlayerPrefsSavingLoading.Instance.SaveBool(ConstantStrings.Instance.GetItemID(myItemType) + ConstantStrings.onFire, true);
    }

    public virtual void DestroyAttraction()
    {
        Debug.LogError(ConstantStrings.Instance.GetDisplayName(myItemType) + "Destroyed");
        isDestroyed = true;
        onFire = false;
        PlayerPrefsSavingLoading.Instance.SaveBool(ConstantStrings.Instance.GetItemID(myItemType) + ConstantStrings.onFire, false);
        PlayerPrefsSavingLoading.Instance.SaveBool(ConstantStrings.Instance.GetItemID(myItemType) + ConstantStrings.destroyed, true);
    }

    public string GetID()
    {
        return ConstantStrings.Instance.GetItemID(myItemType);
    }

    public bool IsBuilt()
    {
        return isBuilt;
    }

    public bool IsOnFire()
    {
        return onFire;
    }

    public bool IsDestroyed()
    {
        return isDestroyed;
    }

    public PurchaseItemType GetItemType()
    {
        return myItemType;
    }
}
