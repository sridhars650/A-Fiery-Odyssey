using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialLogic : MonoBehaviour
{
    public bool gameIsFrozen = false;
    public bool inMessageState = false;
    public GameObject messageObject;
    private BoxCollider2D boxCollider;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        // No operations needed in Update method currently
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

}
