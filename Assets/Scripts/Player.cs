using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool canMove;
    public bool canRight, canLeft;
    public Transform bodyTransform;
    public Transform[] sticks;
    public BoxCollider col;
    public float horizontalTarget;
    public float verticalTarget;
    public float scaleStickVerticalTarget;
    public float posStickVerticalTarget;
    public float centerStickVerticalTarget;
    public Animator playerAnimator;
    public float forwardSpeed;
    public float maxSpeed;
    private Managers _managers;
    private float _bodyChangingSpeed;
    private Rigidbody _rb;

    private void Start()
    {
        _managers = Managers.instance;
        _bodyChangingSpeed = 20f;
        _rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //OBSTACLE
        if (other.gameObject.layer == 6)
        {
            _managers.gameManager.LoseGame();
            playerAnimator.SetBool("Started",false);
            NulliftVelocity();
        }
        
        //COIN
        if (other.gameObject.layer == 7)
        {
            _managers.gameManager.AddCoin();
            Destroy(other.gameObject);
        }
        
        //FINISH
        if (other.gameObject.layer == 8)
        {
            _managers.gameManager.FinishGame();
        }
        
        //INVISIBLE OBSTACLE
        if (other.gameObject.layer == 9)
        {
            _managers.gameManager.LoseGame();
            _rb.useGravity = true;
            _rb.velocity = new Vector3(0f,0f,5f);
        }
        
        //ROAD
        if (other.gameObject.layer == 10)
        {
            Road road = other.GetComponent<Road>();
            canLeft = road.canLeft;
            canRight = road.canRight;
        }
    }
    
    private void FixedUpdate()
    {
        if(!_managers.gameManager.CanPlay())
            return;
        
        if (_rb.velocity.magnitude < maxSpeed)
        {
            _rb.AddForce(new Vector3(0f, 0f, forwardSpeed * Time.fixedDeltaTime), ForceMode.Impulse);
        }
    }

    private void Update()
    {
        if(!_managers.gameManager.isStarted || !_managers.gameManager.CanPlay())
            return;
        
        bodyTransform.position = Vector3.MoveTowards(bodyTransform.position, 
            new Vector3(bodyTransform.position.x, verticalTarget, bodyTransform.position.z), 
            _bodyChangingSpeed*Time.deltaTime);

        transform.position = Vector3.MoveTowards(transform.position,
            new Vector3(horizontalTarget, transform.position.y, transform.position.z),
            40 * Time.deltaTime);
        
        col.center = Vector3.MoveTowards(col.center,
            new Vector3(col.center.x,centerStickVerticalTarget,col.center.z), 
            _bodyChangingSpeed*Time.deltaTime);

        for (int i=0; i<sticks.Length; i++)
        {
            sticks[i].position = Vector3.MoveTowards(sticks[i].position,
                new Vector3(sticks[i].position.x, posStickVerticalTarget, sticks[i].position.z), 
                _bodyChangingSpeed*Time.deltaTime);
            sticks[i].localScale = Vector3.MoveTowards(sticks[i].localScale,
                new Vector3(sticks[i].localScale.x, scaleStickVerticalTarget, sticks[i].localScale.z), 
                _bodyChangingSpeed*Time.deltaTime);
        }
    }

    public void TrueCanMoveInTime(float time) => Invoke(nameof(TrueCanMove), time);
    
    public void TrueCanMove() => canMove = true;

    public void NulliftVelocity() => _rb.velocity = Vector3.zero;
}
