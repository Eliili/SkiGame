using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishFlag : MonoBehaviour
{
    private bool raceFinished = false; // Flag to track if the race has finished
    private float raceTime; // Time taken to complete the race
    public Text raceTimeText; // Reference to a UI Text element to display the race time

    public float RaceTime => raceTime;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !raceFinished)
        {
            Debug.Log("Player crossed the finish line.");
            EndRace();
        }
    }

    private void EndRace()
    {
        raceFinished = true;
        raceTime = Time.time; // Record the time when the player crosses the finish line
        DisplayRaceTime();
        // You can trigger any end-of-race events here (e.g., disable player controls, display race results, etc.)
    }

    private void DisplayRaceTime()
    {
        if (raceTimeText != null)
        {
            float minutes = Mathf.FloorToInt(raceTime / 60);
            float seconds = Mathf.FloorToInt(raceTime % 60);
            float milliseconds = Mathf.FloorToInt((raceTime - Mathf.Floor(raceTime)) * 1000);
            raceTimeText.text = string.Format("Race Time: {0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
        }
    }
}
