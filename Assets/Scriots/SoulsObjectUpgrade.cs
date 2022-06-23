using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoulsObjectUpgrade : SoulsObjectBase
{
    [SerializeField] private float soulCapacityIncrease;
    [SerializeField] private float soulGatherTimeIncrease;
    [SerializeField] private float soulGatherAmountIncrease;

    [SerializeField] private SoulsObjectAttraction myBaseAttraction;
    [SerializeField] private int upgradeLevel;

    public float GetSoulCapacityIncrease()
    {
        return soulCapacityIncrease;
    }

    public float GetSoulGatherTimeIncrease()
    {
        return soulGatherTimeIncrease;
    }

    public float GetSoulGatherAmountIncrease()
    {
        return soulGatherAmountIncrease;
    }

    public override void BuildAttraction()
    {
        base.BuildAttraction();
        myBaseAttraction.ShowUpgradeLevel(upgradeLevel);
    }
}
