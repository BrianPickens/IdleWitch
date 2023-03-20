using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SoulsHolder : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI soulsText;
    [SerializeField] private Image soulsFill;

    [SerializeField] private float fullSouls;
    public void UpdateSouls(float _numSouls)
    {
        soulsText.text = Mathf.RoundToInt(_numSouls).ToString();
        soulsFill.fillAmount = _numSouls / fullSouls;
    }
}
