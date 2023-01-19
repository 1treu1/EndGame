using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject deck;
    private GameObject roof;
    void Start()
    {
        roof = GameObject.FindGameObjectWithTag("Roof");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.name);
        if (other.CompareTag("Deck"))
        {
            Debug.Log("Deck");
            deck = other.gameObject.transform.GetChild(0).gameObject;
            deck.SetActive(false);
        }
        if (other.CompareTag("Floor"))
        {
            Debug.Log("Floor");
            roof.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.name);
        if (other.CompareTag("Deck"))
        {
            Debug.Log("Exit Deck");
            deck = other.gameObject.transform.GetChild(0).gameObject;
            deck.SetActive(true);
        }
        if (other.CompareTag("Floor"))
        {
            Debug.Log("Floor");
            roof.SetActive(true);
        }
    }

}

