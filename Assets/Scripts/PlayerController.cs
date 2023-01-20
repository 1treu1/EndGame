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
        Vector3 move = playerinput.actions["Move"].ReadValue<Vector3>();
        //Vector3 move = new Vector3(horizontalInput,0, verticalInput);
        characterController.Move(move * speed * Time.deltaTime);
        move.Normalize();
        //Rotacion del personaje
        transform.Translate(move * rotationSpeed * Time.deltaTime, Space.World);
        
        if(move != Vector3.zero)
        {
            Quaternion rotacion = Quaternion.LookRotation(move, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotacion, rotationSpeed * Time.deltaTime);
        }
        

    }
}
