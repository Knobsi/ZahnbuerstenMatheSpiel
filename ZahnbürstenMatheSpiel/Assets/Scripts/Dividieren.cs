using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Dividieren : MonoBehaviour
{
    public LevelSelector levelSelector;

    public int addirenDifficulty;
    decimal zahl1;
    decimal zahl2;
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

    public GameObject zahnb�rste;
    public GameObject lamp;

    int lvlIsFinish;
    int kommazahlenErlaubt;

    private void Awake()
    {
     
        lvlIsFinish = PlayerPrefs.GetInt("lvlIsFinishMars");

        if (levelfinish == 4 || levelfinish == 1)
        {
            zahnb�rste.SetActive(true);
            lamp.SetActive(true);
            PlayerPrefs.SetInt("MarsSauber", 1);
            PlayerPrefs.SetInt("lvlIsFinishMars", 1);
            PlayerPrefs.Save();
            planetClean.SetActive(true);
            planetDirty.SetActive(false);

        }
        else
        {
            zahnb�rste.SetActive(false);
            planetDirty.SetActive(true);
            planetClean.SetActive(false);
            PlayerPrefs.SetInt("MarsSauber", 0);
            PlayerPrefs.SetInt("lvlIsFinishMars", 0);
            PlayerPrefs.Save();

        }

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

        //Levelselector zugriff

        levelSelector = GameObject.Find("PlanetenController").GetComponentInParent<LevelSelector>();

        GameObject.Find("Merkur").SetActive(false);
        GameObject.Find("Venus").SetActive(false);
        GameObject.Find("Erde").SetActive(false);
        GameObject.Find("Mars").SetActive(false);
        GameObject.Find("Jupiter").SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        //Wen eine neue nummer ben�tight wird
        if (nedNewNumber == true)
        {
            NewNumbers();
        }
        //Zur�ck zum Men�
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            SceneManager.LoadScene("Hauptmen�");

        }
        //Zeigt das das level geschaft ist
        if (levelfinish == 4 || lvlIsFinish == 1)
        {
            zahnb�rste.SetActive(true);
            lamp.SetActive(true);
            PlayerPrefs.SetInt("lvlIsFinishMars", 1);
            PlayerPrefs.SetInt("MarsSauber", 1);
            PlayerPrefs.Save();
            planetClean.SetActive(true);
            planetDirty.SetActive(false);

        }
        else
        {
            zahnb�rste.SetActive(false);
            lamp.SetActive(false);
            planetDirty.SetActive(true);
            planetClean.SetActive(false);
            PlayerPrefs.SetInt("MarsSauber", 0);
            PlayerPrefs.SetInt("lvlIsFinishMars", 0);
            PlayerPrefs.Save();

        }
        Debug.Log(levelfinish);

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
                break;

            case 2:
                zahl1 = UnityEngine.Random.Range(1, 51);
                zahl2 = UnityEngine.Random.Range(1, 51);
                break;

            case 3:
                zahl1 = UnityEngine.Random.Range(1, 101);
                zahl2 = UnityEngine.Random.Range(1, 101);
                break;

            case 4:
                zahl1 = UnityEngine.Random.Range(1, 1001);
                zahl2 = UnityEngine.Random.Range(1, 1001);
                break;


        }
        if(kommazahlenErlaubt == 0)
        {

            if ((zahl1 % zahl2) != 0)
            {
                NewNumbers();
            }

        }
       

        //Gibt die nummer in den Textzeilen aus
        string zahl1Text = Convert.ToString(zahl1);
        string zahl2Text = Convert.ToString(zahl2);

        text1Question.GetComponent<Text>().text = $" {zahl1} / {zahl2} = ";




    }

    void CheckSumme()
    {
        //Rechnet den Betrag aus
        decimal summe = zahl1 / zahl2;
        summe = Math.Round(summe, 2);

        string text = inputText.gameObject.GetComponent<InputField>().text;
        decimal summe1 = Convert.ToDecimal(text);
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
            inputText.gameObject.GetComponent<InputField>().text = "";
            bakterienzahl = 4;
        }

    }

    void CheckEnd()
    {

        if (levelfinish == 4 || lvlIsFinish == 1)
        {
            PlayerPrefs.SetInt("MarsSauber", 1);
            PlayerPrefs.Save();
            SceneManager.LoadScene("Hauptmen�");
            bakterienzahl = 0;

        }

    }
}

