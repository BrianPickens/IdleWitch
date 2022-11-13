using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;


public class SoulsObjectAttraction : SoulsObjectBase
{

    [SerializeField] private float soulCapacity;
    [SerializeField] private float soulGatherTime;
    [SerializeField] private float soulGatherAmount;

    [SerializeField] private GameObject soulsDisplayHolder;

    [SerializeField] private TextMeshProUGUI soulsDisplay;

    private float currentGatheredSouls;

    private DateTime lastCollection;

    public Action<int, Vector2> OnCollectSouls;

    [SerializeField] private List<SoulsObjectUpgrade> myUpgrades = new List<SoulsObjectUpgrade>();

    [SerializeField] private GameObject displayHolder;

    [SerializeField] private List<GameObject> upgradeLevelDisplays = new List<GameObject>();

    [SerializeField] private GameObject treesToClear;

    private void Update()
    {
        if (isBuilt)
        {
            UpdateSoulsGathered();
        }

        UpdateUI();
    }

    public override void Initialize()
    {
        base.Initialize();

        if (PlayerPrefsSavingLoading.Instance.LoadString(ConstantStrings.Instance.GetItemID(myItemType) + ConstantStrings.collectionTime) != string.Empty)
        {
            long temp = Convert.ToInt64(PlayerPrefsSavingLoading.Instance.LoadString(ConstantStrings.Instance.GetItemID(myItemType) + ConstantStrings.collectionTime));
            lastCollection = DateTime.FromBinary(temp);
        }
        else
        {
            lastCollection = DateTime.Now;
            PlayerPrefsSavingLoading.Instance.SaveString(ConstantStrings.Instance.GetItemID(myItemType) + ConstantStrings.collectionTime, lastCollection.ToBinary().ToString());

        }

        if (!isBuilt)
        {
            treesToClear.SetActive(true);
            soulsDisplayHolder.SetActive(false);
            displayHolder.SetActive(false);
        }
        else
        {
            ClearTrees();
            soulsDisplayHolder.SetActive(true);
            displayHolder.SetActive(true);
        }

    }

    public override void BuildAttraction()
    {
        base.BuildAttraction();
        ClearTrees();
        soulsDisplayHolder.SetActive(true);
        displayHolder.SetActive(true);
        ShowUpgradeLevel(0);
        lastCollection = DateTime.Now;
        PlayerPrefsSavingLoading.Instance.SaveString(ConstantStrings.Instance.GetItemID(myItemType) + ConstantStrings.collectionTime, lastCollection.ToBinary().ToString());

    }

    private void ClearTrees()
    {
        treesToClear.SetActive(false);
    }

    private void UpdateSoulsGathered()
    {

        DateTime currentTime = DateTime.Now;
        TimeSpan timeSinceLastCollection = currentTime - lastCollection;

        double numSecondsSinceLastCollection = 0f;
        if (timeSinceLastCollection.TotalSeconds > double.MaxValue || timeSinceLastCollection.TotalSeconds < 0f)
        {
            numSecondsSinceLastCollection = double.MaxValue;
        }
        else
        {
            numSecondsSinceLastCollection = timeSinceLastCollection.TotalSeconds;
        }

        if (numSecondsSinceLastCollection / (soulGatherTime-GetGatherTimeUpgradeAmount()) * (soulGatherAmount+GetGatherAmountUpgradeAmount()) > (soulCapacity+GetCapacityUpgradeAmount()))
        {
            currentGatheredSouls = (soulCapacity+GetCapacityUpgradeAmount());
        }
        else
        {
            currentGatheredSouls = (float)(numSecondsSinceLastCollection / (soulGatherTime - GetGatherTimeUpgradeAmount()) * (soulGatherAmount + GetGatherAmountUpgradeAmount()));
        }

    }

    private void UpdateUI()
    {
        soulsDisplay.text = Mathf.FloorToInt(currentGatheredSouls).ToString() + "/" + (soulCapacity+GetCapacityUpgradeAmount()).ToString();
    }

    public void OnCollectButtonPressed()
    {
        if (Mathf.FloorToInt(currentGatheredSouls) > 0)
        {
            OnCollectSouls?.Invoke(Mathf.FloorToInt(currentGatheredSouls), transform.position);
            currentGatheredSouls = 0f;
            lastCollection = DateTime.Now;
            PlayerPrefsSavingLoading.Instance.SaveString(ConstantStrings.Instance.GetItemID(myItemType) + ConstantStrings.collectionTime, lastCollection.ToBinary().ToString());
        }
        else
        {
            //nothign to gather
        }

    }

    private float GetCapacityUpgradeAmount()
    {
        float capacityUpgrade = 0f;
        for (int i = 0; i < myUpgrades.Count; i++)
        {
            if (myUpgrades[i].IsBuilt())
            {
                capacityUpgrade += myUpgrades[i].GetSoulCapacityIncrease();
            }
        }
        return capacityUpgrade;
    }

    private float GetGatherTimeUpgradeAmount()
    {
        float gatherTimeUpgrade = 0f;
        for (int i = 0; i < myUpgrades.Count; i++)
        {
            if (myUpgrades[i].IsBuilt())
            {
                gatherTimeUpgrade += myUpgrades[i].GetSoulGatherTimeIncrease();
            }
        }
        return gatherTimeUpgrade;
    }

    private float GetGatherAmountUpgradeAmount()
    {
        float gatherAmountUpgrade = 0f;
        for (int i = 0; i < myUpgrades.Count; i++)
        {
            if (myUpgrades[i].IsBuilt())
            {
                gatherAmountUpgrade += myUpgrades[i].GetSoulGatherAmountIncrease();
            }
        }
        return gatherAmountUpgrade;
    }

    public void ShowUpgradeLevel(int _upgradeLevel)
    {
        for (int i = 0; i < upgradeLevelDisplays.Count; i++)
        {
            upgradeLevelDisplays[i].SetActive(false);
        }

        upgradeLevelDisplays[_upgradeLevel].SetActive(true);

    }

}
