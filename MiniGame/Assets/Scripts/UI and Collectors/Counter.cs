using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour {
    public PlayerMovement player;
    public int count;
    public Text textBox;
    public Text challengeText;
    // Use this for initialization
    void Start () {
        count = player.buildMaterial;
	}
	
	// Update is called once per frame
	void Update () {
        count = player.buildMaterial;
        if (!player.victory)
        {
            textBox.text = count.ToString();
        }
        else
        {
            textBox.text = "You Win";
            challengeText.text = "Can You Go Faster?";
        }
    }
}
