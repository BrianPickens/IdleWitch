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

    private int currentUpgradeLevel;

    private float currentGatheredSouls;

    private DateTime lastCollection;

    public Action<int, Vector2> OnCollectSouls;

    [SerializeField] private List<SoulsObjectUpgrade> myUpgrades = new List<SoulsObjectUpgrade>();

    [SerializeField] private GameObject displayHolder;

    [SerializeField] private List<GameObject> upgradeLevelDisplays = new List<GameObject>();

    [SerializeField] private List<GameObject> fireDisplays = new List<GameObject>();

    [SerializeField] private GameObject destroyedDisplay;

    [SerializeField] private GameObject treesToClear;

    private void Update()
    {
        if (isBuilt)
        {
            UpdateSoulsGathered();
        }

        UpdateUI();
    }

    public override void InitializeBuiltAttraction()
    {
        base.InitializeBuiltAttraction();

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

        
        if (!isBuilt)//if we aren't already built, show the trees and make sure its all turned off
        {
            SetTreesActive(true);
            soulsDisplayHolder.SetActive(false);
            displayHolder.SetActive(false);
        }
        else
        {
            BuildAttractionFromLoading();
        }

    }

    public void BuildAttractionFromLoading()
    {
        SetTreesActive(false);
        soulsDisplayHolder.SetActive(true);
        displayHolder.SetActive(true);
        ShowUpgradeLevel(0);
        destroyedDisplay.SetActive(false);
    }

    public override void BuildAttraction(bool _rebuild)
    {
        base.BuildAttraction(_rebuild);
        SetTreesActive(false);
        soulsDisplayHolder.SetActive(true);
        displayHolder.SetActive(true);
        ShowUpgradeLevel(0);
        lastCollection = DateTime.Now;
        PlayerPrefsSavingLoading.Instance.SaveString(ConstantStrings.Instance.GetItemID(myItemType) + ConstantStrings.collectionTime, lastCollection.ToBinary().ToString());
    }

    public override void SetAttractionOnFire()
    {
        base.SetAttractionOnFire();
        fireDisplays[currentUpgradeLevel].SetActive(true);
    }

    public override void DestroyAttraction()
    {
        base.DestroyAttraction();
        fireDisplays[currentUpgradeLevel].SetActive(false);
        upgradeLevelDisplays[currentUpgradeLevel].SetActive(false);
        destroyedDisplay.SetActive(true);
    }

    private void SetTreesActive(bool _active)
    {
        if (treesToClear != null)
        {
            treesToClear.SetActive(_active);
        }
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

    //called from tapping a button in editor
    public void OnCollectButtonPressed()
    {
        if (onFire)
        {
            DestroyAttraction();
        }
        else if (isDestroyed)
        {
            //add UI for rebuild
        }
        else if (Mathf.FloorToInt(currentGatheredSouls) > 0)
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
        if (_upgradeLevel < currentUpgradeLevel)
        {
            return; //this lets us not have to worrry about load order when showing the attractions because the hightest upgrade will be shown.
        }

        for (int i = 0; i < upgradeLevelDisplays.Count; i++)
        {
            upgradeLevelDisplays[i].SetActive(false);
        }

        upgradeLevelDisplays[_upgradeLevel].SetActive(true);

        currentUpgradeLevel = _upgradeLevel;

    }

}
