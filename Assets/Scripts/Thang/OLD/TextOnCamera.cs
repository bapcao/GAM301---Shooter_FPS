using TMPro;
using UnityEngine;

public class TextOnCamera : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Camera targetCamera;
    public Vector3 offset = new Vector3(0, 1, 0); // Offset from camera

    void Update()
    {
        if (targetCamera != null)
        {
            text.transform.position = targetCamera.transform.position + offset;
            text.transform.LookAt(targetCamera.transform); // Faces the camera
        }
    }
}