using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : BaseSingleton<Sounds>
{
    [SerializeField] private GameObject tapSound;
    
    private void Awake()
    {
        if(!instance)
            instance = this;
    }
}
