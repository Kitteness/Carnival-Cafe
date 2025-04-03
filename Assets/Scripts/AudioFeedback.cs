using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class AudioFeedback : MonoBehaviour
{
    public AudioClip grabSound;
    private AudioSource audioSource;
    private XRGrabInteractable grabInteractable;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        grabInteractable = GetComponent<XRGrabInteractable>();

        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnGrab);
        }
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        audioSource.PlayOneShot(grabSound);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
