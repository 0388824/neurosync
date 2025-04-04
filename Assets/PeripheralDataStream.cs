using UnityEngine;
using TMPro;

public class PeripheralDataStream : MonoBehaviour
{
    public TMP_Text dataText; // Assign PeripheralData (Text) here

    private float neuralLink = 87f;  // Starting value for Neural Link
    private float memoryUsed = 32f;  // Starting value for Memory Cache

    void Start()
    {
        InvokeRepeating("UpdateData", 1f, 1f); // Update every second
    }

    void UpdateData()
    {
        // Fluctuate Neural Link between 85% and 89%
        neuralLink = Mathf.Clamp(neuralLink + Random.Range(-1f, 1f), 85f, 95f);

        // Fluctuate Memory Used between 4GB and 64GB
        memoryUsed = Mathf.Clamp(memoryUsed + Random.Range(-20f, 20f), 4f, 64f);

        // Update UI Text
        dataText.text = $"Neural Link: {neuralLink:F1}%\n" +
                        $"Memory Cache: {memoryUsed:F1}GB / 64GB";
    }
}
