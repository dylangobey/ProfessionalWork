using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchScript : MonoBehaviour
{
    public bool isOn = false; // Creates a Bool Called "isOn" and is Defaulted to False
    public GameObject lightSource; // Creates a GameObject called "lightSource" in Unity Editor
    public bool failSafe = false; // Creates a Bool Called "failSafe" and is Defaulted to False

    private void Update() // Every frame, the following is checked
    {
        if (Input.GetKeyDown(KeyCode.L)) // If the Key "L" is Pressed, the Following Will Happen
        {
            if(isOn == false && failSafe == false) // If "isOn" and "failSafe" is false, the Following Will Happen
            {
                failSafe = true; // "failSafe" is set to True
                lightSource.SetActive(true); // "lightSource" GameObject is Set to Active
                isOn = true; // "isOn" is Set To True
                StartCoroutine(FailSafe()); // Starts the "FailSafe" IEnumerator
            }
            if (isOn == true && failSafe == false) // If "isOn" is Set to True and "failSafe" to False, The Following Will Happen
            {
                failSafe = true; // "failSafe" is Set to True
                lightSource.SetActive(false); // "lightSource" GameObject is Set to Inactive
                isOn = false; // "isOn" is Set to False;
                StartCoroutine(FailSafe()); // Starts the "FailSafe" IEnumerator
            }
        }
    }

    IEnumerator FailSafe() 
    {
        yield return new WaitForSeconds(0.25f); // After 0.25 Seconds Elapse, the Following Shall Happen
        failSafe = false; // "failSafe" is Set to False
    }
}