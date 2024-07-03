using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishedScript : MonoBehaviour
{
    public bool gameIsFrozen = false;
    public bool inMessageState = false;
    public GameObject messageObject;
    private BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // No operations needed in Update method currently
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            inMessageState = true;
            FreezeGame(true); // freezes game
            PopUpMessage();
        }
    }

    public void FreezeGame(bool freeze)
    {
        gameIsFrozen = freeze;
        Time.timeScale = freeze ? 0 : 1;
    }

    public void PopUpMessage()
    {
        messageObject.SetActive(true);
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
}
