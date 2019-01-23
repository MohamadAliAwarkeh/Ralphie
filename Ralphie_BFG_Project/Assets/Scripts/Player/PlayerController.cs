using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Idle,
    WalkingAndActions,
}

public class PlayerController : MonoBehaviour
{

    //Public Variables
    [Header("Player Variables")]
    public float playerSpeed; 
    public PlayerState playerState = PlayerState.Idle;

    [Header("Script References")]
    public FollowPlayer followPlayer;

    //Private Variables
    private Rigidbody myRB;
    private Vector3 moveInput;
    private Vector3 moveVelocity;

    void Start()
    {
        myRB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        switch (playerState)
        {
            case PlayerState.Idle:
                //The states a player can have during idle
                Idle();
                break;

            case PlayerState.WalkingAndActions:
                //The states a player can have during Walking and Actions
                PlayerMovement();
                break;
        }

        if (Input.GetKey(KeyCode.JoystickButton0) || Input.GetKey(KeyCode.Space))
        {
            followPlayer.speed = 6;
        }
    }

    void FixedUpdate()
    {
        myRB.velocity = moveVelocity;
    }

    void Idle()
    {

    }

    void PlayerMovement()
    {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * playerSpeed;
    }
}
