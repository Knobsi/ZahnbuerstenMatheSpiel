using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class fly : MonoBehaviour
{
    public string lvlToLoad;
    public Button yourButton;

    public bool nowStart;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(LoadLevel);
    }

    // Update is called once per frame
    void Update()
    {
        if(nowStart == true)
        {

            Vector2 flyNow = new Vector2(1, 0);
            this.gameObject.transform.Translate(flyNow * Time.deltaTime);

        }
        
    }

    public void LoadLevel()
    {
        StartCoroutine(goWay());
        

    }
    IEnumerator goWay()
    {

        nowStart = true;
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(lvlToLoad);




    }

}
