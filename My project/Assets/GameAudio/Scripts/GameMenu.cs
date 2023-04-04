using UnityEngine;
using UnityEngine.Audio;  //addition of Audio namespace

public class GameMenu : MonoBehaviour
{
    public AudioMixerSnapshot paused;
    public AudioMixerSnapshot unpaused;
    
    void Start()
    {
        if (paused == null || unpaused == null)
        {
            this.enabled = false;  //disable the component if missing snapshots
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }
        
    }

    private void Pause()
    {
        Time.timeScale = Time.timeScale == 1 ? 0 : 1;
        if (Time.timeScale > 0) //if time is not paused
        {
            unpaused.TransitionTo(.01f);
        }
        else
        {
            paused.TransitionTo(.01f);
        }
    }
}
