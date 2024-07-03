using UnityEngine;

public class MessageState : MonoBehaviour
{
    public bool gameIsFrozen = false;
    public GameObject messageObject;
    private PolygonCollider2D polygonCollider;
    private float disableTimer = 0;
    private bool isDisabled = false;
    public bool inMessageState = false;

    // Start is called before the first frame update
    void Start()
    {
        polygonCollider = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleCollisionDisableTimer();
        HandleMessageStateInput();
    }

    private void HandleCollisionDisableTimer()
    {
        if (!isDisabled) return;

        disableTimer -= Time.deltaTime;
        if (disableTimer <= 0)
        {
            polygonCollider.enabled = true;
            isDisabled = false;
        }
    }

    private void HandleMessageStateInput()
    {
        if (inMessageState && Input.GetKeyDown(KeyCode.Escape))
        {
            dismissPopUp();
        }
    }

    private void DisableCollisionForSeconds(float seconds)
    {
        polygonCollider.enabled = false;
        disableTimer = seconds;
        isDisabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            enterMessageState();
        }
    }

    private void enterMessageState()
    {
        inMessageState = true;
        freezeGame(true);
        popUpMessage();
    }

    public void freezeGame(bool freeze)
    {
        gameIsFrozen = freeze;
        Time.timeScale = freeze ? 0 : 1;
    }

    public void popUpMessage()
    {
        messageObject.SetActive(true);
    }

    public void dismissPopUp()
    {
        messageObject.SetActive(false);
        inMessageState = false;
        freezeGame(false);
        DisableCollisionForSeconds(2);
    }
}
