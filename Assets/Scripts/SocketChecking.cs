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
    public GameObject audioTarget;
    private AudioSource targetAudioSource;
    public AudioClip correctSound;
    public AudioClip incorrectSound;


    public void Start()
    {
        targetAudioSource = audioTarget.GetComponent<AudioSource>();
    }

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
                targetAudioSource.PlayOneShot(correctSound);
            }
            else
            {
                incorrectPanel.SetActive(true);
                orderPanel.SetActive(false);
                targetAudioSource.PlayOneShot(incorrectSound);
            }
        }
        else
        {
            noItemPanel.SetActive(true);
            orderPanel.SetActive(false);
            targetAudioSource.PlayOneShot(incorrectSound);
        }
    }
}
