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

    public void socketCheck(string tag)
    {

        IXRSelectInteractable interactable = socket.GetOldestInteractableSelected();

        Debug.Log(interactable.transform.name + " in socket of " + socket.transform.name);

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
}
