using UnityEngine;

public class MagicController : MonoBehaviour
{
    public GameObject magicParticles;

    public void magic()
    {
        Instantiate(magicParticles, transform.position, transform.rotation);
        Debug.Log("Magic!");
    }
}
