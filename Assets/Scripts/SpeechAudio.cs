using UnityEngine;

public class SpeechAudio : MonoBehaviour
{
    public GameObject audioTarget;
    private AudioSource targetAudioSource;
    public AudioClip textBleeps;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Starte()
    {
        targetAudioSource = audioTarget.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void OnEnable()
    {
        targetAudioSource.PlayOneShot(textBleeps);
    }
}
