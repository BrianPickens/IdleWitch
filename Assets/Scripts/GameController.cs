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
    [SerializeField] private List<DetectionObject> allDetectionObjects = new List<DetectionObject>();
    [SerializeField] private List<OffersObject> allOffersObjects = new List<OffersObject>();

    [SerializeField] private Menus allMenus;

    [SerializeField] private SoulsCreator soulsCreator;
    [SerializeField] private RectTransform soulsTarget;

    [SerializeField] private float fireTimer;
    private DateTime fireCheckTime;
    private int totalFireChance;

    private void Start()
    {

        InitializeActions();

        InitializeAttractions();

        InitializeDetection();

        InitializeOffers();

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

    private void InitializeDetection()
    {
        for (int i = 0; i < allDetectionObjects.Count; i++)
        {
            allDetectionObjects[i].InitializeBuildDetection();
        }
    }

    private void InitializeOffers()
    {
        for (int i = 0; i < allOffersObjects.Count; i++)
        {
            allOffersObjects[i].InitializeOfferTaken();
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

        for (int i = 0; i < allDetectionObjects.Count; i++)
        {
            if (allDetectionObjects[i].GetID() == _ID)
            {
                allDetectionObjects[i].BuildDetection();
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
        if (PlayerPrefsSavingLoading.Instance.LoadString(ConstantStrings.fireCheckTime) != string.Empty)
        {
            long temp = Convert.ToInt64(PlayerPrefsSavingLoading.Instance.LoadString(ConstantStrings.fireCheckTime));
            fireCheckTime = DateTime.FromBinary(temp);

            DateTime currentTime = DateTime.Now;
            double numSecondsSinceLastFireCheck = 0f;

            int numTimesToCheck = 0;
            TimeSpan timeSinceLastCheck = currentTime - fireCheckTime;
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
                fireCheckTime = fireCheckTime.AddSeconds(numTimesToCheck * fireTimer);
                PlayerPrefsSavingLoading.Instance.SaveString(ConstantStrings.fireCheckTime, fireCheckTime.ToBinary().ToString());
                DoFireCheck(numTimesToCheck);
            }

        }
        else
        {
            fireCheckTime = DateTime.Now.AddSeconds(fireTimer);
            PlayerPrefsSavingLoading.Instance.SaveString(ConstantStrings.fireCheckTime, fireCheckTime.ToBinary().ToString());
        }
    }

    private void HandleFireChances()
    {
        totalFireChance = 0;
        for (int i = 0; i < allAttractions.Count; i++)
        {
            if (allAttractions[i].IsBuilt())
            {
                totalFireChance += ConstantStrings.Instance.GetItemChanceChange(allAttractions[i].GetItemType());
            }
        }

        for (int i = 0; i < allDetectionObjects.Count; i++)
        {
            if (allDetectionObjects[i].IsBuilt())
            {
                totalFireChance += ConstantStrings.Instance.GetItemChanceChange(allDetectionObjects[i].GetItemType());
            }
        }

        totalFireChance = (int)Mathf.Clamp(totalFireChance, 0, 100);

        gameUI.UpdateFireChance(totalFireChance);

        DateTime currentTime = DateTime.Now;
        TimeSpan timeSinceLastCheck = currentTime - fireCheckTime;

        gameUI.UpdateFireChanceTimer(timeSinceLastCheck);

        double numSecondsSinceLastFireCheck = timeSinceLastCheck.TotalSeconds;
        if (numSecondsSinceLastFireCheck >= 0f)
        {
            fireCheckTime = DateTime.Now.AddSeconds(fireTimer);
            PlayerPrefsSavingLoading.Instance.SaveString(ConstantStrings.fireCheckTime, fireCheckTime.ToBinary().ToString());
            DoFireCheck(1);
        }
    }

    private void DoFireCheck(int _numChecks)
    {
        int numBuildingsOnFire = 0;
        bool successfulFire = false;
        for (int i = 0; i < _numChecks; i++)
        {
            int fireRoll = UnityEngine.Random.Range(0, 100);
            if (fireRoll < totalFireChance)
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
                    numBuildingsOnFire++;
                    successfulFire = true;
                    Debug.LogError("Setting place on fire");
                }
            }
        }

        gameUI.DisplayMobNotification(successfulFire, numBuildingsOnFire);

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
