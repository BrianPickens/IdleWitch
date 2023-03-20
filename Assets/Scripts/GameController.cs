using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameController : MonoBehaviour
{

    [SerializeField] private GameUI gameUI;

    private int totalSouls;

    [SerializeField] private List<SoulsObjectBase> allAttractions = new List<SoulsObjectBase>();
    [SerializeField] private List<SoulsObjectBase> baseAttractions = new List<SoulsObjectBase>();

    [SerializeField] private Menus allMenus;

    [SerializeField] private SoulsCreator soulsCreator;
    [SerializeField] private RectTransform soulsTarget;

    //test
    private float currentFireTimer;
    //end test


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
            allAttractions[i].InitializeBuiltAttraction();
        }

        for (int i = 0; i < allAttractions.Count; i++)
        {
            allAttractions[i].InitializeOnFireAttraction();
        }

        for (int i = 0; i < allAttractions.Count; i++)
        {
            allAttractions[i].InitializeDestroyedAttraction();
        }

        for (int i = 0; i < allAttractions.Count; i++)
        {
            allAttractions[i].InitializeRebuild(OnRebuild, gameUI.GetPurchaseMenu());
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
        allMenus.InitializeMenus(OnPurchase, gameUI.GetPurchaseMenu());
    }

    private void Update()
    {
        UpdateUI();

        //test
        //currentFireTimer -= Time.deltaTime;
        //if (currentFireTimer <= 0f)
        //{
        //    currentFireTimer = 5f;
        //    List<SoulsObjectBase> fireTargets = new List<SoulsObjectBase>();
        //    for (int i = 0; i < baseAttractions.Count; i++)
        //    {
        //        if (baseAttractions[i].IsBuilt() && !baseAttractions[i].IsOnFire() && !baseAttractions[i].IsDestroyed())
        //        {
        //            Debug.LogError("ADDED: " + baseAttractions[i].GetID());
        //            fireTargets.Add(baseAttractions[i]);
        //        }
        //    }

        //    if (fireTargets.Count > 0)
        //    {
        //        int index = UnityEngine.Random.Range(0, fireTargets.Count);
        //        fireTargets[index].SetAttractionOnFire();
        //    }
        //}
        //end test
    }

    private void LoadData()
    {
        totalSouls = PlayerPrefsSavingLoading.Instance.LoadInt(ConstantStrings.totalSouls);
    }

    private void CollectGatheredSouls(int _numSouls, Vector2 _gatherPoint)
    {
        soulsCreator.CreateSouls(_gatherPoint, Camera.main.ScreenToWorldPoint(soulsTarget.transform.position), _numSouls, AddSoul);
    }

    private void AddSoul()
    {
        totalSouls++;
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

    private void OnRebuild(int _purchasePrice, string _ID)
    {
        totalSouls -= _purchasePrice;
        PlayerPrefsSavingLoading.Instance.SaveInt(ConstantStrings.totalSouls, totalSouls);
        for (int i = 0; i < allAttractions.Count; i++)
        {
            if (allAttractions[i].GetID() == _ID)
            {
                allAttractions[i].RebuildAttraction();
                break;
            }
        }
    }


    //debug
    public void ClearData()
    {
        PlayerPrefsSavingLoading.Instance.DeleteAllKeys();
    }

    public void DebugAddSouls()
    {
        totalSouls += 50;
        PlayerPrefsSavingLoading.Instance.SaveInt(ConstantStrings.totalSouls, totalSouls);
    }
}
