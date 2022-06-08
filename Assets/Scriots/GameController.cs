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

    private float totalSouls;

    private bool candyOut;

    private DateTime nextCandyRefreshTime;

    private DateTime lastSoulCollectionTime;

    private TimeSpan currentCandyTimeSpan;


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

        LoadData();

    }

    private void InitializeActions()
    {
        gameUI.OnCollectPressed = CollectGatheredSouls;
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

    private void CollectGatheredSouls()
    {
        if (currentGatheredSouls > 0f)
        {
            totalSouls += currentGatheredSouls;
            currentGatheredSouls = 0f;
            lastSoulCollectionTime = DateTime.Now;
        }
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
}
