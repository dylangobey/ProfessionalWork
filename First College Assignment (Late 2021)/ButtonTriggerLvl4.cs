using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTriggerLvl4 : MonoBehaviour
{
    public GameObject Panel; // Fetches the "Panel" GameObject

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Box") // If the tag "Box" hits the trigger, the following will happen
        {
            Destroy(Panel); // Destroys the "Panel" GameObject
        }
    }
}
