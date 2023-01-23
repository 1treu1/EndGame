using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject deck;
    private GameObject roof;
    private PlayerInput player;
    bool keyStatus = false;
    bool gun1Status = false;
    bool gun2Status = false;
    public GameObject[] objecto;
    public GameObject[] button;
    void Start()
    {
        player = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        Objects();
    }
    void Objects()
    {
        if (GameManager.Instance.key)
        {
            objecto[3].SetActive(true);
        }
        
        if (player.actions["Key"].WasPressedThisFrame() && GameManager.Instance.key)
        {

            keyStatus = !keyStatus;
            if (keyStatus == true)
            {
                Debug.Log("Show key");
                objecto[0].SetActive(true);
                objecto[1].SetActive(false);
                objecto[2].SetActive(false);
                button[0].SetActive(false);
                button[1].SetActive(false);
                button[2].SetActive(true);

            }
            else
            {
                objecto[0].SetActive(false);
                objecto[1].SetActive(false);
                objecto[2].SetActive(false);
                button[0].SetActive(false);
                button[1].SetActive(false);
                button[2].SetActive(false);

            }
        }
        if (player.actions["Gun1"].WasPressedThisFrame() && GameManager.Instance.gun1)
        {

            gun1Status = !gun1Status;
            if (gun1Status == true)
            {
                Debug.Log("Show Gun 1");
                objecto[0].SetActive(false);
                objecto[1].SetActive(true);
                objecto[2].SetActive(false);
                button[0].SetActive(true);
                button[1].SetActive(false);
                button[2].SetActive(false);
            }
            else
            {
                objecto[0].SetActive(false);
                objecto[1].SetActive(false);
                objecto[2].SetActive(false);
                button[0].SetActive(false);
                button[1].SetActive(false);
                button[2].SetActive(false);
            }
        }
        if (player.actions["Gun2"].WasPressedThisFrame() && GameManager.Instance.gun2)
        {

            gun2Status = !gun2Status;
            if (gun2Status == true)
            {
                Debug.Log("Show Gun2");
                objecto[0].SetActive(false);
                objecto[1].SetActive(false);
                objecto[2].SetActive(true);
                button[0].SetActive(false);
                button[1].SetActive(true);
                button[2].SetActive(false);
                
            }
            else
            {
                objecto[0].SetActive(false);
                objecto[1].SetActive(false);
                objecto[2].SetActive(false);
                button[0].SetActive(false);
                button[1].SetActive(false);
                button[2].SetActive(false);
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        //Debug.Log(other.name);
        if (GameManager.Instance.key && keyStatus)
        {
            if (other.CompareTag("Deck"))
            {
                //Debug.Log("Deck");
                deck = other.gameObject.transform.GetChild(0).gameObject;
                deck.SetActive(false);
            }
            if (other.CompareTag("Floor"))
            {
                roof = other.gameObject.transform.GetChild(0).gameObject;
                //Debug.Log("Floor");
                deck.SetActive(false);
                roof.SetActive(false);
            }
        }
            
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.name);
        if (other.CompareTag("Deck"))
        {
            //Debug.Log("Exit Deck");
            deck = other.gameObject.transform.GetChild(0).gameObject;
            deck.SetActive(true);
        }
        if (other.CompareTag("Floor"))
        {
            roof = other.gameObject.transform.GetChild(0).gameObject;
            //Debug.Log("Floor");
            deck.SetActive(true);
            roof.SetActive(true);
        }
    }


}

