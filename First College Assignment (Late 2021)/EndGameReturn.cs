using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameReturn : MonoBehaviour
{
    public void ReturnToMenu() // Creates a new function called "ReturnToMenu()"
    {
        SceneManager.LoadScene("Main Menu"); // Loads the scene called "Main Menu"
    }
}
