using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class OnButtonPress : MonoBehaviour
{
    public InputAction action;

    public UnityEvent OnPress;
    public UnityEvent OnRelease;

    public void Awake()
    {
        action.started += Pressed;
        action.canceled += Released;
    }

    public void OnEnable()
    {
        action.Enable();
    }

    public void OnDisable()
    {
        action.Disable();
    }

    private void Pressed(InputAction.CallbackContext context)
    {
        OnPress.Invoke();
    }

    private void Released(InputAction.CallbackContext context)
    {
        OnRelease.Invoke();
    }
}
