using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    public int Difficulty;
    public int zahlUnterNull;
    public int kommaZahlen;

    public Button zahlUnterNullButton;
    public Button kommaZahlenButton;
    public Button switchDifficultyButton;

    public int switchZahlUnterNull;
    public int switchKommaZahlen;
    public int switchDifficulty;
    // Start is called before the first frame update
    void Start()
    {
        Button btn1 = zahlUnterNullButton.GetComponent<Button>();
        btn1.onClick.AddListener(SwitchZahlUnterNull);

        Button btn2 = kommaZahlenButton.GetComponent<Button>();
        btn2.onClick.AddListener(SwitchKommazahlErlaubt);

        Button btn3 = switchDifficultyButton.GetComponent<Button>();
        btn3.onClick.AddListener(SwitchDifficulty);



    }

    

    void SwitchZahlUnterNull()
    {
        switchZahlUnterNull = PlayerPrefs.GetInt("zahlUnterNull");


        PlayerPrefs.SetInt("zahlUnterNull", zahlUnterNull);
        PlayerPrefs.Save();
    }

    void SwitchKommazahlErlaubt()
    {
        PlayerPrefs.SetInt("kommazahlenErlaubt", kommaZahlen);
        PlayerPrefs.Save();
    }

    void SwitchDifficulty()
    {
        PlayerPrefs.SetInt("Difficulty", Difficulty);
        PlayerPrefs.Save();
    }
}
