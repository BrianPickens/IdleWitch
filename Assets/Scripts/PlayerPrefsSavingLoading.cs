using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsSavingLoading : MonoBehaviour
{
    private static PlayerPrefsSavingLoading instance = null;
    public static PlayerPrefsSavingLoading Instance { get { return instance; } }

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void SaveInt(string _name, int _value)
    {
        PlayerPrefs.SetInt(_name, _value);
    }

    public void SaveBool(string _name, bool _value)
    {
        PlayerPrefs.SetInt(_name, _value == true ? 1 : 0);
    }

    public void SaveFloat(string _name, float _value)
    {
        PlayerPrefs.SetFloat(_name, _value);
    }

    public void SaveString(string _name, string _value)
    {
        PlayerPrefs.SetString(_name, _value);
    }

    public int LoadInt(string _name)
    {
        if (PlayerPrefs.HasKey(_name))
        {
            return PlayerPrefs.GetInt(_name);
        }
        else
        {
            return 0;
        }
    }

    public bool LoadBool(string _name)
    {
        if (PlayerPrefs.HasKey(_name))
        {
            return PlayerPrefs.GetInt(_name) == 1 ? true : false;
        }
        else
        {
            return false;
        }
    }

    public float LoadFloat(string _name)
    {
        if (PlayerPrefs.HasKey(_name))
        {
            return PlayerPrefs.GetFloat(_name);
        }
        else
        {
            return 0f;
        }
    }

    public string LoadString(string _name)
    {
        if (PlayerPrefs.HasKey(_name))
        {
            return PlayerPrefs.GetString(_name);
        }
        else
        {
            return string.Empty;
        }
    }

    public void DeleteAllKeys()
    {
        PlayerPrefs.DeleteAll();
    }

}
