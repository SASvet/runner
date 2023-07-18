using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{

    public float cooldown;
    [HideInInspector] public bool isCooldown;
    private Image shieldImage;
    private PlayerController player;
    // Start is called before the first frame update

    void Start()
    {
        shieldImage = GetComponent<Image>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        isCooldown = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCooldown)
        {
            shieldImage.fillAmount -= 1 / cooldown * Time.deltaTime;
            if (shieldImage.fillAmount <=0)
            {
                shieldImage.fillAmount = 1;
                isCooldown = false;
                gameObject.SetActive(false);
            }
        }
    }


    public void ResetTimer()
    {
        shieldImage.fillAmount = 1;
    }

}
