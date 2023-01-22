using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class GameManager : MonoBehaviour
{
    public static GameManager Instance
    {
        get;
        private set;
    }
    public bool key = false;
    public bool gun1 = true;
    public bool gun2 = false;
    



    private void Awake()
    {
        Instance = this;
    }
   
}
