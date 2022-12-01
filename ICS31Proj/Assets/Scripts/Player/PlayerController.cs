using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreDisplay;
    [SerializeField] private int score;
    [SerializeField] private float speed;
    [SerializeField] float jump;
    [SerializeField] bool grounded;

    private float xDirection = 0f;

    private Rigidbody2D rb;
    private Animator anime;



    // Start is called before the first frame update
    private void Start()
    {

        Debug.Log("Loading...");
        score = PlayerPrefs.GetInt("Score");
        rb = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();

    }

    // Update is called once per frame
    private void Update()
    {
        xDirection = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xDirection * speed, rb.velocity.y);

        //Flips player when moving left or right
        if (xDirection > 0.01f)
        {
            transform.localScale = new Vector3(2, 2, 1);
        }
        else if (xDirection < -0.01f)
        {
            transform.localScale = new Vector3(-2, 2, 1);
        }

        //Animation
        anime.SetBool("Run", xDirection != 0);
        anime.SetBool("Grounded", grounded);

        //Detect if the key is pressed down.
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            AddHealth(1);
        }

    }

    private void Jump()
    {
        rb.AddForce(new Vector2(rb.velocity.x, jump));
        grounded = false;
    }

    public void AddScore(int _score)
    {
        score += _score;
        scoreDisplay.text = score.ToString();
    }

    public void AddDamage(int _damage)
    {
        GetComponent<PlayerCombat>().AddDamage(_damage);
    }

    public void AddHealth(int _health)
    {
        GetComponent<Health>().AddHealth(_health);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")   //Prevents spam jumping
        {
            grounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }    
}
