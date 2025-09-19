using System;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwipeInput : MonoBehaviour
{
    private UserInputAction input;
    private Scoring scoring;
    private Vector2 lastCursorPos = Vector2.zero;
    private bool isPressed = false;
    private bool isActive = false;
    public bool IsActive 
    {
        get => isActive;
        set
        {
            isActive = value;
            if (isActive)
            {
                OnEnable();
            }
            else
            {
                OnDisable();
            }
        }
    }
    public GameObject PictureObject { get => pictureObject; set => pictureObject = value; }

    [Header("Position")]
    [SerializeField][Tooltip("The objects resting-point.")] private float screenCenter;
    [Space]
    [Header("Rotation")]
    [SerializeField][Tooltip("Should the object rotate when moved.")] private bool doRotation;
    [SerializeField][Range(0, 20)][Tooltip("How much should the object rotate when moved.")] private float rotationMultiplier;
    [Space]
    [Header("Speed")]
    [SerializeField][Range(0, 0.05f)][Tooltip("How much should the object move when dragged.")] private float dragMultiplier;
    [SerializeField][Range(0, 0.5f)][Tooltip("How fast should the object move when let go.")] private float movementMultiplier;
    [Space]
    [Header("Distance")]
    [SerializeField][Range(1, 10)][Tooltip("The threshold for confirming an answer.")] private float answerDistance;
    [SerializeField][Range(10, 20)][Tooltip("The threshold for removing the card.")] private float destructionDistance;


    private void OnEnable()
    {
        // Enables the input, and activates the click/tap event
        scoring = gameObject.GetComponent<Scoring>();
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
            // activates the tracking of the cursor.
            lastCursorPos = Mouse.current.position.ReadValue();
            try
            {
                lastCursorPos += Touchscreen.current.position.ReadValue();
            }
            catch { }
            input.User.Drag.performed += OnDrag;
        }
        else
        {
            // deactivates the tracking of the cursor.
            input.User.Drag.performed -= OnDrag;
        }
    }
    private void OnDrag(InputAction.CallbackContext context)
    {
        Vector2 newCursorPos = Mouse.current.position.ReadValue();
        try
        {
            newCursorPos += Touchscreen.current.position.ReadValue();
        }
        catch { }
        Vector2 cursorDelta = newCursorPos - lastCursorPos;

        if (cursorDelta.x != 0)
        {
            gameObject.transform.position += new Vector3(cursorDelta.x * dragMultiplier, 0, 0);
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
        float distance = screenCenter - gameObject.transform.position.x;
        if (!isPressed)
        {
            if (Mathf.Abs(distance) > answerDistance)
            {
                gameObject.transform.position -= new Vector3(distance * movementMultiplier, 0, 0);
            }
            else if (Mathf.Abs(distance) < movementMultiplier)
            {
                gameObject.transform.position = new Vector3(screenCenter, 0, 0);
            }
            else
            {
                gameObject.transform.position += new Vector3(distance * movementMultiplier, 0, 0);
            }
        }


        if (Mathf.Abs(distance) > destructionDistance)
        {
            Answer(distance < 0);
            GameBehavior_SO.ActivateNextCard();
            Destroy(gameObject);
        }

        if (doRotation)
        {
            RotateObject(distance);
        }
    }


    private void RotateObject(float distance)
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 0, distance * rotationMultiplier);
    }


    public void Answer(bool side)
    {
        if (side)
        {
            scoring.Answer(SnakeType.Snog);
        }
        else
        {
            scoring.Answer(SnakeType.Hugorm);
        }
    }
}
