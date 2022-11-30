using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ExitButton() // Makes a "ExitButton()" function for the menu
    {
        Application.Quit(); // Closes the game 
        Debug.Log("Game Closed"); // Says "Game Closed" in console
    }

    public void StartGame() // Makes a "StartGame()" function for the menu
    {
        SceneManager.LoadScene("LevelOne"); // Loads the "LevelOne" scene
    }
}
