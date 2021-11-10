using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class ScenenManagerScript : MonoBehaviour
{
    public string lvlToLoad;
    public Button yourButton;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(LoadLevel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel()
    {

        SceneManager.LoadScene(lvlToLoad);

    }
}
