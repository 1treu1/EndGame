using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.health -= 10;
            if (GameManager.Instance.health <= 0)
            {
                GameManager.Instance.health = 0;
                Debug.Log("GameOver");
                Destroy(other.gameObject, 0.5f);
            }
        }
    }
}
