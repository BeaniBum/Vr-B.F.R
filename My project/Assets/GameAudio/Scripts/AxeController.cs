using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeController : MonoBehaviour {
    public GameObject AxePrefab;
    private AudioSource[] audioSources;

    // Use this for initialization
    void Start () {
        audioSources = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            foreach (var audioSource in audioSources)
            {
                if (audioSource.isPlaying) return;
                audioSource.pitch = 1.0f + Random.Range(-.1f, .1f);
                audioSource.volume = 1.0f - Random.Range(0.0f, .25f);                
                audioSource.Play();
            }
            var axe = Instantiate(AxePrefab,
                transform.position, Quaternion.LookRotation(
                transform.forward, transform.up));
            var rigidBody = axe.GetComponent<Rigidbody>();
            rigidBody.AddForce(transform.forward * 10f, ForceMode.Impulse);
            rigidBody.AddTorque(transform.right * -10f, ForceMode.Impulse);
        }
    }
}
