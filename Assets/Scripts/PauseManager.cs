using UnityEngine;

public class PauseSystem : MonoBehaviour
{
    private bool isPaused = false;

    private void Update()
    {
        // Check if the Space key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TogglePause();
        }
    }

    private void TogglePause()
    {
        // Toggle the pause state
        isPaused = !isPaused;

        // Set the time scale to freeze or resume game logic
        Time.timeScale = isPaused ? 0f : 1f;
    }
}
