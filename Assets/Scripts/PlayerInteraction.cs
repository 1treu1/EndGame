using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject deck;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
       
        if (other.CompareTag("Deck"))
        {
            Debug.Log("Deck");
            deck = other.gameObject.transform.GetChild(0).gameObject;
            deck.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Deck"))
        {
            Debug.Log("Exit Deck");
            deck = other.gameObject.transform.GetChild(0).gameObject;
            deck.SetActive(true);
        }

    }
}
