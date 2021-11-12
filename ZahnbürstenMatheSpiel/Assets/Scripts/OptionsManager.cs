using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    public int Difficulty;
    public int zahlUnterNull;
    public int kommaZahlen;
    public int mute;

    public Button zahlUnterNullButton;
    public Button kommaZahlenButton;
    public Button switchDifficultyButton;
    public Button muteButton;

    public int switchZahlUnterNull;
    public int switchKommaZahlen;
    public int switchDifficulty;
    public int switchMute;

    public Text zahlUnterNullText;
    public Text kommaZahlenText;
    public Text difficultyText;
    public Text muteText;
    
    // Start is called before the first frame update
    void Start()
    {
        Button btn1 = zahlUnterNullButton.GetComponent<Button>();
        btn1.onClick.AddListener(SwitchZahlUnterNull);

        Button btn2 = kommaZahlenButton.GetComponent<Button>();
        btn2.onClick.AddListener(SwitchKommazahlErlaubt);

        Button btn3 = switchDifficultyButton.GetComponent<Button>();
        btn3.onClick.AddListener(SwitchDifficulty);

        Button btn4 = muteButton.GetComponent<Button>();
        btn4.onClick.AddListener(SwitchMute);

    }

    

    void SwitchZahlUnterNull()
    {
        switchZahlUnterNull = PlayerPrefs.GetInt("zahlUnterNull");

        if(switchZahlUnterNull == 1)
        {
            zahlUnterNull = 0;
            zahlUnterNullText.gameObject.GetComponent<Text>().text = "An";
        }
        else if(switchZahlUnterNull == 0)
        {
            zahlUnterNull = 1;
            zahlUnterNullText.gameObject.GetComponent<Text>().text = "Aus";
        }
        else
        {
            zahlUnterNull = 0;
            zahlUnterNullText.gameObject.GetComponent<Text>().text = "An";
        }

            PlayerPrefs.SetInt("zahlUnterNull", zahlUnterNull);
        PlayerPrefs.Save();
    }

    void SwitchKommazahlErlaubt()
    {
        switchKommaZahlen = PlayerPrefs.GetInt("kommazahlenErlaubt");

        if(switchKommaZahlen == 1)
        {
            kommaZahlen = 0;
            kommaZahlenText.gameObject.GetComponent<Text>().text = "An";
        }
        else if (switchKommaZahlen == 0)
        {
            kommaZahlen = 1;
            kommaZahlenText.gameObject.GetComponent<Text>().text = "Aus";
        }
        else 
        {
            kommaZahlen = 0;
            kommaZahlenText.gameObject.GetComponent<Text>().text = "An";
        }
        PlayerPrefs.SetInt("kommazahlenErlaubt", kommaZahlen);
        PlayerPrefs.Save();
    }

    void SwitchDifficulty()
    {
        switchDifficulty = PlayerPrefs.GetInt("Difficulty");

        switch(switchDifficulty)
        {
            case 1:
                Difficulty = 2;
                difficultyText.gameObject.GetComponent<Text>().text = " Difficulty easy Zahlen von 1 - 10"; 
                break;
            case 2:
                Difficulty = 3;
                difficultyText.gameObject.GetComponent<Text>().text = " Difficulty easy Zahlen von 1 - 50";
                break;
            case 3:
                Difficulty = 4;
                difficultyText.gameObject.GetComponent<Text>().text = " Difficulty easy Zahlen von 1 - 100";
                break;
            case 4:
                Difficulty = 1;
                difficultyText.gameObject.GetComponent<Text>().text = " Difficulty easy Zahlen von 1 - 1000";
                break;
            default:
                Difficulty = 1;
                difficultyText.gameObject.GetComponent<Text>().text = " Difficulty easy Zahlen von 1 - 10";
                break;

        }

        PlayerPrefs.SetInt("Difficulty", Difficulty);
        PlayerPrefs.Save();
    }

    void SwitchMute()
    {
        switchMute = PlayerPrefs.GetInt("mute");

        if(switchMute == 1)
        {
            mute = 0;
            muteText.gameObject.GetComponent<Text>().text = "An";
        }
        else if(switchMute == 0)
        {
            mute = 1;
            muteText.gameObject.GetComponent<Text>().text = "Aus";
        }
        else
        {
            mute = 0;
            muteText.gameObject.GetComponent<Text>().text = "An";
        }

        PlayerPrefs.SetInt("mute", mute);
        PlayerPrefs.Save();

    }
}
