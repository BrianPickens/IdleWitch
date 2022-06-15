using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameController : MonoBehaviour
{

    [SerializeField] private GameUI gameUI;

    [SerializeField] private float baseSoulGatherTimer;
    [SerializeField] private float baseSoulGatherAmount;
    [SerializeField] private float baseSoulCapacity;

    [SerializeField] private float baseCandyDuration;//in seconds;
        
    private float currentGatheredSouls;
    private float currentSoulCapacity;

    private float currentSoulGatherAmount;

    private float currentSoulGatherTimer;

    private float soulGatherTimer;

    private float currentCandyDuration;

    private int totalSouls;

    private bool candyOut;

    private DateTime nextCandyRefreshTime;

    private DateTime lastSoulCollectionTime;

    private TimeSpan currentCandyTimeSpan;

    [SerializeField] private List<SoulsObject> allAttractions = new List<SoulsObject>();


    private void Start()
    {



        //
        currentSoulCapacity = baseSoulCapacity;
        currentSoulGatherAmount = baseSoulGatherAmount;
        currentSoulGatherTimer = baseSoulGatherTimer;
        soulGatherTimer = currentSoulGatherTimer;
        currentCandyDuration = baseCandyDuration;
        //

        InitializeActions();

        InitializeAttractions();

        LoadData();

    }

    private void InitializeAttractions()
    {
        for (int i = 0; i < allAttractions.Count; i++)
        {
            allAttractions[i].Initialize();
        }
    }

    private void InitializeActions()
    {
        for (int i = 0; i < allAttractions.Count; i++)
        {
            allAttractions[i].OnCollectSouls = CollectGatheredSouls;
        }

        gameUI.OnCandyPressed = RefreshCandy;
    }

    private void Update()
    {

        RunSoulGatherTimer();
        RunCandyTimer();
        UpdateUI();


    }

    private void LoadData()
    {
        totalSouls = PlayerPrefsSavingLoading.Instance.LoadInt(ConstantStrings.totalSouls);
    }

    private void RunSoulGatherTimer()
    {
        if (candyOut)
        {
            soulGatherTimer -= Time.deltaTime;
            if (soulGatherTimer <= 0f)
            {
                GatherSouls();
                soulGatherTimer = currentSoulGatherTimer;
            }
        }
        else
        {
            soulGatherTimer = currentSoulGatherTimer;
        }

    }

    private void GatherSouls()
    {
        currentGatheredSouls += currentSoulGatherAmount;
        if (currentGatheredSouls > currentSoulCapacity)
        {
            currentGatheredSouls = currentSoulCapacity;
        }
    }

    private void CollectGatheredSouls(int _numSouls)
    {
        totalSouls += _numSouls;
        PlayerPrefsSavingLoading.Instance.SaveInt(ConstantStrings.totalSouls, totalSouls);

        //if (currentGatheredSouls > 0f)
        //{
        //    totalSouls += currentGatheredSouls;
        //    currentGatheredSouls = 0f;
        //    lastSoulCollectionTime = DateTime.Now;
        //}
    }

    private void RefreshCandy()
    {
        if (!candyOut)
        {
            DateTime nextRefresh = DateTime.Now;
            nextRefresh = nextRefresh.AddSeconds(baseCandyDuration);
            nextCandyRefreshTime = nextRefresh;
            candyOut = true;
        }
        
    }

    private void RunCandyTimer()
    {
        currentCandyTimeSpan = nextCandyRefreshTime - DateTime.Now;
        if (currentCandyTimeSpan.Seconds < 0)
        {
            candyOut = false;
        }
    }


    private void UpdateUI()
    {
        gameUI.UpdateTotalSoulsDisplay(totalSouls);
        gameUI.UpdateGatherableSoulsDiplay(currentGatheredSouls, currentSoulCapacity);
        gameUI.UpdateCandyOutDisplay(candyOut, currentCandyTimeSpan.Hours, currentCandyTimeSpan.Minutes, currentCandyTimeSpan.Seconds);

    }


    //debug
    public void ClearData()
    {
        PlayerPrefsSavingLoading.Instance.DeleteAllKeys();
    }
}
