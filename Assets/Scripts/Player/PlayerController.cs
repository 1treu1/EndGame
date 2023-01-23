using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 2.5f;
    public float rotationSpeed;
    public PlayerInput playerinput;
    public float jumpHeight = 3;
    Vector3 velocity;
    public float gravity = -9.81f;

    private void Start()
    {
        playerinput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        //Movimiento del player
        /*
        float horizontalInput = Input.GetAxis("Horizontal"); //X
        float verticalInput = Input.GetAxis("Vertical"); //Z
        */
        Vector2 input = playerinput.actions["Move"].ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x,0, input.y);
        characterController.Move(move * speed * Time.deltaTime);
        move.Normalize();
        //Rotacion del personaje
        transform.Translate(move * rotationSpeed * Time.deltaTime, Space.World);

        if (move != Vector3.zero)
        {
            Rotation(move);
        }

        velocity.y = -2f;
        characterController.Move(velocity * Time.deltaTime);


    }
    void Rotation(Vector3 move)
    {
        Quaternion rotacion = Quaternion.LookRotation(move, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotacion, rotationSpeed * Time.deltaTime);
    }
}
