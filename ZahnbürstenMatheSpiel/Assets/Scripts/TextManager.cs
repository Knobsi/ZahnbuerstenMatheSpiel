using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextManager : MonoBehaviour
{
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;

    public GameObject gameUI;

    public int bereitsAbgespielt;

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
            StartCoroutine(TextSwitch());
        }
        else
        {
            gameUI.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TextSwitch()
    {
        gameUI.gameObject.SetActive(false);
        text1.gameObject.SetActive(true);
        yield return new WaitForSeconds(8);
        text1.gameObject.SetActive(false);
        text2.gameObject.SetActive(true);
        yield return new WaitForSeconds(8);
        text2.gameObject.SetActive(false);
        text3.gameObject.SetActive(true);
        yield return new WaitForSeconds(8);
        text3.gameObject.SetActive(false);
        gameUI.gameObject.SetActive(true);

    }
}
