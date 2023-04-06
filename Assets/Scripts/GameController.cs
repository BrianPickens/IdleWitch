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

    [SerializeField] private float fireTimer;
    private DateTime lastFireCheckTime;

    private void Start()
    {

        InitializeActions();

        InitializeAttractions();

        InitializeMenus();

        InitializeFireCheckTime();

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
        HandleFireChances();
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

    private void InitializeFireCheckTime()
    {
        if (PlayerPrefsSavingLoading.Instance.LoadString(ConstantStrings.lastFireCheckTime) != string.Empty)
        {
            long temp = Convert.ToInt64(PlayerPrefsSavingLoading.Instance.LoadString(ConstantStrings.lastFireCheckTime));
            lastFireCheckTime = DateTime.FromBinary(temp);

            DateTime currentTime = DateTime.Now;
            double numSecondsSinceLastFireCheck = 0f;

            int numTimesToCheck = 0;
            TimeSpan timeSinceLastCheck = currentTime - lastFireCheckTime;
            if (timeSinceLastCheck.TotalSeconds > double.MaxValue)
            {
                numSecondsSinceLastFireCheck = double.MaxValue;
            }
            else
            {
                numSecondsSinceLastFireCheck = timeSinceLastCheck.TotalSeconds;
            }

            if (numSecondsSinceLastFireCheck > fireTimer)
            {
                numTimesToCheck = Mathf.FloorToInt((float)(numSecondsSinceLastFireCheck / fireTimer));
                lastFireCheckTime = DateTime.Now.AddSeconds(numTimesToCheck * fireTimer);
                PlayerPrefsSavingLoading.Instance.SaveString(ConstantStrings.lastFireCheckTime, lastFireCheckTime.ToBinary().ToString());
                DoFireCheck(numTimesToCheck);
            }

        }
        else
        {
            PlayerPrefsSavingLoading.Instance.SaveString(ConstantStrings.lastFireCheckTime, DateTime.Now.ToBinary().ToString());
        }
    }

    private void HandleFireChances()
    {
        DateTime currentTime = DateTime.Now;
        TimeSpan timeSinceLastCheck = currentTime - lastFireCheckTime;

        double numSecondsSinceLastFireCheck = timeSinceLastCheck.TotalSeconds;
        Debug.LogError(numSecondsSinceLastFireCheck);
        if (numSecondsSinceLastFireCheck > 0)
        {
            lastFireCheckTime = DateTime.Now.AddSeconds(fireTimer);
            PlayerPrefsSavingLoading.Instance.SaveString(ConstantStrings.lastFireCheckTime, lastFireCheckTime.ToBinary().ToString());
            DoFireCheck(1);
        }
    }

    private void DoFireCheck(int _numChecks)
    {

        //still need to add percent chance
        for (int i = 0; i < _numChecks; i++)
        {
            List<SoulsObjectBase> fireTargets = new List<SoulsObjectBase>();
            for (int j = 0; j < baseAttractions.Count; j++)
            {
                if (baseAttractions[j].IsBuilt() && !baseAttractions[j].IsOnFire() && !baseAttractions[j].IsDestroyed())
                {
                    //Debug.LogError("ADDED: " + baseAttractions[j].GetID());
                    fireTargets.Add(baseAttractions[j]);
                }
            }

            if (fireTargets.Count > 0)
            {
                int index = UnityEngine.Random.Range(0, fireTargets.Count);
                fireTargets[index].SetAttractionOnFire();
                Debug.LogError("Setting place on fire");
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
