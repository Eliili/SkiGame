using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFlag : MonoBehaviour
{
    public float raceDuration = 60f; // Duration of the race in seconds
    private bool raceStarted = false; // Flag to track if the race has started
    private float timeLeft; // Time left in the race

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !raceStarted)
        {
            Debug.Log("Player entered the start flag collider.");
            StartRace();
        }
    }

    private void StartRace()
    {
        raceStarted = true;
        timeLeft = raceDuration;
        Debug.Log("Race started!");
        StartCoroutine(RaceCountdown());
    }

    private IEnumerator RaceCountdown()
    {
        while (timeLeft > 0)
        {
            yield return new WaitForSeconds(1f); // Wait for 1 second
            timeLeft -= 1f; // Decrease time left by 1 second
        }

        EndRace();
    }

    private void EndRace()
    {
        Debug.Log("Race ended!");
    }
}
