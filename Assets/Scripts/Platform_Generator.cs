using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Generator : MonoBehaviour
{

    public GameObject platform;
    public Transform generationPoint;
    private float distanceBetween;
    // private float platformWidth;

   // public ObjectPooler ObjectPool;


    private float[] platformWidths;

    public float DistanceBetweenMin;
    public float DistanceBetweenMax;


    public ObjectPooler[] ObjectPools;

    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;
    private bool spawnCoins;

    // public CoinGenerator coinGenerator;
    // public float randomCoin;


    // private MaceGenerator maceGenerator;

    public ObjectPooler ShieldPool;
    public float randomShield;

    // public GameObject[] platforms;
    private int platformSelector;


    // Start is called before the first frame update
    void Start()
    {
        // platformWidth = platform.GetComponent<BoxCollider2D>().size.x;

        //coin = GameObject.FindGameObjectWithTag("Coin");
        //coin = FindObjectOfType<Coin>();

        platformWidths = new float[ObjectPools.Length];
        for (int i = 0; i < ObjectPools.Length; i++) 
        {
            platformWidths[i] = ObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;

        // coinGenerator = FindObjectOfType<CoinGenerator>();
        //maceGenerator = FindObjectOfType<MaceGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range(DistanceBetweenMin, DistanceBetweenMax);
            platformSelector = Random.Range(0, ObjectPools.Length);

            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);
            if (heightChange > maxHeight)
            {
                heightChange = maxHeight;
            }
            else if (heightChange < minHeight)
            {
                heightChange = minHeight;
            }

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector]/2) + distanceBetween, heightChange, transform.position.z);
           



            //Instantiate(platforms[platformSelector], transform.position, transform.rotation);

           GameObject newPlatform = ObjectPools[platformSelector].GetPooledObject();
           newPlatform.transform.position = transform.position;
           newPlatform.transform.rotation = transform.rotation;
           newPlatform.SetActive(true);


            if (platformSelector != 4)
            {
                ActivateCoinsOnPlatform(newPlatform);
            }

            if (platformSelector == 0)
            {
                ActivateMaceOnPlatform(newPlatform);
             
            }

            if (platformSelector == 1)
            {
                
                ActivateChestOnPlatform(newPlatform);
            }



            // ActivateMaceOnPlatform(newPlatform);

            //coin.SetActive(true);

            // if (platformSelector == 0) 
            // {
            //     maceGenerator.SpawnMace(newPlatform.transform.position + new Vector3(0f, 0.725f, 0f));
            // }



            if (platformSelector == 4)
            {
                if (Random.Range(0f, 100f) < randomShield)
                {
                    GameObject newShield = ShieldPool.GetPooledObject();
                    Vector3 ShieldPosition = new Vector3(-0.083f, 1f, 0f);
                    newShield.transform.position = transform.position+ ShieldPosition;
                    newShield.transform.rotation = transform.rotation;
                    newShield.SetActive(true);
                }
            }


            

            /*if (Random.Range(0f, 100f) < randomCoin)
            {
                coinGenerator.SpawnCoins(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z));
            }

            */

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), transform.position.y, transform.position.z);

        }
    }


    private void ActivateCoinsOnPlatform(GameObject platform)
    {
        Coin[] coins = platform.GetComponentsInChildren<Coin>(true);
        foreach (Coin coin in coins)
        {
            if (coin.CompareTag("coin"))
            {
                coin.gameObject.SetActive(true);
            }
        }
    }


    private void ActivateChestOnPlatform(GameObject platform)
    {
        Chest chest = platform.GetComponentInChildren<Chest>(true);
        if (chest != null && chest.CompareTag("Chest"))
        {
            chest.gameObject.SetActive(true);
        }
    }

    private void ActivateMaceOnPlatform(GameObject platform)
    {
        Mace mace = platform.GetComponentInChildren<Mace>(true);
        if (mace != null && mace.CompareTag("mace"))
        {
            mace.gameObject.SetActive(true);
        }
    }


}
