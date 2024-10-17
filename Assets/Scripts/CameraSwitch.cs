using TMPro;
using UnityEngine;
using UnityEngine.UI; // Add this line to use UI elements

public class CameraSwitch : MonoBehaviour
{
    public Camera[] cameras; // An array of cameras you want to switch between
    private int currentCameraIndex = 0;

    // Add UI Text elements for displaying the view mode
    public TextMeshProUGUI viewModeText;

    private void Start()
    {
        // Enable the initial camera
        EnableCamera(currentCameraIndex);
    }

    private void Update()
    {
        // Toggle between cameras when the Tab key is pressed
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            currentCameraIndex = (currentCameraIndex + 1) % cameras.Length;
            EnableCamera(currentCameraIndex);

            // Update the view mode text
            UpdateViewModeText();
        }
    }

    private void EnableCamera(int index)
    {
        // Disable all cameras except the one at the specified index
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].enabled = (i == index);
        }
    }

    private void UpdateViewModeText()
    {
        // Set the view mode text based on the current camera
        string viewMode = (currentCameraIndex == 0) ? "Front View" : "Top View" ;
        viewModeText.text = $"{viewMode}";
    }
}
