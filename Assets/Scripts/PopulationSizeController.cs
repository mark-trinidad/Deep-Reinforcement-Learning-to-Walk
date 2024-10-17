using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopulationController : MonoBehaviour
{
    public TextMeshProUGUI populationText; // Reference to the UI Text displaying the population count
    public int maxPopulation = 100; // Maximum population size
    public int minPopulation = 1; // Minimum population size

    private int population = 1; // Initial population size

    private void Start()
    {
        UpdatePopulationText();
    }

    public void IncreasePopulation()
    {
        population++;
        ClampPopulation();
        UpdatePopulationText();
    }

    public void DecreasePopulation()
    {
        population--;
        ClampPopulation();
        UpdatePopulationText();
    }

    private void ClampPopulation()
    {
        population = Mathf.Clamp(population, minPopulation, maxPopulation);
    }

    private void UpdatePopulationText()
    {
        populationText.text = $"{population}";
    }
}
