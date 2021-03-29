using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public float distanceTraveled;
    public int collectedCoins;

    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public float jumpForce = 5;
    [SerializeField] Transform raycast;
    [SerializeField] bool isGrounded;
    [SerializeField] bool airJump;
    [SerializeField] bool checkSheild;
    [SerializeField] GameObject mySheild;
    [SerializeField] SFXManager sfxManager;
    [SerializeField] UIController uiController;
    [SerializeField] Animator anim;


    bool jump;
    float lastYPos;
    bool playerIsFalling;
    
    
    void Start()
    {
        lastYPos = transform.position.y;
    }

    void Update()
    {
        distanceTraveled += Time.deltaTime;
        CheckForInput();
        CheckIfPlayerIsFalling();
        

    }
    void FixedUpdate() //used for physics 
    {
        CheckForGrounded();
        CheckForJump();
    }
    void CheckForInput()
    {
        if (isGrounded == true || airJump == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(airJump == true && isGrounded == false)
                {
                    airJump = false;
                    sfxManager.PlaySFX("DoubleJump");
                }
                else
                {
                    sfxManager.PlaySFX("Jump");
                }
                jump = true;
                anim.SetTrigger("Jump");
            }
        }
    }

    void CheckForGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(raycast.position, Vector2.down);
        if (hit.collider != null)
        {
            if (hit.distance < 0.1f)
            {
                isGrounded = true;
                anim.SetBool("IsGrounded", true);
                if(playerIsFalling == true)
                {
                    sfxManager.PlaySFX("Land");

                }
            }
            else
            {
                isGrounded = false;
               

            }
            Debug.DrawRay(raycast.position, Vector2.down, Color.green);
        }
        else 
        { 
            isGrounded = false;
            anim.SetBool("IsGrounded", false);
        }
        
    }
    void CheckForJump()
    {
        if (jump == true)
        {
            jump = false;
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

        }
    }
    void CheckIfPlayerIsFalling()
    {
        if (transform.position.y < lastYPos)
        {
            anim.SetBool("Falling", true);
            playerIsFalling = true;

        }
        else
        {
            anim.SetBool("Falling", false);
            playerIsFalling = false;
        }
        lastYPos = transform.position.y;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Obstacle"))
        {
           if(checkSheild == true)
            {
                
                mySheild.SetActive(false);
                checkSheild = false;
                sfxManager.PlaySFX("ShieldBreak");
                Destroy(collision.gameObject);
            }
            else
            {
                uiController.ShowGameOverScreen();

            }
        }

        if(collision.transform.CompareTag("DeathBox"))
        {
            sfxManager.PlaySFX("GameOverHit");
            uiController.ShowGameOverScreen();
        }
       


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectable"))
        {
            collectedCoins++;
            sfxManager.PlaySFX("Coin");
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("AirJump"))
        {
            airJump = true;
            sfxManager.PlaySFX("PowerupDoubleJump");
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Sheild"))
        {
            checkSheild = true;
            mySheild.SetActive(true);
            sfxManager.PlaySFX("PowerupShield");
            Destroy(collision.gameObject);
        }
    }
}
