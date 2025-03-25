using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Teleportation;

public class TeleportManager : MonoBehaviour
{
    [SerializeField] Slider teleportSlider;
    [SerializeField] TeleportationProvider provider;

    public void ChangeTeleport()
    {
        provider.delayTime = teleportSlider.value * 2;
    }
}
