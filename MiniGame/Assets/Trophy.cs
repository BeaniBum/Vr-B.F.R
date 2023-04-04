using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Trophy : MonoBehaviour
{
    public PlayerMovement player;
    public Timer timer;
   // private string LevelOne = "Level1Time";
    public Scene scene;

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        SaveNumber();
        SceneManager.LoadScene("Menu");
        
    }
    public void SaveNumber()
    {
        float i = timer.timeStart;
        if (scene.name == "Level 1")
        {
            if(i < PlayerPrefs.GetFloat("Level1Time") || PlayerPrefs.GetFloat("Level1time")==0)
            {
                PlayerPrefs.SetFloat("Level1Time", i);
                PlayerPrefs.Save();
            }
            
            Debug.Log(PlayerPrefs.GetFloat("Level1Time").ToString());
        }
       
        
        
    }

    /* how to load stuff with player prefs
     * float playerPositionX = PlayerPrefs.GetFloat("playerPositionX");
     checks if save exists
    if(PlayerPrefs.HasKey("PlayerpositionX))
    {
    do all the stuff if we have a key
    }

    PlayerPrefs.DeleteAll();
    */
}
