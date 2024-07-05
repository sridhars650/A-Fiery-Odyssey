using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LogicScript : MonoBehaviour
{
    public bool settingsOpen = false;
    public GameObject settingsMenu;

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

    public void showHelpMenu()
    {
        SceneManager.LoadScene("HelpScene");
    }

    public void openSettingsMenu()
    {
        settingsOpen = !settingsOpen;
        if (settingsOpen)
        { 
            settingsMenu.SetActive(true);
        }
    }

}
