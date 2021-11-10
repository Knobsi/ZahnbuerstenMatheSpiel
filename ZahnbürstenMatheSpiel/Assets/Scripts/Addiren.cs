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
    bool nedNewNumber;

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
    

    // Start is called before the first frame update
    void Start()
    {
        //Setzt den startwert
        nedNewNumber = true;

        //Checkt das ergebniss
        Button btn = testButton.GetComponent<Button>();
        btn.onClick.AddListener(CheckSumme);

        //Weiterbutton
        Button weiter = weiterButton.GetComponent<Button>();
        weiter.onClick.AddListener(CheckEnd);

        //Checkt die Schwierigkeit
        addirenDifficulty = 1;

        //Levelselector zugriff

        levelSelector = GameObject.Find("PlanetenController").GetComponentInParent<LevelSelector>() ;

        GameObject.Find("Merkur").SetActive(false);
        GameObject.Find("Venus").SetActive(false);
        GameObject.Find("Erde").SetActive(false);
        GameObject.Find("Mars").SetActive(false);
        GameObject.Find("Jupiter").SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        //Wen eine neue nummer benötight wird
        if(nedNewNumber == true)
        {
            NewNumbers();
        }
        //Zurück zum Menü
        if(Input.GetKeyDown(KeyCode.Escape))
        {

            SceneManager.LoadScene("Hauptmenü");

        }
        //Zeigt das das level geschaft ist
        if(levelfinish == 4)
        {
            zahnbürste.SetActive(true);
            PlayerPrefs.SetInt("merkurSauber", 1);
            PlayerPrefs.Save();
            planetClean.SetActive(true);
            planetDirty.SetActive(false);
            
        }
        else
        {
            zahnbürste.SetActive(false);
            planetDirty.SetActive(true);
            planetClean.SetActive(false);

        }
        Debug.Log(levelfinish);

        switch (bakterienzahl)
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

    void NewNumbers()
    {
        //Vordert eine neue nummer anhand der schwierigkeit
        nedNewNumber = false;

        switch (addirenDifficulty)
        {
            case 1:
                zahl1 = UnityEngine.Random.Range(0, 10);
                zahl2 = UnityEngine.Random.Range(0, 10);
                break;

            case 2:
                zahl1 = UnityEngine.Random.Range(0, 50);
                zahl2 = UnityEngine.Random.Range(0, 50);
                break;

            case 3:
                zahl1 = UnityEngine.Random.Range(0, 100);
                zahl2 = UnityEngine.Random.Range(0, 100);
                break;

            case 4:
                zahl1 = UnityEngine.Random.Range(0, 1000);
                zahl2 = UnityEngine.Random.Range(0, 1000);
                break;

                
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

    void CheckEnd()
    {

        if(levelfinish == 4)
        {

            SceneManager.LoadScene("Hauptmenü");
            PlayerPrefs.SetInt("merkurSauber", 1);
            PlayerPrefs.Save();
            bakterienzahl = 0;

        }

    }
}
