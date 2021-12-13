using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    AudioSource audioSource;
    [SerializeField]
    private AudioClip normalJump;
    [SerializeField]
    private AudioClip boostJump;
    [SerializeField]
    private AudioClip land;
    [SerializeField]
    private AudioClip boostPad;
    [SerializeField]
    private AudioClip collectableSound;
    [SerializeField]
    private AudioClip hurt;
    public CharacterController controller;
    public GameObject Player;
    public float speed;
    public float startSpeed;
    public float gravity;
    public float jumpHeight;
    public float boostHeight;
    public float speedBoost;
    public float speedDecay;
    public Vector3 spawn;

    public int collection;


    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    bool onJumpPad;
    bool onBoostPad;
    bool triggered;
    bool respawn;
    bool landed;
    public bool victory;

    // Update is called once per frame
    private void Start()
    {
        victory = false;
        triggered = false;
        startSpeed = speed;
        spawn = new Vector3(-45f, 1.9f, -45f);
        collection = 0;
        audioSource = GetComponent<AudioSource>();
    }

    void Update ()
    {
        Debug.Log(collection);
        if(collection == 4)
        {
            victory = true;
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(respawn)
        {
            GetComponent<AudioSource>().PlayOneShot(hurt);
            Player.transform.position = spawn;
            respawn = false;
        }

        if (isGrounded && velocity.y <0)
        {
            if(!landed)
            {
                GetComponent<AudioSource>().PlayOneShot(land);
                landed = true;
            }
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x +transform.forward * z;

        

        if(onBoostPad)
        {
            isGrounded = true;
            if (triggered == false)
            {
                GetComponent<AudioSource>().PlayOneShot(boostPad);
                speed += speedBoost;
                triggered = true;
            }
            
            controller.Move(move * speed * Time.deltaTime);


        }
        else
        {
            controller.Move(move * speed * Time.deltaTime);

        }

        if(!onBoostPad)
        {
            if(speed>startSpeed)
            {
                speed -= speedDecay ;
            }
            if(speed<startSpeed)
            {
                speed = startSpeed;
            }
        }

 
       
            
        
        

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            landed = false;
            if(onJumpPad)
            {
                GetComponent<AudioSource>().PlayOneShot(boostJump);
                velocity.y = Mathf.Sqrt(jumpHeight+boostHeight * -2f * gravity);
            }
            else
            {
                GetComponent<AudioSource>().PlayOneShot(normalJump);
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
            
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

	}

    public void OnJumpPad()
    {
        onJumpPad = true;
    }

    public void OffJumpPad()
    {
        onJumpPad = false;
    }

    public void OnBoostPad()
    {
        onBoostPad = true;
        
    }

    public void OffBoostPad()
    {
        onBoostPad = false;
        triggered = false;
    }

    public void Respawn()
    {
        respawn = true;
    }
    
    public void Collected()
    {
        collection++;
    }
}
