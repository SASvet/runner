using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class Coin : MonoBehaviour
{
  
    /*
    public TMP_Text coinsText;
    private float coin;
   // public PlayerController player;

    void start()
    {
        coinsText = GameObject.FindGameObjectWithTag("CoinText").GetComponent<TMP_Text>();
       // player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && PlayerController.coins !=null)
        {
            PlayerController.coins += 1;
            coin = PlayerController.coins;
            coinsText.text = coin.ToString();
            //Destroy(collision.gameObject);
            gameObject.SetActive(false);
        }
    }
    */

    public void Activation()
    {
        gameObject.SetActive(true);
    }
}