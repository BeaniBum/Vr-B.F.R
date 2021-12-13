using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum States
{
    Menu,
    Build,
    Run
}
public class StateManager : MonoBehaviour
{

    public States activeState;
    // Start is called before the first frame update
    void Start()
    {
        activeState = States.Run;
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
