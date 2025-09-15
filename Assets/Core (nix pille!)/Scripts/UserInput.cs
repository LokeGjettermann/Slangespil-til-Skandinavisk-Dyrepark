using UnityEngine;
using UnityEngine.InputSystem;

public class UserInput : MonoBehaviour
{
    private UserInputAction input;
    private Vector2 lastCursorPos = Vector2.zero;
    private bool isPressed = false;

    private void OnEnable()
    {
        input = new UserInputAction();
        input.User.Enable();

        input.User.Touch.performed += OnTouch;
    }

    private void OnDisable()
    {
        input.User.Disable();

        input.User.Touch.performed -= OnTouch;
    }

    private void OnTouch(InputAction.CallbackContext context)
    {
        isPressed = !isPressed;
        if (isPressed)
        {
            Debug.Log("thing pressed");
            lastCursorPos = Mouse.current.position.ReadValue() + Touchscreen.current.position.ReadValue();
            input.User.Drag.performed += OnDrag;
        }
        else
        {
            Debug.Log("thing unpressed");
            input.User.Drag.performed -= OnDrag;
        }
    }
    private void OnDrag(InputAction.CallbackContext context)
    {
        Vector2 newCursorPos = Mouse.current.position.ReadValue() + Touchscreen.current.position.ReadValue();
        Vector2 cursorDelta = newCursorPos - lastCursorPos;
        //Debug.Log($"dragged the thing by: {cursorDelta.x}");

        if (cursorDelta.x != 0)
        {
            gameObject.transform.position += new Vector3(cursorDelta.x / 100, 0, 0);
            Debug.Log($"dragged the thing by: {cursorDelta.x}");
        }
        lastCursorPos += cursorDelta;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
