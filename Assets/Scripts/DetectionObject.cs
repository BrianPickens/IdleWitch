using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionObject : MonoBehaviour
{
    private bool isBuilt;

    [SerializeField] private PurchaseItemType myItemType;

    public void InitializeBuildDetection()
    {
        isBuilt = PlayerPrefsSavingLoading.Instance.LoadBool(ConstantStrings.Instance.GetItemID(myItemType) + ConstantStrings.built);
        if (isBuilt)
        {
            BuildDetection();
        }
    }

    public void BuildDetection()
    {
        isBuilt = true;
        PlayerPrefsSavingLoading.Instance.SaveBool(ConstantStrings.Instance.GetItemID(myItemType) + ConstantStrings.built, true);
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
}
