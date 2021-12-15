using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
    public AudioSource audioSource;
    [SerializeField]
    private AudioClip platformSound;

    public GameObject Platform;

    public bool forward;
    public bool back;
    public bool left;
    public bool right;
    public bool up;
    public bool down;
    public float speed;
    public Vector3 platformPos;
    public Vector3 startPlatformPos;
    public float distance;
    public float limit;
    public bool flip;
    /*
    public float startDistanceX;
    public float startDistanceY;
    public float startDistanceZ;
    
    public float distanceY;
    public float distanceZ;
    */

    // Use this for initialization
    void Start ()
    {

       //forward = false;
        //back = false;
        //left = false;
       // right = false;
       // up = false;
       // down = false;
       // flip = false;
       // speed = 2f;
       // distance = 0f;
      //  limit = 8f;     
        startPlatformPos = Platform.transform.position;
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        platformPos = Platform.transform.position;
        distance = Vector3.Distance(startPlatformPos, platformPos);

       // Debug.Log(distance);

        if (distance >= limit)
        {
            flip = true;
            GetComponent<AudioSource>().PlayOneShot(platformSound);
        }

        if (distance <= .2)
        {
            flip = false;
            GetComponent<AudioSource>().PlayOneShot(platformSound);
        }

        if (forward)
       {
            if(!flip)
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);                
            }
            if(flip)
            {
                transform.Translate(Vector3.back * speed * Time.deltaTime);                
            }                                
       }

        if (back)
        {
            if (!flip)
            {
                transform.Translate(Vector3.back * speed * Time.deltaTime);
            }
            if (flip)
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
        }

        if(left)
        {
            
            if (!flip)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            if (flip)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
        }
       if (up)
        {

            if (!flip)
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
            if (flip)
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
        }

        if (down)
        {          
            if (!flip)
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
            if (flip)
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
        }

        if (right)
        {
            if (!flip)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            if (flip)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
        }
    }

  //  public void StatChecker(List<bool> stats)
  //  {
        
 //   }

}