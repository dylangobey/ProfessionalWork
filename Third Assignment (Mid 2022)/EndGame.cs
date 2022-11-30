using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) // When the Trigger is Entered, the Following Will Happen
    {
        if(other.gameObject.tag == "Player") // If collider tag is "Player" the following will happen
        {
            SceneManager.LoadScene(2); // Loads the "EndGame" Scene
            Cursor.lockState = CursorLockMode.None; // Unlocks the cursor for movement
        }
    }
}
