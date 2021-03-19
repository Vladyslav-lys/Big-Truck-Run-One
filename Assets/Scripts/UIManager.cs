using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject startUI;
    public GameObject dragUI;
    public GameObject playUI;
    public GameObject pauseUI;
    public GameObject settingsUI;
    public GameObject shopUI;
    public GameObject loseUI;
    public GameObject finishUI;
    public GameObject levelLineHolder;
    public GameObject coinHolder;
    public Image levelLine;
    public TextMeshProUGUI startCoinText;
    public TextMeshProUGUI finishCoinText;
    public TextMeshProUGUI vibrationSettingsText;
    public TextMeshProUGUI soundSettingsText;
    public TextMeshProUGUI vibrationPauseText;
    public TextMeshProUGUI soundPauseText;
    public TextMeshProUGUI levelText;

    private void Start()
    {
        vibrationPauseText.text = vibrationSettingsText.text = "Vibration " + Managers.instance.soundManager.Vibration;
        soundPauseText.text = soundSettingsText.text = "Sound " + Managers.instance.soundManager.Sound;
    }

    public void StartGame()
    {
        startUI.SetActive(false);
        dragUI.SetActive(true);
        playUI.SetActive(true);
    }

    public void FinishGameInTime(float delay)
    {
        Invoke(nameof(FinishGame), delay);
    }

    private void FinishGame()
    {
        EnablePlayUI(false);
        finishUI.SetActive(true);
    }

    public void LoseGameInTime(float delay)
    {
        Invoke(nameof(LoseGame), delay);
    }

    private void LoseGame()
    {
        EnablePlayUI(false);
        loseUI.SetActive(true);
    }
    
    public void OpenSettings()
    {
        EnableStartUI(false);
        settingsUI.SetActive(true);
    }
    
    public void CloseSettings()
    {
        EnableStartUI(true);
        settingsUI.SetActive(false);
    }

    public void OpenPause()
    {
        EnablePlayUI(false);
        pauseUI.SetActive(true);
    }
    
    public void ClosePause()
    {
        EnablePlayUI(true);
        pauseUI.SetActive(false);
    }

    private void EnableStartUI(bool isActive)
    {
        coinHolder.SetActive(isActive);
        levelText.gameObject.SetActive(isActive);
        levelLineHolder.SetActive(isActive);
        startUI.SetActive(isActive);
    }
    
    private void EnablePlayUI(bool isActive)
    {
        coinHolder.SetActive(isActive);
        levelText.gameObject.SetActive(isActive);
        levelLineHolder.SetActive(isActive);
        playUI.SetActive(isActive);
    }

    public void SetVibrationText(TextMeshProUGUI textMesh)
    {
        textMesh.text = "Vibration " + Managers.instance.soundManager.Vibration;
    }
    
    public void SetSoundText(TextMeshProUGUI textMesh)
    {
        textMesh.text = "Sound " + Managers.instance.soundManager.Sound;
    }
}
