using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private float direction = 0f;
    public float jumpspeed = 8f;
    private Rigidbody2D player;
    private bool isTouchingGround;

    public Transform groundcheck;
    public float groundcheckRadius;
    public LayerMask groundlayer;

    private Animator animator;

    private Vector3 respawnpoint;
    public GameObject Falldetector;

    public TMP_Text ScoreText;

    public HealthBar healthBar;


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        respawnpoint = transform.position;
        ScoreText.text = "Score: " + Scoring.totalScore;
    }

    // Update is called once per frame
    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundcheck.position, groundcheckRadius, groundlayer);
        direction = Input.GetAxis("Horizontal");

        if (direction > 0f)
        {
            player.velocity = new Vector2 (direction * speed, player.velocity.y);
        }
        else if (direction < 0f)
        {
            player.velocity = new Vector2 (direction * speed, player.velocity.y);
        }
        else
        {
            player.velocity = new Vector2(0,player.velocity.y);
        }

        if (Input.GetButtonDown("Jump") )
        {
            player.velocity = new Vector2(player.velocity.x, jumpspeed);
        }
        animator.SetFloat("Speed", Mathf.Abs(player.velocity.x));
        animator.SetBool("onGround", isTouchingGround);

        Falldetector.transform.position = new Vector2(transform.position.x, Falldetector.transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FallDetector")
        {
            transform.position = respawnpoint;
        }
        else if (collision.tag == "Coin")
        {
            Scoring.totalScore += 1;
            ScoreText.text = "Score: " + Scoring.totalScore;
            SoundManager.instance.coinsound.PlayOneShot(SoundManager.instance.sound);
            collision.gameObject.SetActive(false);
        }
        //else if (collision.tag == "Coin")
        //{
        //    SoundManager.instance.coinsound.PlayOneShot(SoundManager.instance.sound);
        //}
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Spike")
        {
            healthBar.Damage(0.002f);
        }
    }
}
