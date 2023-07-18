using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active_shield : MonoBehaviour
{
    public Shield shieldTimer;
    public GameObject effect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(effect, transform.position, Quaternion.identity);

            if (shieldTimer != null)
            {
                shieldTimer.gameObject.SetActive(true);
                shieldTimer.isCooldown = true;
            }
        }

        Destroy(gameObject);
    }
}
