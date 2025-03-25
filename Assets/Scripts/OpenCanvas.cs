using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class OpenCanvas : MonoBehaviour
{
    public GameObject canvas;

    public InputActionReference openCanvasAction;

    public void Awake()
    {
        openCanvasAction.action.Disable();
        openCanvasAction.action.performed += ToggleMenu;
    }

    private void ToggleMenu(InputAction.CallbackContext context)
    {
        canvas.SetActive(!canvas.activeSelf);
    }

}
