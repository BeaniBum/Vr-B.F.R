using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;


public class HandsInput : MonoBehaviour
{
    //vr controller implementation
    public InputDeviceCharacteristics controllerCharacteristics;
    private InputDevice targetDevice;
    private GameObject spawnedController;
    public PlayerMovement player; 
    public   GameObject  playerFetcher;
    private GameObject eventSystem;
    public StateManager State;
    

    [Header("Controller Orientation")]
    [SerializeField]
    private bool right;
    [SerializeField]
    private bool left;

    [Header("Right Bools")]
    public bool rightPrimaryPressed;
    public bool rightSecondaryPressed;
    public bool rightTriggerPressed;

    [Header("Left Bools")]
    public bool leftPrimaryPressed;
    public bool leftSecondaryPressed;
    public bool leftTriggerPressed;

    private Vector2 inputAxis,selectAxis;



    


    // Start is called before the first frame update
    void Start()
    {
       playerFetcher = GameObject.FindWithTag("Player");
        Debug.Log(playerFetcher.tag);
       player = playerFetcher.GetComponent<PlayerMovement>();
       
        eventSystem = GameObject.FindWithTag("StateManagement");
       State = eventSystem.GetComponent <StateManager>();

        List<InputDevice> devices = new List<InputDevice>();

        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);


        if (devices.Count > 0)
        {
            targetDevice = devices[0];
        }
        
    }

    // Update is called once per frame
        public void Update()
    {
        if(right)
        {
            targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool rightPrimaryPressed);
            targetDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool rightSecondaryPressed);
            targetDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool rightTriggerPressed);
            targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
            Debug.Log(State.CurrentState());
            switch (State.CurrentState())
            {
                case (States.Menu):
                    {
                        if (rightPrimaryPressed)
                        {

                        }

                        break;
                    }
                case (States.Build):
                    {
                        if (rightPrimaryPressed)
                        {

                        }
                        break;
                    }
                case (States.Run):
                    {
                        Debug.Log(inputAxis);
                        if (rightPrimaryPressed)
                        {
                            if (player.jumpCooldown <= 0 && rightPrimaryPressed)
                            {
                                //player.Jump(player.isGrounded);
                                player.jumpCooldown = player.cooldownCounter;
                            }
                           
                        }

                        break;
                    }
            }

        }
        if(left)
        {
            targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool leftPrimaryPressed);
            targetDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool leftSecondaryPressed);
            targetDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool leftTriggerPressed);
            //targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out selectAxis);
        }

       // Debug.Log(State.CurrentState());
       
         
    }
 
}
