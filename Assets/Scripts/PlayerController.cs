using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 2.5f;
    public float rotationSpeed;


    void Update()
    {
        //Movimiento del player
        float horizontalInput = Input.GetAxis("Horizontal"); //X
        float verticalInput = Input.GetAxis("Vertical"); //Z
        Vector3 move = new Vector3(horizontalInput,0, verticalInput);
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
