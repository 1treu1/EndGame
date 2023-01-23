using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Health : MonoBehaviour
{
    private Image healtBar;
    private TextMeshProUGUI counteeHealt;
    void Start()
    {
        healtBar = GetComponent<Image>();
        counteeHealt = gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        healtBar.fillAmount = GameManager.Instance.health / GameManager.Instance.maxHealth;
        counteeHealt.text = (healtBar.fillAmount* GameManager.Instance.maxHealth).ToString();
    }
}
