using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    public string levelName; // Name of the level for which the leaderboard is being used
    public List<float> bestTimes = new List<float>(); // List to store the best times

    private const int maxEntries = 5; // Maximum number of entries in the leaderboard

    private FinishFlag finishFlag;

    private void Start()
    {
        // Load saved times from PlayerPrefs
        LoadBestTimes();
    }

    // Call this method whenever a race is stopped
    public void OnRaceStop()
    {
        float raceTime = finishFlag.RaceTime;
        Debug.Log("Race Time: " + raceTime);
        // Check if the current race time qualifies for the leaderboard
        if (IsQualifiedForLeaderboard(raceTime))
        {
            // Add the time to the leaderboard and update PlayerPrefs
            bestTimes.Add(raceTime);
            SortAndTrimLeaderboard();
            SaveBestTimes();
            PrintLeaderboard();
        }
    }

    private bool IsQualifiedForLeaderboard(float raceTime)
    {
        // Check if the time is faster than any of the current leaderboard entries
        return bestTimes.Count < maxEntries || raceTime < bestTimes[bestTimes.Count - 1];
    }

    private void SortAndTrimLeaderboard()
    {
        // Sort the leaderboard in ascending order
        bestTimes.Sort();

        // Trim the leaderboard to keep only the top entries
        if (bestTimes.Count > maxEntries)
        {
            bestTimes.RemoveRange(maxEntries, bestTimes.Count - maxEntries);
        }
    }

    private void SaveBestTimes()
    {
        // Save the best times to PlayerPrefs
        for (int i = 0; i < bestTimes.Count; i++)
        {
            PlayerPrefs.SetFloat(levelName + "_Time_" + i, bestTimes[i]);
        }
        PlayerPrefs.Save();
    }

    private void LoadBestTimes()
    {
        // Load the best times from PlayerPrefs
        bestTimes.Clear();
        for (int i = 0; i < maxEntries; i++)
        {
            float time = PlayerPrefs.GetFloat(levelName + "_Time_" + i, float.MaxValue);
            if (time != float.MaxValue)
            {
                bestTimes.Add(time);
            }
        }
    }

    private void PrintLeaderboard()
    {
        // Output the leaderboard to the console
        Debug.Log("Leaderboard for " + levelName + ":");
        for (int i = 0; i < bestTimes.Count; i++)
        {
            Debug.Log((i + 1) + ". " + FormatTime(bestTimes[i]));
        }
    }

    private string FormatTime(float time)
    {
        // Format the time as minutes:seconds.milliseconds
        TimeSpan timeSpan = TimeSpan.FromSeconds(time);
        return string.Format("{0:00}:{1:00}.{2:000}", timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);
    }
}