using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    //Wo
    //Sauber
    //Dreckig
    //Ob dreckig oder sauber
    //Button

    public GameObject lvl1;
    public Sprite Merkur2;
    public Sprite Merkur;
    public int merkurSauber;

    public GameObject lvl2;
    public Sprite Venus2;
    public Sprite Venus;
    public int VenusSauber;
    public GameObject VenusButton;

    public GameObject lvl3;
    public Sprite Erde2;
    public Sprite Erde;
    public int ErdeSauber;
    public GameObject ErdeButton;

    public GameObject lvl4;
    public Sprite Mars2;
    public Sprite Mars;
    public int MarsSauber;
    public GameObject MarsButton;

    public GameObject lvl5;
    public Sprite Jupiter2;
    public Sprite Jupiter;
    public int JupiterSauber;
    public GameObject JupiterButton;

    



    // Start is called before the first frame update
    void Start()
    {
         

        merkurSauber = 0;
        VenusSauber = 0;
        ErdeSauber = 0;
        MarsSauber = 0;
        JupiterSauber = 0;

        
        merkurSauber = PlayerPrefs.GetInt("merkurSauber");
        VenusSauber = PlayerPrefs.GetInt("VenusSauber");
        ErdeSauber = PlayerPrefs.GetInt("ErdeSauber");
        MarsSauber = PlayerPrefs.GetInt("MarsSauber");
        JupiterSauber = PlayerPrefs.GetInt("JupiterSauber");

        GameObject.Find("Merkur").SetActive(true);
        GameObject.Find("Venus").SetActive(true);
        GameObject.Find("Erde").SetActive(true);
        GameObject.Find("Mars").SetActive(true);
        GameObject.Find("Jupiter").SetActive(true);
        if(merkurSauber ==1)
        {
            VenusButton.SetActive(true);
            if(VenusSauber ==1)
            {

                ErdeButton.SetActive(true);
                if(ErdeSauber == 1)
                {

                    MarsButton.SetActive(true);
                    if(MarsSauber == 1)
                    {

                        JupiterButton.SetActive(true);

                    }
                        

                }



                

            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        // lvl1
        if(merkurSauber == 1)
        {

            lvl1.GetComponent<SpriteRenderer>().sprite = Merkur2;
            PlayerPrefs.SetInt("merkurSauber", 1);
            PlayerPrefs.Save();
            

        }
        else
        {

            lvl1.GetComponent<SpriteRenderer>().sprite = Merkur;

        }
        // lvl2
        if (VenusSauber == 1)
        {

            lvl2.GetComponent<SpriteRenderer>().sprite = Venus2;
            PlayerPrefs.SetInt("VenusSauber", 1);
            PlayerPrefs.Save();

        }
        else
        {

            lvl2.GetComponent<SpriteRenderer>().sprite = Venus;

        }
        // lvl 3
        if (ErdeSauber == 1)
        {

            lvl3.GetComponent<SpriteRenderer>().sprite = Erde2;
            PlayerPrefs.SetInt("ErdeSauber", 1);
            PlayerPrefs.Save();


        }
        else
        {

            lvl3.GetComponent<SpriteRenderer>().sprite = Erde;

        }
        // lvl 4
        if (MarsSauber == 1)
        {

            lvl4.GetComponent<SpriteRenderer>().sprite = Mars2;
            PlayerPrefs.SetInt("MarsSauber", 1);
            PlayerPrefs.Save();

        }
        else
        {

            lvl4.GetComponent<SpriteRenderer>().sprite = Mars;

        }

        // lvl 5
        if (JupiterSauber == 1)
        {

            lvl5.GetComponent<SpriteRenderer>().sprite = Jupiter2;
            PlayerPrefs.SetInt("JupiterSauber", 1);
            PlayerPrefs.Save();
        }
        else
        {

            lvl5.GetComponent<SpriteRenderer>().sprite = Jupiter;

        }
    }
}
