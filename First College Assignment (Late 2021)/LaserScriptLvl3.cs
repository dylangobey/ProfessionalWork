using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaserScriptLvl3 : MonoBehaviour
{
    public GameObject Player; // Fetches the Player GameObject

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") // If the tag "Player" is found when it is triggered the following will occur
        {
            SceneManager.LoadScene("DeathScreenLvl3"); // Loads the DeathScreenLvl3 Scene
            Cursor.lockState = CursorLockMode.Confined; // Unlocks the mouse so the buttons can be pressed;
            Debug.LogWarning("Player Killed"); // In the console, it will say "Player Killed"
        }
    }
}
