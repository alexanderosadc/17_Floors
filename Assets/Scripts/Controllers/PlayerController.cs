using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed = 2.5f;
    public float gravity = 20.0f;
    public bool useZAxis = false;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    private Player player;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        player = GetComponent<Player>();
    }

    void Update()
    {
        if (controller.isGrounded && player.CanControl)
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = 0;

            if (useZAxis)
                moveZ = Input.GetAxis("Vertical");

            moveDirection = new Vector3(moveX, 0, moveZ);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
        }

        moveDirection.y -= gravity * Time.deltaTime;

        controller.Move(moveDirection * Time.deltaTime);
    }
}