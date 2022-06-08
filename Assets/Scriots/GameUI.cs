using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI totalSoulsDisplay;
    [SerializeField] private TextMeshProUGUI soulsGatheredDisplay;
    [SerializeField] private TextMeshProUGUI candyOutDisplay;

    public Action OnCollectPressed;
    public Action OnCandyPressed;

    public void UpdateTotalSoulsDisplay(float _numSouls)
    {
        totalSoulsDisplay.text = Mathf.RoundToInt(_numSouls).ToString();
    }

    public void UpdateGatherableSoulsDiplay(float _numGathered, float _maxGatherable)
    {
        soulsGatheredDisplay.text = Mathf.RoundToInt(_numGathered).ToString() + " / " + Mathf.RoundToInt(_maxGatherable).ToString();
    }

    public void UpdateCandyOutDisplay(bool _candyOut, int _hours, int _minutes, int _seconds)
    {
        if (_candyOut)
        {

            string timerText = string.Empty;

            if (_hours > 0)
            {
                timerText += _hours.ToString() + ":";
            }

            if (_minutes == 0 && _hours > 0)
            {
                timerText += _minutes.ToString() + ":";
            }
            else if (_minutes > 0)
            {
                timerText += _minutes.ToString() + ":";
            }

            if (_seconds == 0 && _hours > 0 || _seconds == 0 && _minutes > 0)
            {
                timerText += _seconds.ToString() + ":";
            }
            else if (_seconds > 0)
            {
                timerText += _seconds.ToString();
            }

            if (string.IsNullOrEmpty(timerText))
            {
                timerText = "0";
            }


            candyOutDisplay.text = timerText;
        }
        else
        {
            candyOutDisplay.text = "Refill Candy";
        }

    }

    public void OnCollectSoulsPressed()
    {
        OnCollectPressed?.Invoke();
    }

    public void OnRefreshCandyPressed()
    {
        OnCandyPressed?.Invoke();
    }

}
