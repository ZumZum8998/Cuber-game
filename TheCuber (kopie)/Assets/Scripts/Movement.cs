using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour

{

    public int maxHealth = 100;
    public int currentHealth;
  
    AudioSource jumpsound;
    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sprRend;
    private ParticleSystem particle;





    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

    public HealthBar healthBar;


    void Start()
    {
        
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        jumpsound = GetComponent<AudioSource>();
        
        animator = GetComponent<Animator>();
        sprRend = GetComponent<SpriteRenderer>();
        particle = GetComponent<ParticleSystem>();

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }


    void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        Debug.Log(moveInput);
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);


    }

    void Update()
    {
        if (moveInput > 0f)
        {
            sprRend.flipX = false;
        } else if (moveInput < 0f)
        {
            sprRend.flipX = true;
        }
        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
            AddHealth(20);

        }
        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            jumpsound.Play();
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true)
        {
            jumpsound.Play();
            rb.velocity = Vector2.up * jumpForce;
        }

        if (moveInput != 0)
        {
            animator.SetBool("walking", true);

        }
        else
        {
            animator.SetBool("walking", false);
        }



        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }

       










    }

    void TakeDamage(int damage)
    {


        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }
    }
    void AddHealth(int AddHealth)
    {


        currentHealth += AddHealth;
        healthBar.SetHealth(currentHealth);
        if(currentHealth >= 100)
        {
            currentHealth = 100;
        }
    }




}
