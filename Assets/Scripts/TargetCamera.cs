using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCamera : MonoBehaviour
{
    public Transform playerTransform;
    public Transform finishTransform;
    private Managers _managers;

    private void Start()
    {
        _managers = Managers.instance;
    }

    private void Update()
    {
        if(_managers.gameManager.CanPlay())
            transform.position = new Vector3(transform.position.x, transform.position.y, playerTransform.position.z - 10f);

        if (_managers.gameManager.isFinished)
        {
            transform.position =
                Vector3.MoveTowards(transform.position, finishTransform.position, 20f * Time.deltaTime);
            transform.rotation =
                Quaternion.RotateTowards(transform.rotation, finishTransform.rotation, 70f*Time.deltaTime);
        }
    }
}
