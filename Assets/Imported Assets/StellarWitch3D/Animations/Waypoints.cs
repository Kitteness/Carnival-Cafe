using UnityEngine;
using UnityEngine.AI;
using UnityEditor;

public class Waypoints : MonoBehaviour
{

    private string icon;
    private Color tint;
    private bool allowScaling;

    private WaypointManager waypointManager;
    private void OnValidate()
    {
        if (waypointManager == null) waypointManager = GetComponentInParent<WaypointManager>();
        icon = waypointManager.icon;
        allowScaling = waypointManager.allowScaling;
        tint = waypointManager.tint;
    }
    private void OnDrawGizmos()
    {
        if (waypointManager.drawIcons && !string.IsNullOrEmpty(icon))
            Gizmos.DrawIcon(transform.position, icon, allowScaling, tint);
    }

  
}
