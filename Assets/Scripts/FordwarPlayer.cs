using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FordwarPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.position + new Vector3(0, 10.45f, -5.48f);
       
    }
}
