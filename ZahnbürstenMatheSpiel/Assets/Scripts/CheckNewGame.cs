using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckNewGame : MonoBehaviour
{
    int gameWasAlreadyStart;

    private void Start()
    {
        gameWasAlreadyStart = PlayerPrefs.GetInt("gameWasAlreadyStart");

        
        if (gameWasAlreadyStart == 0)
        {
            PlayerPrefs.SetInt("mute", 1);
            PlayerPrefs.SetInt("Difficulty", 1);
            PlayerPrefs.SetInt("kommazahlenErlaubt", 0);
            PlayerPrefs.SetInt("zahlUnterNull", 0);
            PlayerPrefs.SetInt("gameWasAlreadyStart", 1);
            PlayerPrefs.Save();
        }
        
        
    }


}
