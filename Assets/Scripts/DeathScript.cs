using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour
{
    private PolygonCollider2D polygonCollider;
    public GameObject messageObject;
    public bool inMessageState = false;
    public bool gameIsFrozen = false;

    // Start is called before the first frame update
    void Start()
    {
        polygonCollider = GetComponent<PolygonCollider2D>();
        Time.timeScale = 1; // Ensure time scale is reset at the start
        Debug.Log("Start: Time.timeScale = " + Time.timeScale); // Debug log to check time scale
    }

    public void ResetTutorial()
    {
        Debug.Log("ResetTutorial: called");
        FreezeGame(false); // unfreezes
        Debug.Log("ResetTutorial: Time.timeScale before load = " + Time.timeScale); // Debug log before scene load
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitTheGame()
    {
        Debug.Log("QuitTheGame: called");
        Application.Quit();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            Debug.Log("OnCollisionEnter2D: collision with layer 3 detected");
            EnterMessageState();
        }
    }

    private void EnterMessageState()
    {
        Debug.Log("EnterMessageState: called");
        inMessageState = true;
        FreezeGame(true); // freezes game
        PopUpMessage();
    }

    public void FreezeGame(bool freeze)
    {
        gameIsFrozen = freeze;
        Time.timeScale = freeze ? 0 : 1;
        Debug.Log("FreezeGame: Time.timeScale = " + Time.timeScale); // Debug log to check time scale
    }

    public void PopUpMessage()
    {
        Debug.Log("PopUpMessage: called");
        messageObject.SetActive(true);
    }
}
