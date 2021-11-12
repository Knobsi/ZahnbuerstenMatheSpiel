using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusikController : MonoBehaviour
{
    public AudioSource backgroundMusic;

    public int muteSource;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        muteSource = PlayerPrefs.GetInt("mute");
        
        if(muteSource == 1)
        {
            backgroundMusic.gameObject.GetComponent<AudioSource>().mute = false;
        }
        else if (muteSource == 0)
        {
            backgroundMusic.gameObject.GetComponent<AudioSource>().mute = true;
        }
        else
        {
            backgroundMusic.gameObject.GetComponent<AudioSource>().mute = false;
        }

    }
}
