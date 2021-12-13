using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    public PlayerMovement player;
    public float timeStart;
    public float currentTime;
    public Text textBox;

	// Use this for initialization
	void Start () {
        textBox.text = timeStart.ToString("F2");
        
	}
	
	// Update is called once per frame
	void Update () {
        
        
        if (player.victory == false)
        {
            timeStart += Time.deltaTime;
            textBox.text = timeStart.ToString("F2");

        }
       else
        {
           currentTime = timeStart;
           textBox.text = currentTime.ToString("F2");
        }
        
        
	}
}
