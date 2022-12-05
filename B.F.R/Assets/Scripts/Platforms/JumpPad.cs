using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour {

    public GameObject playerFetcher;
    public PlayerMovement player; 

	// Use this for initialization
	void Start () {
        playerFetcher = GameObject.FindWithTag("Player");
        player = playerFetcher.GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        player.OnJumpPad();
    }

    private void OnTriggerExit(Collider other)
    {
        player.OffJumpPad();
    }
}
