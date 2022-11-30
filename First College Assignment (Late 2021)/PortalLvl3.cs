using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalLvl3 : MonoBehaviour
{
    public GameObject PortalActive; // Fetches the "PortalActive" GameObject
    public GameObject PortalInactive; // Fetches the "PortalInactive" GameObject
    public GameObject SpawnLocation; // Fetches the "SpawnLocation" GameObject

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Box") // If the tag "Box" is found when it is triggered the following will occur
        {
            Instantiate(PortalActive, SpawnLocation.transform.position, SpawnLocation.transform.rotation); // Spawns the "PortalActive" GameObject on the "SpawnLocation" GameObject and fetches the "PortalActive" rotation and position
            Destroy(PortalInactive); // Destroys the "PortalInactive" GameObject from the scene
            Debug.Log("Triggered"); // In the console, it will say "Triggered"
        }
    }
}
