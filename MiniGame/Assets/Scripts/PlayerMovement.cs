using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//using UnityEngine.XR;


public class PlayerMovement : MonoBehaviour {
    public VrPrototype controls;
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
    public GameObject Player, Camera;
    public float speed;
    public float startSpeed;
    public float gravity;
    public float jumpHeight;
    public float boostHeight;
    public float speedBoost;
    public float speedDecay;
    public float jumpCooldown;
    public float cooldownCounter;
    public Vector3 spawn;
    public Vector3 direction;
    public Vector2 inputVector;

    public int collection;


    //public PlayerMovement playerMovement = new PlayerMovement();

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
    public Quaternion headYaw;
    private void OnEnable()
    {
       // controls = new VrPrototype();
       // controls.Player.Enable();

        //controls.Player.Jump.performed += Jump;
    }
    private void Start()
    {
        
        victory = false;
        triggered = false;
        startSpeed = speed;
        spawn = new Vector3(-45f, 1.9f, -45f);
        collection = 0;
        audioSource = GetComponent<AudioSource>();
        controller = Player.GetComponent<CharacterController>();
        cooldownCounter = 0.1f;
        jumpCooldown = 0f;

    }

    public void MovementPerformed(InputAction.CallbackContext context)
    {
        
        
        if (context.performed)
        {
            // Debug.Log("Moveeeeeeeeeeeee" + context);
           
            inputVector = context.ReadValue<Vector2>();
            Debug.Log(context.ReadValue<Vector2>());
          
            // float x = inputVector.x;
           // float z = inputVector.y;
            //direction = headYaw * new Vector3(x, 0, z);
        }
       /* if (context.canceled)
        {
            inputVector = new Vector2(0, 0);
        }*/

       // Vector3 move = headYaw * (transform.right * x + transform.forward * z);

    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {

           // Debug.Log("Jump " + isGrounded);

            if (isGrounded == true)
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
            else
            {
                Debug.Log("Nope");
            }
        }


    }
    private void Update()
    {
        if (collection == 4)
        {
            victory = true;
        }
        if (respawn)
        {
            GetComponent<AudioSource>().PlayOneShot(hurt);
            Player.transform.position = spawn;
            respawn = false;
        }
        if (jumpCooldown > 0f)
        {
            // Subtract the difference of the last time the method has been called
            jumpCooldown -= Time.deltaTime;
        }
    }
    void FixedUpdate()
    {
        //Player.GetComponent<isGrounded>;
        //Debug.Log(isGrounded);
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            if (!landed)
            {
                GetComponent<AudioSource>().PlayOneShot(land);
                landed = true;
            }
            velocity.y = -2f;
        }


        headYaw = Quaternion.Euler(0, Camera.transform.eulerAngles.y, 0);
        Vector3 direction = headYaw * new Vector3(inputVector.x, 0, inputVector.y);
        
        
        Vector3 move = headYaw * (transform.right * inputVector.x + transform.forward * inputVector.y);
        BoostPad(onBoostPad, move);
        ConstantPhysics();


    }
  
    
    public void BoostPad(bool status, Vector3 vector3)
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

            controller.Move(vector3 * speed * Time.deltaTime);


        }
        else
        {
            controller.Move(vector3 * speed * Time.deltaTime);

        }

    }

    private void ConstantPhysics()
    { 
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
