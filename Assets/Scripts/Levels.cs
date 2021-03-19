using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : BaseSingleton<Levels>
{
    public GameObject[] levels;
    public Material[] skyboxes;
    public Material[] fogMats;
    public Renderer fogRenderer;
    public bool isDebug;
    public int level;
    private float _curDistance;
    private float _lineStep;
    private Managers _managers;
    
    public int Level
    {
        get => PlayerPrefs.GetInt("Level", 1);
        set => PlayerPrefs.SetInt("Level", value);
    }

    public int TenTimeLevel
    {
        get => PlayerPrefs.GetInt("TenTimeLevel", 1);
        set => PlayerPrefs.SetInt("TenTimeLevel", value); 
    }
    
    private void Awake()
    {
        if(!instance)
            instance = this;
    }

    private void Start()
    {
        if (isDebug)
            Level = level;
        levels[Level-1].SetActive(true);
        _curDistance = levels[Level-1].GetComponent<Level>().distance;
        _lineStep = 1f/_curDistance;
        _managers = Managers.instance;
        _managers.uiManager.levelText.text = "Level " + Level;
        SetEnvironment();
        InvokeRepeating(nameof(LineAdding),0f, 0.06f);
    }

    private void LineAdding()
    {
        if(!_managers.gameManager.CanPlay())
            return;
        
        _managers.uiManager.levelLine.fillAmount += _lineStep;
            
        if(!_managers.gameManager.CanPlay())
            CancelInvoke(nameof(LineAdding));
    }

    private void SetEnvironment()
    {
        fogRenderer.material = fogMats[TenTimeLevel-1];
        RenderSettings.skybox = skyboxes[TenTimeLevel-1];
    }

    public void SetNewTenTimeLevel()
    {
        if (Level % 10 == 0)
            TenTimeLevel++;
        if (TenTimeLevel > skyboxes.Length)
            TenTimeLevel = 1;
    }
    
    public void SetNewLevel()
    {
        Level++;
        if (Level > levels.Length)
        {
            Level = 1;
            TenTimeLevel = 1;
        }
    }
}
