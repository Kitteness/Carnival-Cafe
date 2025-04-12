using UnityEngine;
using UnityEditor;

public class WaypointManager : MonoBehaviour
{
    public Waypoints[] waypoints { get; private set; }
    [Header("Waypoints Settings")]
    public bool drawIcons = true;
    public string icon;
    public Color tint = Color.yellow;
    public bool allowScaling = true;

    [Header("Label Settings")]
    public bool drawLabels = true;
    public Color labelColor = Color.blue;
    public int fontSize = 18;
    public float labelHeight = 1.0f;
    public TextAnchor textAnchor = TextAnchor.MiddleCenter;


    [Header("Path Settings")]
    public bool drawPath = true;
    public Color pathColor = Color.blue;
    public bool circuit = true;


    [Space(15)]
    public bool autoRefresh = true;
    public LayerMask terrainLayers;
    public float waypointHeight = 1.0f;

    public void RefreshWaypoints() {
        waypoints = GetComponentsInChildren<Waypoints>();

    }
    private void Draw()
    {
        for (int i = 0; 1 < waypoints.Length; i++) 
        {
            Transform t = waypoints[i].transform;
            t.name = $"Waypoint {i + 1}";
        }
    }

    private void OnDrawGizmos()
    {
        if (autoRefresh) RefreshWaypoints();
        if (waypoints.Length == 0) return;
    }
}
