using System.Collections;
using System.Collections.Generic;
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            inMessageState = true;
            freezeGame(); // freezes game
            popUpMessage();
        }
    }

    public void freezeGame()
    {
        gameIsFrozen = !gameIsFrozen;
        if (gameIsFrozen)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void popUpMessage()
    {
        messageObject.SetActive(true);
    }

    public void resetTutorial()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void quitTheGame()
    {
        Application.Quit();
    }
}
