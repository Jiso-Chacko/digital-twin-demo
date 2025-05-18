using UnityEngine;

public class Orbit : MonoBehaviour
{
    [Header("Orbit Settings")]
    public Transform centerObject;    // drag in your Earth here
    public float orbitRadius = 50f;   // match your Earth radius
    public float orbitPeriod = 20f;   // seconds per full revolution

    void Update()
    {
        // Calculate angle (radians) based on elapsed time
        float angle = (Time.time / orbitPeriod) * 2f * Mathf.PI;

        // Compute offset in the XZ plane
        Vector3 offset = new Vector3(
            Mathf.Cos(angle) * orbitRadius,
            0f,
            Mathf.Sin(angle) * orbitRadius
        );

        // Update the Satellite’s position
        transform.position = centerObject.position + offset;
    }
}
