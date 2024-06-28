using UnityEngine;

public class MagnetCursor : MonoBehaviour
{
    public Texture2D cursorUp;
    public Texture2D cursorDown;
    public Texture2D cursorLeft;
    public Texture2D cursorRight;
    public Texture2D cursorUpRight;
    public Texture2D cursorUpLeft;
    public Texture2D cursorDownRight;
    public Texture2D cursorDownLeft;
    public Transform blockTransform;
    public Vector2 hotSpot = Vector2.zero;
    public float initialAttractionSpeed = 1f; // Initial speed when starting to attract
    public float maxAttractionSpeed = 5f; // Maximum speed when fully attracted
    public float attractionAcceleration = 2f; // Acceleration rate towards max speed
    public float attractionRange = 1f; // Distance within which attraction starts
    public float stopDistance = 0.1f; // Distance at which attraction stops

    private bool isAttracting = false;
    private float currentAttractionSpeed = 0f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isAttracting = true;
            currentAttractionSpeed = initialAttractionSpeed;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isAttracting = false;
            currentAttractionSpeed = 0f;
        }

        if (isAttracting)
        {
            Vector3 cursorPosition = Input.mousePosition;
            Vector3 blockScreenPosition = Camera.main.WorldToScreenPoint(blockTransform.position);
            Vector3 moveDirection = (Camera.main.ScreenToWorldPoint(cursorPosition) - blockTransform.position).normalized;
            float distance = Vector3.Distance(blockTransform.position, Camera.main.ScreenToWorldPoint(cursorPosition));

            if (distance > attractionRange)
            {
                currentAttractionSpeed = Mathf.Min(currentAttractionSpeed + attractionAcceleration * Time.deltaTime, maxAttractionSpeed);
                blockTransform.position += moveDirection * currentAttractionSpeed * Time.deltaTime;
            }
            else if (distance > stopDistance)
            {
                blockTransform.position += moveDirection * maxAttractionSpeed * Time.deltaTime;
            }
        }

        // Set cursor based on angle
        Vector3 cursorDir = Camera.main.WorldToScreenPoint(blockTransform.position) - Input.mousePosition;
        float angle = Mathf.Atan2(cursorDir.y, cursorDir.x) * Mathf.Rad2Deg;

        Cursor.SetCursor(GetCursorTexture(angle), hotSpot, CursorMode.Auto);

        // Debug logs for position
        Debug.Log("Block Position: " + blockTransform.position);
    }

    Texture2D GetCursorTexture(float angle)
    {
        if (angle > -22.5f && angle <= 22.5f)
        {
            return cursorRight;
        }
        else if (angle > 22.5f && angle <= 67.5f)
        {
            return cursorUpRight;
        }
        else if (angle > 67.5f && angle <= 112.5f)
        {
            return cursorUp;
        }
        else if (angle > 112.5f && angle <= 157.5f)
        {
            return cursorUpLeft;
        }
        else if (angle > 157.5f || angle <= -157.5f)
        {
            return cursorLeft;
        }
        else if (angle > -157.5f && angle <= -112.5f)
        {
            return cursorDownLeft;
        }
        else if (angle > -112.5f && angle <= -67.5f)
        {
            return cursorDown;
        }
        else if (angle > -67.5f && angle <= -22.5f)
        {
            return cursorDownRight;
        }

        // Default cursor
        return cursorUp;
    }
}
