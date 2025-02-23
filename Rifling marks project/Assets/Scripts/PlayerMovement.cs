using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 Movement;
    public float MoveSpeedMultiplier;

    public float MoveSpeed;
    public float jumpHeight;

    public float gravity = -9.813f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundLayerMask;
    public PlayerData playerData;

    Vector3 velocity;
    bool isGrounded;

    public CharacterController characterController;

    public enum PlayerState
    {
        Standing,
        Crouch,
        Prone
    }

    public PlayerState State;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayerMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        characterController.Move(move * MoveSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);

        playerData.Position = transform.position;
        playerData.Rotation = transform.rotation;
        playerData.Scale = transform.localScale;

    }
}
