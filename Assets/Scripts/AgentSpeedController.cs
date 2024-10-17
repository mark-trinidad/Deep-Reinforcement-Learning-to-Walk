using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AgentSpeedController : MonoBehaviour
{
    public float baseSpeed = 5f; // Base speed of the agent
    public float maxSpeed = 20f; // Maximum speed
    public float minSpeed = 1f; // Minimum speed
    public float speedIncrement = 1f; // Speed change increment

    private float currentSpeed; // Current speed of the agent
    public TextMeshProUGUI speedText; // Reference to the UI Text displaying the speed

    private void Start()
    {
        currentSpeed = baseSpeed;
        UpdateSpeedText();
    }

    public void IncreaseSpeed()
    {
        currentSpeed = Mathf.Clamp(currentSpeed + speedIncrement, minSpeed, maxSpeed);
        UpdateSpeedText();
    }

    public void DecreaseSpeed()
    {
        currentSpeed = Mathf.Clamp(currentSpeed - speedIncrement, minSpeed, maxSpeed);
        UpdateSpeedText();
    }

    private void UpdateSpeedText()
    {
        speedText.text = $"{currentSpeed:F1}";
        // Apply the new speed to the agent (e.g., using a NavMeshAgent)
        // Replace this with your actual agent movement logic
        // For example:
        // GetComponent<NavMeshAgent>().speed = currentSpeed;
    }
}
