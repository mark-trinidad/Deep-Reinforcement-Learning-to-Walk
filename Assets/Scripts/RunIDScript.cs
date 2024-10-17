using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;

public class PopupPanelManager : MonoBehaviour
{
    public GameObject popupPanel;
    public InputField runIDInput; // Make sure this is of type InputField
    public GameObject errorMessageText; // Reference to the text GameObject for error messages
    public GameObject errorMessageText1; // Reference to the text GameObject for error messages
    public GameObject trainingModel;
    public int maxRunIDLength = 10; // Maximum number of characters for RunID
    public float fadeDuration = 1f; // Duration for fade-out effect in seconds
    public float trainingDelay = 5f; // Delay in seconds before starting training

    void Start()
    {
        // Listen for Enter key press event in the input field
        runIDInput.onEndEdit.AddListener(delegate { SaveRunID(); });
    }

    // Method to show the popup panel
    public void ShowPopupPanel()
    {
        popupPanel.SetActive(true);
        runIDInput.Select(); // Automatically select the input field for typing
    }

    // Method to confirm the RunID input
    public void ConfirmRunID()
    {
        string runID = runIDInput.text; // Get the text from the InputField

        if (IsValidRunID(runID))
        {
            // Save the RunID using PlayerPrefs for persistence
            PlayerPrefs.SetString("RunID", runID);
            PlayerPrefs.Save();

            // Run the ML-Agents command with the saved RunID
            RunMLAgentsCommand(runID);
            StartCoroutine(DelayedStartTraining());
            ClosePopupPanel();
        }
        else
        {
            ShowErrorMessage(runID);
            StartCoroutine(FadeOutErrorMessage());
        }
    }

    // Method to check if the RunID is valid
    bool IsValidRunID(string runID)
    {
        return !string.IsNullOrEmpty(runID) && runID.Length <= maxRunIDLength;
    }

    // Method to run the ML-Agents command with the given RunID
void RunMLAgentsCommand(string runID)
{

    // Construct the ML-Agents command 
    string mlAgentsCommand = "mlagents-learn --run-id=" + runID;

    // Create a new process start info
    ProcessStartInfo psi = new ProcessStartInfo();
    psi.FileName = "CMD.exe";
    psi.Arguments = "/k " + mlAgentsCommand; // /k keeps CMD window open after execution

    // Start the process
    Process.Start(psi);
}

    // Method to close the popup panel
    public void ClosePopupPanel()
    {
        popupPanel.SetActive(false);
    }

    // Method to save the RunID when Enter key is pressed
    public void SaveRunID()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            ConfirmRunID(); // Call ConfirmRunID() when Enter is pressed
        }
    }

    // Method to show error message and set text content
    void ShowErrorMessage(string runID)
    {
        if (errorMessageText == null)
        {
            UnityEngine.Debug.LogError("errorMessageText is not assigned.");
            return;
        }

        UnityEngine.Debug.Log("Error message GameObject: " + errorMessageText.name);

        if (errorMessageText != null)
        {
            if (string.IsNullOrEmpty(runID))
            {
                errorMessageText.SetActive(true);
            }
            else if (runID.Length > maxRunIDLength)
            {
                errorMessageText1.SetActive(true);
            }
        }
        else
        {
            UnityEngine.Debug.LogError("Text component not found on errorMessageText.");
        }
    }

    // Coroutine for fade-out effect of error message
    IEnumerator FadeOutErrorMessage()
    {
        TextMeshProUGUI errorText = errorMessageText.GetComponent<TextMeshProUGUI>();
        Color textColor = errorText.color;

        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration); // Calculate alpha value
            errorText.color = new Color(textColor.r, textColor.g, textColor.b, alpha);
            yield return null;
        }

        errorMessageText.SetActive(false);
        errorText.color = textColor; // Reset text color

        TextMeshProUGUI errorText1 = errorMessageText1.GetComponent<TextMeshProUGUI>();
        Color textColor1 = errorText1.color;

        timer = 0f; // Reset timer for the second fade-out
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration); // Calculate alpha value
            errorText1.color = new Color(textColor1.r, textColor1.g, textColor1.b, alpha);
            yield return null;
        }

        errorMessageText1.SetActive(false);
        errorText1.color = textColor1; // Reset text color
    }

    // Method to hide the popup panel in response to a button click
    public void HidePopupPanel()
    {
        ClosePopupPanel(); // Call the existing close method
    }

    IEnumerator DelayedStartTraining()
    {
        yield return new WaitForSeconds(trainingDelay); // Wait for the specified delay
        trainingModel.SetActive(true); // Start the training after delay
    }
}
