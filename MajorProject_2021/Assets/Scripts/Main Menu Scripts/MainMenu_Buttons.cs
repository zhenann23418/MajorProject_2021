using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//In order to change scenes, you need to use the line below: 
using UnityEngine.SceneManagement;

public class MainMenu_Buttons : MonoBehaviour
{
    //for the CPR Button -> leads to the CPR scene to play the animations
    public void PlayCPR()
    {
        SceneManager.LoadScene("CPR Animation Scene");
    }

    //For the Grease Fire Button -> leads to the Grease Fire scene to play the animations
    public void PlayGreaseFire()
    {
        SceneManager.LoadScene("Grease Fire Animation Scene");
    }

    //For the exit button -> basically allows the user to quit the program
    public void QuitApplication()
    {
        Application.Quit();
    }
}
