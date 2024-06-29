using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageState : MonoBehaviour
{
    public bool gameIsFrozen = false;
    public GameObject messageObject;
    private PolygonCollider2D polygonCollider;
    private float disableTimer = 0;
    private bool isDisabled = false;
    private bool inMessageState = false;

    // Start is called before the first frame update
    void Start()
    {
        polygonCollider = GetComponent<PolygonCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isDisabled)
        {
            disableTimer -= Time.deltaTime;
            if (disableTimer <= 0)
            {
                polygonCollider.enabled = true;
                isDisabled = false;
            }
        }
        if (inMessageState)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                dismissPopUp();
            }
        }
    }
    private void DisableCollisionForTwoSeconds()
    {
        polygonCollider.enabled = false;
        disableTimer = 2;
        isDisabled = true;
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

    public void dismissPopUp()
    {
        messageObject.SetActive(false);
        freezeGame(); // unfreezes game
        DisableCollisionForTwoSeconds();
    } 

}
