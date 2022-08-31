using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum States
{
    Menu,
    Build,
    Run
}
public enum Platform
{
    BoostPad,
    JumpPad,
    MovingPlatform
}
public class StateManager : MonoBehaviour
{

    public States activeState;
    public Platform activePlatform;
    // Start is called before the first frame update
    void Start()
    {
        activeState = States.Run;
        activePlatform = Platform.JumpPad;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public States CurrentState()
        {
            return activeState;
        }
}
