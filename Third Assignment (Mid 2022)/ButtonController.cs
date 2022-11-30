using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public GameObject Button; // Creates a "Button" GameObject in Unity Editor

    public void ReturnToMenu() // Creates a function called "ReturnToMenu"
    {
        SceneManager.LoadScene(0); // Loads "MainMenu" scene
    }

    public void Start() // At the start of the script, the following will happen
    {
        StartCoroutine(Fade()); // Starts "Fade" coroutine
    }

    IEnumerator Fade()
    {
        yield return new WaitForSeconds(3); // Waits 3 Seconds
        Button.SetActive(true); // Sets "Button" GameObject to active
        Debug.Log("Button Active"); // Debug Says "Button Active" in Unity Editor
    }
}
