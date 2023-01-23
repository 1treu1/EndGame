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
    public AudioSource audi;
    public AudioClip shoot;
    private float shotRateTime = 0;
    public float shotRate = 0.0f;
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
            OnShoot();
            if (Time.time > shotRateTime)
            {
                //Debug.Log("Fire");
                Fire();
                shotRateTime = Time.time + shotRate;
            }
            
            
        }
        else
        {
            OnNoShoot();
        }
        
    }
    void Fire()
    {
        GameObject newBullet = Instantiate(bullet, spawnBullet.position, spawnBullet.rotation);
        audi.PlayOneShot(shoot);
        Rigidbody rb = newBullet.GetComponent<Rigidbody>();
        rb.AddForce(spawnBullet.forward * speed, ForceMode.Impulse);
        Destroy(newBullet, 1.0f);
    }
}
