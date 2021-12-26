using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;



public class VikingController : MonoBehaviour
{
    [SerializeField] float RunSpeed = 10f;
    [SerializeField] float JumpSpeed = 10f;

    Vector3 InputValue;
    Rigidbody myRigidbody;
    Animator myAnimator;
    public bool isDied = false;

    bool TurnRight, TurnLeft = false;
    bool CanRotate = false;
    Vector3 Direction = new Vector3(0, 0, 1);

    

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        myAnimator = GetComponent<Animator>();
    }

   

    // Update is called once per frame
    void Update()
    {

        Run();
    }

    private void OnTriggerEnter(Collider other)
    {
        if( other.CompareTag("rightRotate") )
        {
            CanRotate = true;
        }
        if( other.CompareTag("Obstacle") )
        {
            GameOver();
        }
    }

    

    private void OnTriggerExit(Collider other)
    {
        if( other.CompareTag("rightRotate") )
        {
            TurnRight = false;
            CanRotate = false;
        }
    }
    

    void Run()
    {
        Vector3 playerVelocity = new Vector3(0, 0, 0);
        if( Direction.Equals(new Vector3(0, 0, 1)) )
        {
            playerVelocity  = new Vector3(RunSpeed * InputValue.x, myRigidbody.velocity.y, RunSpeed * InputValue.z);
        }
        else if( Direction.Equals(new Vector3(1, 0, 0)) )
        {
            playerVelocity = new Vector3(RunSpeed * InputValue.z, myRigidbody.velocity.y, -RunSpeed * InputValue.x);
        }
        else if( Direction.Equals(new Vector3(0, 0, -1)) )
        {
            playerVelocity = new Vector3(-RunSpeed * InputValue.x, myRigidbody.velocity.y, -RunSpeed * InputValue.z);
        }
        else if( Direction.Equals(new Vector3(-1, 0, 0)) )
        {
            playerVelocity = new Vector3(-RunSpeed * InputValue.z, myRigidbody.velocity.y, RunSpeed * InputValue.x);
        }
         
        myRigidbody.velocity = playerVelocity;
        bool playerHorizonSpeed = Mathf.Abs(myRigidbody.velocity.z) > Mathf.Epsilon || Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isRunning", playerHorizonSpeed);
    }
    void OnMove(InputValue value)
    {
        InputValue = value.Get<Vector3>();
        Debug.Log(InputValue);
    }
    void OnJump(InputValue value)
    {
        if( value.isPressed )
        {
            myRigidbody.velocity += new Vector3(0f, JumpSpeed, 0f);
           
        }
    }
    void OnTurnRight(InputValue value)
    {
        if( CanRotate )
        {
            if( value.isPressed && !TurnRight )
            {
                if( Direction.Equals(new Vector3(0, 0, 1)) )
                {
                    Direction = new Vector3(1, 0, 0);
                }
                else if( Direction.Equals(new Vector3(1, 0, 0)) )
                {
                    Direction = new Vector3(0, 0, -1);
                }
                else if( Direction.Equals(new Vector3(0, 0, -1)) )
                {
                    Direction = new Vector3(-1, 0, 0);
                }
                else if( Direction.Equals(new Vector3(-1, 0, 0)) )
                {
                    Direction = new Vector3(0, 0, 1);
                }
                transform.Rotate(Vector3.up, transform.rotation.y + 90);
                TurnRight = true;
            }
        }
    }
    void OnTurnLeft(InputValue value)
    {
        if( CanRotate ) 
        {
            if( value.isPressed && !TurnLeft )
            {
                if( Direction.Equals(new Vector3(0, 0, 1)) )
                {
                    Direction = new Vector3(0, 0, -1);
                }
                else if( Direction.Equals(new Vector3(1, 0, 0)) )
                {
                    Direction = new Vector3(0, 0, 1);
                }
                else if( Direction.Equals(new Vector3(0, 0, -1)) )
                {
                    Direction = new Vector3(1, 0, 0);
                }
                else if( Direction.Equals(new Vector3(-1, 0, 0)) )
                {
                    Direction = new Vector3(0, 0, -1);
                }
                transform.Rotate(Vector3.up, transform.rotation.y - 90);
                TurnLeft = true;
                
            }
        }
        
    }
    private void GameOver()
    {
        SceneManager.LoadScene(2);
        isDied = true;
    }
}
