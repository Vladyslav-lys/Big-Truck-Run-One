using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class Managers : BaseSingleton<Managers>
{
    public GameManager gameManager;
    public SoundManager soundManager;
    public SkinManager skinManager;
    public UIManager uiManager;
    public SpawnManager spawnManager;

    private void Awake()
    {
        if(!instance)
            instance = this;
    }
}
