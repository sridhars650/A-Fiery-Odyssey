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
        Vector3 cursorPosition = Input.mousePosition;
        Vector3 blockScreenPosition = Camera.main.WorldToScreenPoint(blockTransform.position);
        Vector3 direction = (blockScreenPosition - cursorPosition).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

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
            // Calculate distance to cursor
            float distance = Vector3.Distance(blockTransform.position, Camera.main.ScreenToWorldPoint(cursorPosition));

            // Move towards cursor
            if (distance > attractionRange)
            {
                // Gradually increase speed towards max speed
                currentAttractionSpeed = Mathf.Min(currentAttractionSpeed + attractionAcceleration * Time.deltaTime, maxAttractionSpeed);
                Vector3 moveDirection = (Camera.main.ScreenToWorldPoint(cursorPosition) - blockTransform.position).normalized;
                blockTransform.position += moveDirection * currentAttractionSpeed * Time.deltaTime;
            }
            else if (distance > stopDistance)
            {
                // Move at max speed when close enough
                Vector3 moveDirection = (Camera.main.ScreenToWorldPoint(cursorPosition) - blockTransform.position).normalized;
                blockTransform.position += moveDirection * maxAttractionSpeed * Time.deltaTime;
            }
        }

        // Set cursor based on angle
        if (angle > 67.5f && angle <= 112.5f)
        {
            Cursor.SetCursor(cursorUp, hotSpot, CursorMode.Auto);
        }
        else if (angle > 112.5f && angle <= 157.5f)
        {
            Cursor.SetCursor(cursorUpLeft, hotSpot, CursorMode.Auto);
        }
        else if (angle > 157.5f || angle <= -157.5f)
        {
            Cursor.SetCursor(cursorLeft, hotSpot, CursorMode.Auto);
        }
        else if (angle > -157.5f && angle <= -112.5f)
        {
            Cursor.SetCursor(cursorDownLeft, hotSpot, CursorMode.Auto);
        }
        else if (angle > -112.5f && angle <= -67.5f)
        {
            Cursor.SetCursor(cursorDown, hotSpot, CursorMode.Auto);
        }
        else if (angle > -67.5f && angle <= -22.5f)
        {
            Cursor.SetCursor(cursorDownRight, hotSpot, CursorMode.Auto);
        }
        else if (angle > -22.5f && angle <= 22.5f)
        {
            Cursor.SetCursor(cursorRight, hotSpot, CursorMode.Auto);
        }
        else if (angle > 22.5f && angle <= 67.5f)
        {
            Cursor.SetCursor(cursorUpRight, hotSpot, CursorMode.Auto);
        }
    }
}
