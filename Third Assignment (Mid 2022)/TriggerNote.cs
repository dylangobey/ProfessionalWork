using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerNote : MonoBehaviour
{
    public GameObject NoteToReplace; // Creates a "NoteToReplace" GameObject in Unity Editor
    public GameObject NoteToPlace; // Creates a "NoteToPlace" GameObject in Unity Editor
    public GameObject TableToDestroy; // Creates a "TableToDestroy" GameObject in Unity Editor
    public GameObject TableToPlace; // Creates a "TableToPlace" GameObject in Unity Editor

    public void OnTriggerEnter(Collider other) // When the Trigger is Entered, the Following Will Happen
    {
        if(other.gameObject.tag == "Player") // If the gameObject's Tag is "Player", the Following Will Happen 
        {
            Destroy(gameObject); // Destroys Itself
            Destroy(NoteToReplace); // Destroys "NoteToReplace"
            Destroy(TableToDestroy); // Destroys "TableToDestroy"
            NoteToPlace.SetActive(true); // Sets "NoteToPlace" as Active
            TableToPlace.SetActive(true); // Sets "TableToPlace" as Active
            Debug.Log("Triggered"); // Debug Says "Triggered" in Unity Editor
        }
    }
}
