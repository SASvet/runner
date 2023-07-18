using UnityEngine;

public class CrouchController : MonoBehaviour
{

    public BoxCollider2D stand;
    public BoxCollider2D crouch;

    private PlayerController player;


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerController>();
        stand.enabled = true;
        crouch.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (player.isGrounded == false)
        {
            stand.enabled = true;
            crouch.enabled = false;
        }
        else
        {
            if (player.crouching == true)
            {
                stand.enabled = false;
                crouch.enabled = true;
            }
            else
            {
                stand.enabled = true;
                crouch.enabled = false;
            }
        }
    }

}
