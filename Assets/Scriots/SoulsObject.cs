using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class SoulsObject : MonoBehaviour
{
    private bool isBuilt;

    private bool isBoosted;

    [SerializeField] private float soulCapacity;
    [SerializeField] private float soulGatherTime;
    [SerializeField] private float soulGatherAmount;

    [SerializeField] private TextMeshProUGUI soulsDisplay;

    private float currentGatheredSouls;

    private DateTime lastCollection;

    public Action<int> OnCollectSouls;

    [SerializeField] private string ID;

    [SerializeField] private List<GameObject> nonBuiltObjects = new List<GameObject>();
    [SerializeField] private List<GameObject> builtObjects = new List<GameObject>();


    private void Update()
    {
        if (isBuilt)
        {
            UpdateSoulsGathered();
        }

        UpdateUI();
    }

    public void Initialize()
    {
        isBuilt = PlayerPrefsSavingLoading.Instance.LoadBool(ID + ConstantStrings.built);

        if (isBuilt)
        {
            for (int i = 0; i < nonBuiltObjects.Count; i++)
            {
                nonBuiltObjects[i].SetActive(false);
            }

            for (int i = 0; i < builtObjects.Count; i++)
            {
                builtObjects[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < nonBuiltObjects.Count; i++)
            {
                nonBuiltObjects[i].SetActive(true);
            }

            for (int i = 0; i < builtObjects.Count; i++)
            {
                builtObjects[i].SetActive(false);
            }
        }

        if (PlayerPrefsSavingLoading.Instance.LoadString(ID + ConstantStrings.collectionTime) != string.Empty)
        {
            long temp = Convert.ToInt64(PlayerPrefsSavingLoading.Instance.LoadString(ID + ConstantStrings.collectionTime));
            lastCollection = DateTime.FromBinary(temp);
        }
        else
        {
            lastCollection = DateTime.Now;
            PlayerPrefsSavingLoading.Instance.SaveString(ID + ConstantStrings.collectionTime, lastCollection.ToBinary().ToString());

        }
    }

    private void BuildAttraction()
    {
        lastCollection = DateTime.Now;
        PlayerPrefsSavingLoading.Instance.SaveString(ID + ConstantStrings.collectionTime, lastCollection.ToBinary().ToString());

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

        if (numSecondsSinceLastCollection / soulGatherTime * soulGatherAmount > soulCapacity)
        {
            currentGatheredSouls = soulCapacity;
        }
        else
        {
            currentGatheredSouls = (float)(numSecondsSinceLastCollection / soulGatherTime * soulGatherAmount);
        }


    }

    private void UpdateUI()
    {
        soulsDisplay.text = Mathf.FloorToInt(currentGatheredSouls).ToString() + "/" + soulCapacity.ToString();
    }

    public void OnCollectButtonPressed()
    {
        if (Mathf.FloorToInt(currentGatheredSouls) > 0)
        {
            OnCollectSouls?.Invoke(Mathf.FloorToInt(currentGatheredSouls));
            currentGatheredSouls = 0f;
            lastCollection = DateTime.Now;
            PlayerPrefsSavingLoading.Instance.SaveString(ID + ConstantStrings.collectionTime, lastCollection.ToBinary().ToString());
        }
        else
        {
            //nothign to gather
        }

    }


}
