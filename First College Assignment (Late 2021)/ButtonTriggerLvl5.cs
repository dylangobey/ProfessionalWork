using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTriggerLvl5 : MonoBehaviour
{
    public GameObject Panel; // Fetches the "Panel" GameObject
    public GameObject PortalActive; // Fetches the "PortalActive" GameObject
    public GameObject PortalInactive; // Fetches the "PortalInactive" GameObject
    public GameObject SpawnLocation; // Fetches the "SpawnLocation" GameObject

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Box") // If the tag "Box" hits the trigger, the following will occur
        {
            Instantiate(PortalActive, SpawnLocation.transform.position, SpawnLocation.transform.rotation); // Places the "PortalActive" GameObject where the "SpawnLocation" GameObject is and mirrors the position and rotation.
            Destroy(PortalInactive); // Destroys the "PortalInactive" GameObject
            Destroy(Panel); // Destroys the "Panel" GameObject
            Debug.LogWarning("Destroyed Panel and Replaced Portal"); // Says "Destroyed Panel and Replaced Portal" in console
        }
    }
}
