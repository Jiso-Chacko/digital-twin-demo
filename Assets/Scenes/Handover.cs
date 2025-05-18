using UnityEngine;
using UnityEngine.UI;  // needed for UI Text
using TMPro;

public class Handover : MonoBehaviour
{
    [Header("Assign Your Ground Stations")]
    public Transform[] groundStations;

    [Header("UI Text Elements (optional)")]
    public TMP_Text currentStationText;
    public TMP_Text handoverCountText;

    private int currentStation = -1;
    private int handoverCount = 0;

    void Update()
    {
        // 1) Find the nearest station
        float bestDist = float.MaxValue;
        int nearest = -1;
        for (int i = 0; i < groundStations.Length; i++)
        {
            float dist = (transform.position - groundStations[i].position).sqrMagnitude;
            if (dist < bestDist)
            {
                bestDist = dist;
                nearest = i;
            }
        }

        // 2) If it’s changed, increment the handover count
        if (nearest != currentStation)
        {
            currentStation = nearest;
            handoverCount++;

            // 3) Update UI text if you supplied Text components
            if (currentStationText != null)
                currentStationText.text = $"Station: {groundStations[nearest].name}";
            if (handoverCountText != null)
                handoverCountText.text = $"Handovers: {handoverCount}";

            Debug.Log($"Handover → {groundStations[nearest].name}  |  Total: {handoverCount}");
        }
    }
}
