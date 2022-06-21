using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameController : MonoBehaviour
{

    [SerializeField] private GameUI gameUI;

    [SerializeField] private float baseCandyDuration;//in seconds;

    private int totalSouls;

    private bool candyOut;

    private DateTime nextCandyRefreshTime;

    private TimeSpan currentCandyTimeSpan;

    [SerializeField] private List<SoulsObject> allAttractions = new List<SoulsObject>();

    [SerializeField] private Menu constructionMenu;
    [SerializeField] private Menu detectionMenu;
    [SerializeField] private Menu offersMenu;

    private void Start()
    {

        InitializeActions();

        InitializeAttractions();

        InitializeMenus();

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

    private void InitializeMenus()
    {
        constructionMenu.InitializeMenu(OnPurchase);
        detectionMenu.InitializeMenu(OnPurchase);
        offersMenu.InitializeMenu(OnPurchase);
    }

    private void Update()
    {
        RunCandyTimer();
        UpdateUI();
    }

    private void LoadData()
    {
        totalSouls = PlayerPrefsSavingLoading.Instance.LoadInt(ConstantStrings.totalSouls);
    }

    private void CollectGatheredSouls(int _numSouls)
    {
        totalSouls += _numSouls;
        PlayerPrefsSavingLoading.Instance.SaveInt(ConstantStrings.totalSouls, totalSouls);
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
        gameUI.UpdateCandyOutDisplay(candyOut, currentCandyTimeSpan.Hours, currentCandyTimeSpan.Minutes, currentCandyTimeSpan.Seconds);
        constructionMenu.UpdateButtons(totalSouls);
        detectionMenu.UpdateButtons(totalSouls);
        offersMenu.UpdateButtons(totalSouls);
    }

    private void OnPurchase(int _purchasePrice, string _ID)
    {
        totalSouls -= _purchasePrice;
        for (int i = 0; i < allAttractions.Count; i++)
        {
            if (allAttractions[i].GetID() == _ID)
            {
                allAttractions[i].BuildAttraction();
                break;
            }
        }
    }


    //debug
    public void ClearData()
    {
        PlayerPrefsSavingLoading.Instance.DeleteAllKeys();
    }
}
