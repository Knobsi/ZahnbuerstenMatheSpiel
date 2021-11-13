using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MischAufgaben : MonoBehaviour
{
   

    public int addirenDifficulty;
    double zahl1;
    double zahl2;
    bool nedNewNumber;

    public Button testButton;
    public Button weiterButton;

    public InputField inputText;

    public Text text1Question;

    int levelfinish = 0;

    public GameObject planetClean;
    public GameObject planetDirty;

    int Randomizer;
    string zahlText;

    double summe;

    public GameObject bakterie1;
    public GameObject bakterie2;
    public GameObject bakterie3;
    public GameObject bakterie4;

    public int bakterienzahl = 4;

    public GameObject zahnbürste;
    public GameObject lamp;

    int lvlIsFinish;

    int zahlUnterNull;
    int kommazahlenErlaubt;

    private void Awake()
    {
        
        lvlIsFinish = PlayerPrefs.GetInt("lvlIsFinishJupiter");

        if (levelfinish == 4 || lvlIsFinish == 1)
        {
            zahnbürste.SetActive(true);
            lamp.SetActive(true);
            PlayerPrefs.SetInt("JupiterSauber", 1);
            PlayerPrefs.SetInt("lvlIsFinishJupiter", 1);
            PlayerPrefs.Save();
            planetClean.SetActive(true);
            planetDirty.SetActive(false);

        }
        else
        {
            zahnbürste.SetActive(false);
            planetDirty.SetActive(true);
            planetClean.SetActive(false);
            PlayerPrefs.SetInt("JupiterSauber", 0);
            PlayerPrefs.SetInt("lvlIsFinishJupiter", 0);
            PlayerPrefs.Save();

        }

        zahlUnterNull = PlayerPrefs.GetInt("zahlUnterNull");
        kommazahlenErlaubt = PlayerPrefs.GetInt("kommazahlenErlaubt");

    }

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
        addirenDifficulty = PlayerPrefs.GetInt("Difficulty");

    }

    // Update is called once per frame
    void Update()
    {
        //Wen eine neue nummer benötight wird
        if (nedNewNumber == true)
        {
            NewNumbers();
        }
        //Zurück zum Menü
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            SceneManager.LoadScene("Hauptmenü");

        }
        //Zeigt das das level geschaft ist
        if (levelfinish == 4 || lvlIsFinish == 1)
        {
            zahnbürste.SetActive(true);
            lamp.SetActive(true);
            PlayerPrefs.SetInt("JupiterSauber", 1);
            PlayerPrefs.SetInt("lvlIsFinishJupiter", 1);
            PlayerPrefs.Save();
            planetClean.SetActive(true);
            planetDirty.SetActive(false);

        }
        else
        {
            zahnbürste.SetActive(false);
            lamp.SetActive(false);
            planetDirty.SetActive(true);
            planetClean.SetActive(false);
            PlayerPrefs.SetInt("lvlIsFinishJupiter", 0);
            PlayerPrefs.Save();

        }

        // Debug.Log(levelfinish);
        if (lvlIsFinish == 1)
        {
            bakterie1.SetActive(false);
            bakterie2.SetActive(false);
            bakterie3.SetActive(false);
            bakterie4.SetActive(false);
        }
        else
        {
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
    }

    void NewNumbers()
    {
        //Vordert eine neue nummer anhand der schwierigkeit
        nedNewNumber = false;

        switch (addirenDifficulty)
        {
            case 1:
                zahl1 = UnityEngine.Random.Range(1, 11);
                zahl2 = UnityEngine.Random.Range(1, 11);
                Randomizer = UnityEngine.Random.Range(1, 5);
                break;

            case 2:
                zahl1 = UnityEngine.Random.Range(1, 51);
                zahl2 = UnityEngine.Random.Range(1, 51);
                Randomizer = UnityEngine.Random.Range(1, 5);
                break;

            case 3:
                zahl1 = UnityEngine.Random.Range(1, 101);
                zahl2 = UnityEngine.Random.Range(1, 101);
                Randomizer = UnityEngine.Random.Range(1, 5);
                break;

            case 4:
                zahl1 = UnityEngine.Random.Range(1, 1001);
                zahl2 = UnityEngine.Random.Range(1, 1001);
                Randomizer = UnityEngine.Random.Range(1, 5);
                break;


        }

        switch (Randomizer)
        {
            case 1:
                zahlText = "+";
                break;
            case 2:
                zahlText = "-";

                if(zahlUnterNull == 1)
                {

                    if ((zahl1 - zahl2) <= 0)
                    {

                        NewNumbers();

                    }

                }
                break;
            case 3:
                zahlText = "*";
                break;
            case 4:
                zahlText = "/";

                if(kommazahlenErlaubt == 0)
                {

                    if ((zahl1 % zahl2) != 0)
                    {
                        NewNumbers();
                    }

                }
                break;

        }

        //Gibt die nummer in den Textzeilen aus
        string zahl1Text = Convert.ToString(zahl1);
        string zahl2Text = Convert.ToString(zahl2);


        text1Question.GetComponent<Text>().text = $" {zahl1} {zahlText} {zahl2} = ";

       

    }

   

    void CheckSumme()
    {
        //Rechnet den Betrag aus

        switch (Randomizer)
        {
            case 1:
                summe = zahl1 + zahl2;
                break;
            case 2:
                summe = zahl1 - zahl2;
                break;
            case 3:
                summe = zahl1 * zahl2;
                break;
            case 4:
                summe = zahl1 / zahl2;
                summe = Math.Round(summe, 2);
                break;

        }



        string text = inputText.gameObject.GetComponent<InputField>().text;
        double summe1 = Convert.ToDouble(text);
        summe1 = Math.Round(summe1, 2);
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
        if (summe1 != summe)
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

        if (levelfinish == 4 || lvlIsFinish == 1)
        {
            PlayerPrefs.SetInt("JupiterSauber", 1);
            PlayerPrefs.Save();
            SceneManager.LoadScene("Hauptmenü");
            bakterienzahl = 0;

        }

    }
}
