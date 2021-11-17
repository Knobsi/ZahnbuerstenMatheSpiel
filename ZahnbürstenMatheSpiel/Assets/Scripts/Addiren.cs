using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Addiren : MonoBehaviour
{
    public LevelSelector levelSelector;

    public int addirenDifficulty;
    int zahl1;
    int zahl2;


    public Button testButton;
    public Button weiterButton;

    public InputField inputText;

    public Text text1Question;

    int levelfinish = 0;

    public GameObject planetClean;
    public GameObject planetDirty;

    public GameObject bakterie1;
    public GameObject bakterie2;
    public GameObject bakterie3;
    public GameObject bakterie4;

    public int bakterienzahl = 4;

    public GameObject zahnbürste;
    public GameObject lamp;

    int lvlIsFinish;

    double maxValue;


    private void Awake()
    {
        //Prüft ob das Level beendet ist und setzt dan die entsprechenden werte (siehe wiki)

        lvlIsFinish = PlayerPrefs.GetInt("lvlIsFinishMerkur");

        if (levelfinish >= 4 || lvlIsFinish == 1)
        {
            zahnbürste.SetActive(true);
            lamp.SetActive(true);
            planetClean.SetActive(true);
            planetDirty.SetActive(false);
            PlayerPrefs.SetInt("merkurSauber", 1);
            PlayerPrefs.SetInt("lvlIsFinishMerkur", 1);
            PlayerPrefs.Save();

        }
    }

    void Start()
    {
        //Vordert die erste Nummer
        NewNumbers();

        //Checkt das ergebniss
        Button btn = testButton.GetComponent<Button>();
        btn.onClick.AddListener(CheckSumme);

        //Weiterbutton
        Button weiter = weiterButton.GetComponent<Button>();
        weiter.onClick.AddListener(CheckEnd);

        //Checkt die Schwierigkeit
        addirenDifficulty = PlayerPrefs.GetInt("Difficulty");

    }

    void Update()
    {

        //Zurück zum Menü
        if(Input.GetKeyDown(KeyCode.Escape))
        {

            SceneManager.LoadScene("Hauptmenü");

        }

        //Prüft ob das Level geschaft ist und setzt dan die entsprechenden werte (siehe wiki)
        lvlIsFinish = PlayerPrefs.GetInt("lvlIsFinishMerkur");

        if (levelfinish >= 4 || lvlIsFinish == 1)
        {
            zahnbürste.SetActive(true);
            lamp.SetActive(true);
            planetClean.SetActive(true);
            planetDirty.SetActive(false);
            PlayerPrefs.SetInt("merkurSauber", 1);
            PlayerPrefs.SetInt("lvlIsFinishMerkur", 1);
            PlayerPrefs.Save();

        }
        
        //Steuert die Bakterienanzahl
        switch(bakterienzahl)
        {

            case 0:
                bakterie1.SetActive(false);
                bakterie2.SetActive(false);
                bakterie3.SetActive(false);
                bakterie4.SetActive(false);
                break;
            case 1:
                bakterie1.SetActive(true);
                bakterie2.SetActive(false);
                bakterie3.SetActive(false);
                bakterie4.SetActive(false);
                break;
            case 2:
                bakterie1.SetActive(true);
                bakterie2.SetActive(true);
                bakterie3.SetActive(false);
                bakterie4.SetActive(false);
                break;
            case 3:
                bakterie1.SetActive(true);
                bakterie2.SetActive(true);
                bakterie3.SetActive(true);
                bakterie4.SetActive(false);
                break;
            case 4:
                bakterie1.SetActive(true);
                bakterie2.SetActive(true);
                bakterie3.SetActive(true);
                bakterie4.SetActive(true);
                break;

        }
    }

    //Vordert eine neue nummer anhand der schwierigkeit
    void NewNumbers()
    { 

        switch (addirenDifficulty)
        {
            case 1:
                zahl1 = UnityEngine.Random.Range(1, 11);
                zahl2 = UnityEngine.Random.Range(1, 11);
                maxValue = 10;
                break;

            case 2:
                zahl1 = UnityEngine.Random.Range(1, 51);
                zahl2 = UnityEngine.Random.Range(1, 51);
                maxValue = 50;
                break;

            case 3:
                zahl1 = UnityEngine.Random.Range(1, 101);
                zahl2 = UnityEngine.Random.Range(1, 101);
                maxValue = 100;
                break;

            case 4:
                zahl1 = UnityEngine.Random.Range(1, 1001);
                zahl2 = UnityEngine.Random.Range(1, 1001);
                maxValue = 1000;
                break;
            default:
                zahl1 = UnityEngine.Random.Range(1, 11);
                zahl2 = UnityEngine.Random.Range(1, 11);
                maxValue = 10;
                break;


        }
        //Prüft ob das Ergebnis im rahmen liegt
        if(zahl1 + zahl2 > maxValue)
        {

            NewNumbers();

        }
        //Gibt die nummer in den Textzeilen aus
        string zahl1Text = Convert.ToString(zahl1);
        string zahl2Text = Convert.ToString(zahl2);

        text1Question.GetComponent<Text>().text = $" {zahl1} + {zahl2} = ";
        


    }

    void CheckSumme()
    {
       //Rechnet den Betrag aus
        int summe = zahl1 + zahl2;

        string text = inputText.gameObject.GetComponent<InputField>().text;
        int summe1 = Convert.ToInt32(text);

        //Checkt das ergebnis was eingegeben wurde
        if (summe1 == summe)
        {
            //Gibt eine neue nummer aus
            Debug.Log("Geilman");
            NewNumbers();
            levelfinish++;
            inputText.gameObject.GetComponent<InputField>().text = "";
            bakterienzahl--;



        }
        if(summe1 != summe)
        {

            Debug.Log("Dummer Trottel");
            NewNumbers();
            levelfinish = 0;
            inputText.gameObject.GetComponent<InputField>().text = "Falsch";
            bakterienzahl = 4;


        }
           
    }

    //Checkt ob die benötigte anzahl an Aufgaben gelöst wurde und Begibt sich dan ins Hauptmenü zurück
    void CheckEnd()
    {

        if(levelfinish >= 4 || lvlIsFinish == 1)
        {

            SceneManager.LoadScene("Hauptmenü");
            PlayerPrefs.SetInt("merkurSauber", 1);
            PlayerPrefs.Save();
            bakterienzahl = 0;

        }

    }
}
