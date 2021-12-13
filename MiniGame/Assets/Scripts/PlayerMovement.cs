using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.XR;


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

    public Vector3 velocity;
    public bool isGrounded;
    bool onJumpPad;
    bool onBoostPad;
    bool triggered;
    bool respawn;
    bool landed;
    public bool victory;

    //control vars
    public HandsInput rightHand, leftHand;





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

    void Update()
    {

        Debug.Log(collection);
        if (collection == 4)
        {
            victory = true;
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (respawn)
        {
            GetComponent<AudioSource>().PlayOneShot(hurt);
            Player.transform.position = spawn;
            respawn = false;
        }

        if (isGrounded && velocity.y < 0)
        {
            if (!landed)
            {
                GetComponent<AudioSource>().PlayOneShot(land);
                landed = true;
            }
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        BoostPad(onBoostPad, move);

        ConstantPhysics();


    }
    public void Jump(bool rightPrimaryPressed, bool groundCheck)
    {
        if (rightPrimaryPressed && groundCheck)
        {
            landed = false;
            if (onJumpPad)
            {
                GetComponent<AudioSource>().PlayOneShot(boostJump);
                velocity.y = Mathf.Sqrt(jumpHeight + boostHeight * -2f * gravity);
            }
            else
            {
                GetComponent<AudioSource>().PlayOneShot(normalJump);
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }

    }
    public void BoostPad(bool status, Vector3 move)
        {
         if (!status)
        {
            if (speed > startSpeed)
            {
                speed -= speedDecay;
            }
            if (speed < startSpeed)
            {
                speed = startSpeed;
            }
        }
        if (status)
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

    }

    private void ConstantPhysics()
    {
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
   
    
        
        /*public bool Jump( )
    {
        return true;
    }*/


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
