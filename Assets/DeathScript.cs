using System.Collections;
using System.Collections.Generic;
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void resetTutorial()
    {
        freezeGame(); // unfreezes
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    public void quitTheGame()
    {
        Application.Quit();
    }

    private void OnCollisionEnter2D(Collision2D collision)
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
}
