using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    public GameObject shieldTimer;
    public int damage = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        shieldTimer = GameObject.Find("ShieldTimer");
        if (other.CompareTag("Player") && (shieldTimer == null || !shieldTimer.activeSelf))
        {
            other.GetComponent<PlayerController>().health -= damage;
            
        }
      
        gameObject.SetActive(false);

    }
}


