using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeAudioCollider : MonoBehaviour {
    public float volumeRatio = 10.0f;
    public float pitchRatio = 10f;
    private AudioSource audioSource;
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();        
	}
    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 2)
        {
            var magnitude = collision.relativeVelocity.magnitude;
            var volume = Mathf.Clamp01(magnitude / volumeRatio);
            var pitch = magnitude / pitchRatio;
            audioSource.volume = volume;
            audioSource.pitch = pitch;
            audioSource.Play();
        }
    }

}
