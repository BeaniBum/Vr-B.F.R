using UnityEngine;
using UnityEngine.Audio;

public class AudioWeatherVane : MonoBehaviour
{
    public ParticleSystem particleTracker; //ParticleSystem must have ExternalForces set
    public AudioMixer masterMixer;
    public string volumeControl = "windVolume";
    public float multiplier = 1f;
    public float offset = -20f;
    public float avgWindMagnitude;
    private ParticleSystem.Particle[] particles;

    void Start()
    {
        particles = new ParticleSystem.Particle[10];
    }

    //FixedUpdate runs every physics update
    void FixedUpdate()
    {
        var magnitude = 0f;
        if (particleTracker.GetParticles(particles) > 0)
        {
            for (int i = 0; i < particles.Length; i++)
            {
                magnitude += particles[i].velocity.magnitude;
            }
            avgWindMagnitude = magnitude / particles.Length;
            masterMixer.SetFloat(volumeControl, avgWindMagnitude * multiplier + offset);
        }
    }   
}