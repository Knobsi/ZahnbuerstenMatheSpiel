using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;

    public GameObject gameUI;

    public int bereitsAbgespielt;

    public Button next;

    public bool firstText;
    public bool secondText;
    public bool thirtText;

    // Start is called before the first frame update
    void Start()
    {
        bereitsAbgespielt = 0;

        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("Active Scene is '" + scene.name + "'.");


        if (scene.name == "LVL1")
        {
            bereitsAbgespielt = PlayerPrefs.GetInt("lvlIsFinishMerkur");
        }
        if(scene.name == "LVL2")
        {
            bereitsAbgespielt = PlayerPrefs.GetInt("lvlIsFinishVenus");
        }
        if(scene.name== "LVL3")
        {
            bereitsAbgespielt = PlayerPrefs.GetInt("lvlIsFinishErde");
        }
        if(scene.name == "LVL4")
        {
            bereitsAbgespielt = PlayerPrefs.GetInt("lvlIsFinishMars");
        }
        if(scene.name == "LVL5")
        {
            bereitsAbgespielt = PlayerPrefs.GetInt("lvlIsFinishJupiter");
        }

        if(bereitsAbgespielt == 0)
        {
            gameUI.gameObject.SetActive(false);
            text1.gameObject.SetActive(true);
            firstText = true;
        }
        else
        {
            gameUI.gameObject.SetActive(true);
        }

        Button btn = next.GetComponent<Button>();
        btn.onClick.AddListener(NextText);



    }

    void NextText()
    {
        if (thirtText == true)
        {
            thirtText = false;
            text3.gameObject.SetActive(false);
            gameUI.gameObject.SetActive(true);

        }
        if (secondText == true)
        {
            secondText = false;
            text2.gameObject.SetActive(false);
            text3.gameObject.SetActive(true);
            thirtText = true;

        }
        if (firstText == true)
        {
            firstText = false;
            text1.gameObject.SetActive(false);
            text2.gameObject.SetActive(true);
            secondText = true;
        }

    }

}
