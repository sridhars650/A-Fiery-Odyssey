using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialLogic : MonoBehaviour
{
    public bool settingsOpen = false;
    public GameObject settingsMenu;
    public bool gameIsFrozen = false;
    public bool inMessageState = false;
    private BoxCollider2D boxCollider;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
    }

    public void FreezeGame(bool freeze)
    {
        gameIsFrozen = freeze;
        Time.timeScale = freeze ? 0 : 1;
    }

    public void ResetTutorial()
    {
        FreezeGame(false); // unfreezes
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitTheGame()
    {
        Application.Quit();
    }

    public void returnToMenu()
    {
        FreezeGame(false); // unfreezes
        SceneManager.LoadScene("TitleScene");
    }

    public void openSettingsMenu()
    {
        settingsOpen = !settingsOpen;
        if (settingsOpen)
        { 
            settingsMenu.SetActive(true);
            FreezeGame(true); // freezes
        }
        else 
        {
            settingsMenu.SetActive(false);
            FreezeGame(false); // unfreezes
        }
    }

}
