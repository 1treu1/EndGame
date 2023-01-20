using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    // Start is called before the first frame update
    public delegate void Shooting();
    public static event Shooting OnShoot;
    public delegate void NoShooting();
    public static event NoShooting OnNoShoot;
    public PlayerInput playerinput;
    void Start()
    {
        playerinput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButton(0))
        if (playerinput.actions["Shoot"].IsPressed())
        {
            Debug.Log("Fire");
            OnShoot();
        }
        else
        {
            OnNoShoot();
        }
        
    }
}
