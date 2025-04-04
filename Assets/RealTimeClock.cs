using UnityEngine;
using TMPro;
using System;

public class RealTimeClock : MonoBehaviour
{
    [Tooltip("Reference to the TextMeshPro text element that displays the time.")]
    public TMP_Text timeText;

    void Update()
    {
        // Update the text element with the current system time formatted as hours:minutes:seconds.
        timeText.text = DateTime.Now.ToString("HH:mm:ss");
    }
}
