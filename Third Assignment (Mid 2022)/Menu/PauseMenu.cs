using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{


    private void Update() //Every frame the following occurs
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // If the "Escape" key is pressed, the following will happen
        {
            SceneManager.LoadScene(0); // Loads "MainMenu" Scene
            Debug.Log("Loaded Main Menu"); // Debug Says "Loaded Main Menu" in Unity Editor
            Cursor.lockState = CursorLockMode.None; // Unlocks cursor to be usable
        }
    }
}
