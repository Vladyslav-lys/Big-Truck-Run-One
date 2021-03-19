using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Player player;
    private Managers _managers;
    private Transform _bodyTransform;
    private Transform _playerTransform;

    private void Start()
    {
        _managers = Managers.instance;
        _bodyTransform = player.bodyTransform;
        _playerTransform = player.transform;
    }

    private void Update()
    {
        #if UNITY_EDITOR
        if((new List<string> {"a","d","w","s"}).Contains(Input.inputString))
            _managers.gameManager.StartGame();
        
        if (!player.canMove || !_managers.gameManager.CanPlay())
            return;
        
        switch (Input.inputString)
        {
            case "a":
                SetHorizontalTarget(!player.canLeft, _playerTransform.position.x - 1.2f);
                break;
            case "d":
                SetHorizontalTarget(!player.canRight, _playerTransform.position.x + 1.2f);
                break;
            case "w":
                SetVerticalTarget(_bodyTransform.localPosition.y > 0f, 1f, 1.3f, 0.9f, 1.85f);
                break;
            case "s":
                SetVerticalTarget(_bodyTransform.localPosition.y < 1f, 0f, 0.3f, 0.4f, 0.85f);
                break;
        }
        #endif
    }

    public void OnBeginDrag(PointerEventData eventData) { }

    public void OnDrag(PointerEventData eventData)
    {
        if (!_managers.gameManager.player.canMove || !_managers.gameManager.CanPlay())
            return;
        
        if (eventData.delta.x < -40f) //LEFT
        {
            SetHorizontalTarget(!player.canLeft, _playerTransform.position.x - 1.2f);
        } if (eventData.delta.x > 40f) //RIGHT
        {
            SetHorizontalTarget(!player.canRight, _playerTransform.position.x + 1.2f);
        } if (eventData.delta.y > 40f) //UP
        {
            SetVerticalTarget(_bodyTransform.localPosition.y > 0f, 1f, 1.3f, 0.9f, 1.85f);
        } if (eventData.delta.y < -40f) //DOWN
        {
            SetVerticalTarget(_bodyTransform.localPosition.y < 1f, 0f, 0.3f, 0.4f, 0.85f);
        }
    }

    public void OnEndDrag(PointerEventData eventData) { player.TrueCanMove(); }

    private void SetVerticalTarget(bool outCondition, float verticalTarget, float scaleStickVerticalTarget, float posStickVerticalTarget, float centerStickVerticalTarget)
    {
        if(outCondition)
            return;
        
        player.verticalTarget = verticalTarget;
        player.scaleStickVerticalTarget = scaleStickVerticalTarget;
        player.posStickVerticalTarget = posStickVerticalTarget;
        player.centerStickVerticalTarget = centerStickVerticalTarget;
        player.canMove = false;
    }

    private void SetHorizontalTarget(bool outCondition, float horizontalTarget)
    {
        if(outCondition)
            return;
        
        player.horizontalTarget = horizontalTarget;
        player.canMove = false;
    }
}
