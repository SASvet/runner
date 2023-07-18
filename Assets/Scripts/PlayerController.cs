using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float JumpForce;

    [SerializeField]
    public bool isGrounded = false;
    public bool crouching;
    public bool Jump = false;
    public int health = 1;
    public Animator animator;
    public TMP_Text healthDisplay;
    public int coins;
    public TMP_Text coinsText;
    public int shield_cost;
    Rigidbody2D RB;
    public Shield shieldTimer;
    public float speed;
    public GameObject effect;
    public GameManager gameManager;

    public AudioSource coinSound;
    public AudioSource jumpSound;
    public AudioSource crouchSound;
    public AudioSource deathSound;
    public AudioSource shieldSound;
    public AudioSource transactionSound;

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
    }
 

    // Update is called once per frame
    void Update()
    {

        float moveAmount = speed * Time.deltaTime;
        transform.Translate(Vector2.right * moveAmount);

        healthDisplay.text = health.ToString();

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (isGrounded == true && crouching == false)
            {
                RB.AddForce(Vector2.up * JumpForce);
               
                animator.SetBool("IsJumping", true);

                jumpSound.Play();
                isGrounded = false;
            }

            else if (crouching == true)
            {
                crouching = false;
                animator.SetBool("IsCrouching", false);
                isGrounded = false;
            }    
        }
        
        if (isGrounded == false)
        {
            animator.SetBool("IsJumping", false);
        }

        if (Input.GetKeyDown(KeyCode.S) && isGrounded == true)
        {
            crouching = true;
            animator.SetBool("IsCrouching", true);
            crouchSound.Play();
        }


        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (coins >= shield_cost)
            {
                coins = coins - shield_cost;
                if (!shieldTimer.gameObject.activeSelf)
                {
                    shieldTimer.gameObject.SetActive(true);

                    shieldTimer.isCooldown = true;
                    //shieldTimer.ResetTimer();
                    Instantiate(effect, transform.position, Quaternion.identity);
                    transactionSound.Play();
                }
                else
                {
                    shieldTimer.ResetTimer();
                    Instantiate(effect, transform.position, Quaternion.identity);
                    transactionSound.Play();
                }

                coinsText.text = coins.ToString();
            }
        }


        if (health == 0) 
        {
            gameManager.RestartGame();
            deathSound.Play();
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            if (isGrounded == false)
            {
                isGrounded = true;
            }
        
        }
        else if (collision.gameObject.CompareTag("killbox"))
        {
            gameManager.RestartGame();
            deathSound.Play();
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "coin")
        {
            coins++;
            coinsText.text = coins.ToString();
            //Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);
            coinSound.Play();
        }
        else if (collision.gameObject.CompareTag("shield"))
        {
            if (!shieldTimer.gameObject.activeSelf)
            {
                shieldTimer.gameObject.SetActive(true);

                shieldTimer.isCooldown = true;
                collision.gameObject.SetActive(false);
                Instantiate(effect, transform.position, Quaternion.identity);
                shieldSound.Play();
            }
            else
            {
                shieldTimer.ResetTimer();
                collision.gameObject.SetActive(false);
                Instantiate(effect, transform.position, Quaternion.identity);
                shieldSound.Play();
            }
        }



    }

    


    private void Crouch()
    {
        if(Input.GetKeyDown(KeyCode.S) && isGrounded == true)
        {
            crouching = true;
            animator.SetBool("IsCrouching", true);
        }
        else
        {
            crouching = false;
            animator.SetBool("IsCrouching", false);

        }
       
    }















}
