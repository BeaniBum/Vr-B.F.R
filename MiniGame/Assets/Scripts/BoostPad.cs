using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPad : MonoBehaviour {

    public PlayerMovement player;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        player.OnBoostPad();
    }

    private void OnTriggerExit(Collider other)
    {
        player.OffBoostPad();
    }
}
