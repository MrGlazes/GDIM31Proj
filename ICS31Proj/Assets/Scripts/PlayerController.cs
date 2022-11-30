using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI scoreDisplay;
    private int score;
    public float speed;
    public float jump;
    private bool grounded;

    private float xDirection = 0f;

    private Rigidbody2D rb;
    private Animator anime;

    private enum MovementState { idle, running, jumping, falling }

    // Start is called before the first frame update
    private void Start()
    {

        Debug.Log("Loading...");

        rb = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();

    }

    // Update is called once per frame
    private void Update()
    {

        xDirection = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(xDirection * speed, rb.velocity.y);

        

        //Detect if the key is pressed down.
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        { 
            rb.AddForce(new Vector2(rb.velocity.x, jump));
        }
        
        else if (rb.velocity.y > .1f)
        {
            anime.SetTrigger("Jump");
            grounded = false;
            anime.SetBool("Grounded", grounded);
        }

        else if (rb.velocity.y < -.1f)
        {
            anime.SetTrigger("Fall");
        }

        if (xDirection > 0)
        {
            anime.SetTrigger("Run");
            GetComponent<SpriteRenderer>().flipX = false;
            direction = 1;
        }

        else if (xDirection < 0)
        {
            anime.SetTrigger("Run");
            GetComponent<SpriteRenderer>().flipX = true;
            direction = -1;
        }

        else
        {
            anime.SetTrigger("Idle");
        }
        
        if (rb.velocity.y == 0)
        {
            grounded = true;
            anime.SetBool("isGrounded", grounded);
        }

        else
        {
            grounded = false;

        }

        anime.SetFloat("Speed", Mathf.Abs(xDirection));

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")    //"Kills" the player and sends them back to menu by changing back to that scene.
        {                                           //Will be changed when health system is added
            SceneManager.LoadScene("MainMenu");
            CameraController.Deactivate();
        }

        if (collision.gameObject.tag == "Ground")   //Prevents spam jumping
        {
            grounded = true;
        }

        if (collision.gameObject.tag == "Finish")   //Similar to running into an enemy, will send player to menu.
        {                                           //When new levels are created, will load next scene by index
            SceneManager.LoadScene("MainMenu");
            CameraController.Deactivate();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            score += 100;
            scoreDisplay.text = score.ToString();
        }
    }
    

}
