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
        { //Detect if the key is pressed down.

            rb.AddForce(new Vector2(rb.velocity.x, jump));

        }

    }

    private void PlayerFacing()
    {

        MovementState playerState;

        if (xDirection < 0f)
        {
            playerState = MovementState.running;
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (xDirection > 0f)
        {
            playerState = MovementState.running;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            playerState = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            playerState = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            playerState = MovementState.falling;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy") 
        {
            SceneManager.LoadScene("MainMenu");
            CameraController.Deactivate();
        }

        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
        if (collision.gameObject.tag == "Finish")
        {
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
