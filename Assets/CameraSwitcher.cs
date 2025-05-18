using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera[] cams;        // assign in Inspector: Main, Follow, TopDown
    private int current = 0;

    void Start()
    {
        // disable all except first
        for (int i = 0; i < cams.Length; i++)
            cams[i].gameObject.SetActive(i == 0);
    }

    void Update()
    {
        // press C to cycle cameras
        if (Input.GetKeyDown(KeyCode.C))
        {
            cams[current].gameObject.SetActive(false);
            current = (current + 1) % cams.Length;
            cams[current].gameObject.SetActive(true);
        }
    }
}