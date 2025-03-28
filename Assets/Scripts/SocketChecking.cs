using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class SocketChecking : MonoBehaviour
{

    [SerializeField] private XRSocketInteractor socket;
    [SerializeField] private GameObject correctPanel;
    [SerializeField] private GameObject incorrectPanel;
    [SerializeField] private GameObject orderPanel;
    [SerializeField] private GameObject noItemPanel;

    public void socketCheck(string tag)
    {
        IXRSelectInteractable interactable = null;

        if (socket.hasSelection)
        {
            interactable = socket.GetOldestInteractableSelected();
        }

        if (interactable != null)
        {
            if (interactable.transform.gameObject.tag == tag)
            {
                correctPanel.SetActive(true);
                orderPanel.SetActive(false);
            }
            else
            {
                incorrectPanel.SetActive(true);
                orderPanel.SetActive(false);
            }
        }
        else
        {
            noItemPanel.SetActive(true);
            orderPanel.SetActive(false);
        }
    }
}
