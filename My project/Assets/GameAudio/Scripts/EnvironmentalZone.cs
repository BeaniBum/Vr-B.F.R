using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EnvironmentalZone : MonoBehaviour {
    public AudioMixerSnapshot zone;    
    public float transitionTime;
    public float influence = 1; //the range of the zone
    public float weight = 5; //the amount of impact the zone has

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, influence);  
    }

}
