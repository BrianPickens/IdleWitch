using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameController : MonoBehaviour
{

    [SerializeField] private GameUI gameUI;

    private int totalSouls;

    [SerializeField] private List<SoulsObjectBase> allAttractions = new List<SoulsObjectBase>();

    [SerializeField] private Menus allMenus;


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
        foreach (SoulsObjectBase attraction in allAttractions)
        {
            if (attraction.GetComponent<SoulsObjectAttraction>() != null)
            {
                attraction.GetComponent<SoulsObjectAttraction>().OnCollectSouls = CollectGatheredSouls;
            }
            
        }
    }

    private void InitializeMenus()
    {
        allMenus.InitializeMenus(OnPurchase);
    }

    private void Update()
    {
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

    private void UpdateUI()
    {
        gameUI.UpdateTotalSoulsDisplay(totalSouls);
        allMenus.UpdateButtons(totalSouls);
    }

    private void OnPurchase(int _purchasePrice, string _ID)
    {
        totalSouls -= _purchasePrice;
        PlayerPrefsSavingLoading.Instance.SaveInt(ConstantStrings.totalSouls, totalSouls);
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
