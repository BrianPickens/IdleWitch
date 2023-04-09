using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MobFireNotification : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;

    public void ShowMobAttacked(bool _successful, int _numBuildingsOnFire)
    {
        titleText.text = string.Empty;
        descriptionText.text = string.Empty;

        if (_successful)
        {
            titleText.text = "Mob Attack!";
            descriptionText.text = "The mob set " + _numBuildingsOnFire.ToString() + " building on fire!";
        }
        else
        {
            titleText.text = "Mob Attack!";
            descriptionText.text = "The mob failed to set anything on fire!";
        }
        gameObject.SetActive(true);
    }

    public void ClickedConfirm()
    {
        gameObject.SetActive(false);
    }

}
