using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 2.5f;


    void Update()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal"); //X
        float verticalInput = Input.GetAxis("Vertical"); //Z

        Vector3 move = transform.right * horizontalInput + transform.forward * verticalInput;

        characterController.Move(move * speed * Time.deltaTime);


    }
}
