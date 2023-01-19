using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    // Start is called before the first frame update
    public delegate void Shooting();
    public static event Shooting OnShoot;
    public delegate void NoShooting();
    public static event NoShooting OnNoShoot;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
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
