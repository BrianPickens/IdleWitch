using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameUI : MonoBehaviour
{
    [SerializeField] private PurchaseConfirmation purchaseMenu;

    [SerializeField] private MobFireNotification mobNotification;

    [SerializeField] private SoulsHolder soulsHolder;

    [SerializeField] private TextMeshProUGUI fireChanceText;
    [SerializeField] private Image fireChanceFill;

    [SerializeField] private TextMeshProUGUI fireChanceTimerText;
    public void UpdateTotalSoulsDisplay(float _numSouls)
    {
        soulsHolder.UpdateSouls(_numSouls);
    }

    public void UpdateFireChance(int _chance)
    {
        fireChanceFill.fillAmount = (float)_chance / 100f;
        fireChanceText.text = _chance.ToString() + "%";

    }

    public void UpdateFireChanceTimer(TimeSpan _fireTime)
    {
        //multiplied by -1 because we our timespan is negative
        string timerString = "";
        timerString += (_fireTime.Hours * -1).ToString();
        timerString += ":";
        if (_fireTime.Minutes * -1 < 10)
        {
            timerString += "0";
            timerString += (_fireTime.Minutes * -1).ToString();
        }
        else 
        {
            timerString += (_fireTime.Minutes * -1).ToString();
        }
        timerString += ":";

        if (_fireTime.Seconds * -1 < 10)
        {
            timerString += "0";
            timerString += (_fireTime.Seconds * -1).ToString();
        }
        else
        {
            timerString += (_fireTime.Seconds * -1).ToString();
        }

        fireChanceTimerText.text = timerString;
    }

    public void DisplayMobNotification(bool _successful, int _numBuildingsOnFire)
    {
        mobNotification.ShowMobAttacked(_successful, _numBuildingsOnFire);
    }

    public PurchaseConfirmation GetPurchaseMenu()
    {
        return purchaseMenu;
    }

}
