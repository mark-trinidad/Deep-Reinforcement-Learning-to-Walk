using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;

public class TrainingManager : MonoBehaviour
{
    public InputField runIDInput; // Reference to the InputField for RunID

    void Start()
    {
        // Start training when the scene loads
        StartTraining();
    }

    // Method to start ML-Agents training automatically
    void StartTraining()
    {
        string runID = runIDInput.text; // Get the RunID from the InputField

        // Check if the RunID is valid (you can implement IsValidRunID() as needed)
        if (IsValidRunID(runID))
        {
            // Run the ML-Agents command with the given RunID
            RunMLAgentsCommand(runID);
        }
        else
        {
            // Display an error message or handle invalid RunID
            UnityEngine.Debug.LogError("Invalid RunID: " + runID);
        }
    }

    // Method to run the ML-Agents command with the given RunID
    void RunMLAgentsCommand(string runID)
    {
        // Construct the ML-Agents command
        string mlAgentsCommand = "mlagents-learn --run-id=" + runID;

        // Execute the command using System.Diagnostics.Process
        Process.Start("CMD.exe", "/c " + mlAgentsCommand); // /c closes CMD window after execution
    }

    // Method to check if the RunID is valid (implement your validation logic here)
    bool IsValidRunID(string runID)
    {
        return !string.IsNullOrEmpty(runID);
    }
}
