using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(RigidbodyFirstPersonController))]
public class FootstepsAudio : MonoBehaviour
{
    public AudioClip[] footstepSounds;
    public float runstepLenghten;
    public float speed;
    public float stepInterval;

    private RigidbodyFirstPersonController characterController;
    private AudioSource audioSource;            
    private float stepCycle;
    private float nextStep;     

    void Start()
    {        
        characterController = GetComponent<RigidbodyFirstPersonController>();
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        switch (AdaptiveAudioManager.Instance.currentAdaptiveLevel)
        {
            case 0:
            case 2:
                speed = 1; stepInterval = 3;
                Time.timeScale = 1f;
                break;
            case 1:
                speed = .5f; stepInterval = 2.5f;
                Time.timeScale = .5f;
                break;
            case 3:
                speed = 1.5f; stepInterval = 2.5f;
                Time.timeScale = 1.5f;
                break;
            case 4:
                speed = 2.5f; stepInterval = 3.5f;
                Time.timeScale = 2f;
                break;
            case 5:
                speed = 3.5f; stepInterval = 5f;
                Time.timeScale = 2.5f;
                break;
        }
                ProgressStepCycle(speed);
    }
    private void ProgressStepCycle(float speed)
    {        
        if (characterController.Velocity.sqrMagnitude > 0 )
        {
            stepCycle += (characterController.Velocity.magnitude + (speed 
                * (characterController.Running ? runstepLenghten : 1f))) 
                * Time.fixedDeltaTime;
        }

        if (!(stepCycle > nextStep))
        {
            return;
        }

        nextStep = stepCycle + stepInterval;

        PlayFootStepAudio();
    }
    
    private void PlayFootStepAudio()
    {
        if (characterController.Grounded == false)
        {
            return;
        }
        // pick & play a random footstep sound from the array,
        // excluding sound at index 0
        int n = Random.Range(1, footstepSounds.Length);
        audioSource.clip = footstepSounds[n];
        audioSource.PlayOneShot(audioSource.clip);
        // move picked sound to index 0 so it's not picked next time
        footstepSounds[n] = footstepSounds[0];
        footstepSounds[0] = audioSource.clip;
    }
}
