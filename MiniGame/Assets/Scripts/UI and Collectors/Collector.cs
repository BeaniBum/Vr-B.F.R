using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour {
    // AudioSource audioSource;
    public PlayerMovement player;
    public GameObject Collectable;
    public Vector3 platformPos;
    public Vector3 startPlatformPos;
    public float distance;
    public float limit;
    public float speed;
    public bool flip;


    // Use this for initialization
    void Start () {

        startPlatformPos = Collectable.transform.position;

    }
	
	// Update is called once per frame
	void Update () {

        platformPos = Collectable.transform.position;
        distance = Vector3.Distance(startPlatformPos, platformPos);

        if (distance >= limit)
        {
            flip = true;
        }

        if (distance <= .2)
        {
            flip = false;
        }

        if (!flip)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        if (flip)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        player.Collected();
        Destroy(Collectable);
    }
}
