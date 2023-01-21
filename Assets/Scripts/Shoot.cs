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
    public Transform spawnBullet;
    public GameObject bullet;
    public float speed = 10f;
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
            Fire();
            OnShoot();
        }
        else
        {
            OnNoShoot();
        }
        
    }
    void Fire()
    {
        GameObject newBullet = Instantiate(bullet, spawnBullet.position, spawnBullet.rotation);
        Rigidbody rb = newBullet.GetComponent<Rigidbody>();
        rb.AddForce(spawnBullet.forward * speed, ForceMode.Impulse);
        Destroy(newBullet, 1.0f);
    }
}
