using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // When the key "Escape" is pressed the following will occur
        {
            Application.Quit(); // Closes the game
        }
    }
}
