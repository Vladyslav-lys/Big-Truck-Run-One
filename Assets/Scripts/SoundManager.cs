using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private Managers _managers;
    
    public string Sound
    {
        get => PlayerPrefs.GetString("Sound", "On");
        set => PlayerPrefs.SetString("Sound", value);
    }
    
    public string Vibration
    {
        get => PlayerPrefs.GetString("Vibration", "On");
        set => PlayerPrefs.SetString("Vibration", value);
    }

    private void Start()
    {
        _managers = Managers.instance;
    }

    public void SetSound()
    {
        if (Sound == "On")
            Sound = "Off";
        else
            Sound = "On";
    }
    
    public void SetVibration()
    {
        if (Vibration == "On")
            Vibration = "Off";
        else
            Vibration = "On";
    }
}
