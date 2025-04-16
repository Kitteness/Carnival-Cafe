using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using TMPro;

public class CustomerManagement : MonoBehaviour
{
    [SerializeField] private GameObject[] customers;
    [SerializeField] private string[] tags;
    private int customerNumber = 0;
    [SerializeField] private XRSocketInteractor socket;
    [SerializeField] private GameObject correctPanel;
    [SerializeField] private GameObject incorrectPanel;
    [SerializeField] private GameObject orderPanel;
    [SerializeField] private GameObject noItemPanel;
    [SerializeField] private GameObject finalPanel;
    [SerializeField] private TextMeshProUGUI orderText;
    [SerializeField] private TextMeshProUGUI finalText;
    public GameObject helloPanel;
    public GameObject audioTarget;
    private AudioSource targetAudioSource;
    public AudioClip correctSound;
    public AudioClip incorrectSound;

    private float currentTime = 0;

    public void Start()
    {
        targetAudioSource = audioTarget.GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        currentTime += Time.deltaTime;
    }

    public void socketCheck()
    {
        IXRSelectInteractable interactable = null;

        if (socket.hasSelection)
        {
            interactable = socket.GetOldestInteractableSelected();
        }

        if (interactable != null)
        {
            if (interactable.transform.gameObject.tag == tags[customerNumber])
            {
                correctPanel.SetActive(true);
                orderPanel.SetActive(false);
                targetAudioSource.PlayOneShot(correctSound);
                interactable.transform.gameObject.SetActive(false);
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

    public void Leave()
    {
        customers[customerNumber].GetComponent<Animator>().SetBool("Leave", true);
        customerNumber++;
        if (customerNumber < customers.Length)
        {
            customers[customerNumber].SetActive(true);
            orderText.text = "I'd like to order " + tags[customerNumber] + ".";
        }
        else
        {
            finalText.text = "You completed every customer's order in " + currentTime.ToString("0") + " seconds!";
            finalPanel.SetActive(true);
        }
    }
}