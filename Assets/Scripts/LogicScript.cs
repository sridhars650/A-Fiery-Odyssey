using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void quitTheGame()
    {
        Application.Quit();
    }

    public void playTutorial()
    {
        SceneManager.LoadScene("TutorialScene");
    }
}
