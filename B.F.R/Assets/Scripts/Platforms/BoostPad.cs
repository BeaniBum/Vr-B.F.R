using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPad : MonoBehaviour {

    public GameObject playerFetcher;
    public PlayerMovement player;
    

    // Use this for initialization
    void Start()
    {
        playerFetcher = GameObject.FindWithTag("Player");
        player = playerFetcher.GetComponent<PlayerMovement>();
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
