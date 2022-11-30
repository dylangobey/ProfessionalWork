using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteAppearence2 : MonoBehaviour
{
    public GameObject Image; // Creates a "Image" GameObject in Unity Editor
    public GameObject EndGameTrigger; // Creates a "EndGameTrigger" GameObject in Unity Editor

    private void OnTriggerEnter(Collider other) // When the Trigger is Entered, the Following Will Happen
    {
        if (other.tag == "Player") // If collider tag is "Player" the following will happen
        {
            Image.SetActive(true); // "Image" GameObject is set to inactive
            EndGameTrigger.SetActive(true); // "EndGameTrigger" is set to active
            Debug.Log("Entered"); // Debug Says "Entered" in Unity Editor 
        }
    }

    private void OnTriggerExit(Collider other) // When the Trigger is Left, the Following Will Happen
    {
        if (other.tag == "Player") // If collider tag is "Player" the following will happen
        {
            Image.SetActive(false); // "Image" GameObject is set to inactive
            Debug.Log("Exited"); // Debug Says "Exited" in Unity Editor
        }
    }
}
