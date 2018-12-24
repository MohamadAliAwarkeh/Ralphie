using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{

    //Public Variables
    [Header("Player Variables")]
    public float playerSpeed;

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
        PlayerMovement();

        if (Input.GetKey(KeyCode.JoystickButton0))
        {
            followPlayer.ComeToPlayer();
        }
    }

    void FixedUpdate()
    {
        myRB.velocity = moveVelocity;
    }

    void PlayerMovement()
    {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * playerSpeed;
    }
}
