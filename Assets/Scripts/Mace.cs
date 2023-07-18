using UnityEngine;

public class Mace : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D other)
    {
        
        GameObject shieldTimer = GameObject.Find("ShieldTimer");
        if (other.CompareTag("Player"))
        {
            if (other.CompareTag("Player") && (shieldTimer == null || !shieldTimer.activeSelf))
            {
                other.GetComponent<PlayerController>().health -= 1;
            }
            gameObject.SetActive(false);
        }
    }
}



