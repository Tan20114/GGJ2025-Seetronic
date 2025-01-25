using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToScene1 : MonoBehaviour
{
    SceneLoader sl;
    InteractableObject io;

    private static Dictionary<string, Vector3> savedPositions = new Dictionary<string, Vector3>();
    public GameObject player; // Reference to the player object

    // Static variable to keep finishPewPew state across scenes
    public static bool finishPewPew = false;

    private void Start()
    {
        sl = FindAnyObjectByType<SceneLoader>();
        io = GetComponent<InteractableObject>();

        // Restore the player's position if it was saved
        string currentScene = SceneManager.GetActiveScene().name;
        if (savedPositions.ContainsKey(currentScene))
        {
            player.transform.position = savedPositions[currentScene];
        }

        // Restore the finishPewPew state (optional: log it)
        Debug.Log($"FinishPewPew state: {finishPewPew}");
    }

    bool isTrigger = false;

    private void Update()
    {
        if (!isTrigger && io.isInteracted) // Example trigger to go back
        {
            isTrigger = true;
            SaveStateAndSwitchScene(4); // Replace with your target scene index
        }
    }

    public void SaveStateAndSwitchScene(int index)
    {
        finishPewPew = true;

        // Save the player's current position
        string currentScene = SceneManager.GetActiveScene().name;
        savedPositions[currentScene] = player.transform.position;

        // Log or debug the save for clarity
        Debug.Log($"Saved position for {currentScene}: {player.transform.position}");
        Debug.Log($"Saving finishPewPew: {finishPewPew}");

        // Switch to the target scene
        StartCoroutine(sl.LoadScene(index));
    }
}
