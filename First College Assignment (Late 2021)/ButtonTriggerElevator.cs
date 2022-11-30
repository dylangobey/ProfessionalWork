using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTriggerElevator : MonoBehaviour
{
    public GameObject moveplatform; // Fetches the moveplatform GameObject

    void Start()
    {
        gameObject.tag = "Box"; // Fetches the gameObject tag "Box"
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Box") // If the tag "Box" hits the trigger, the following will occur
        {
            moveplatform.transform.position += moveplatform.transform.up * Time.deltaTime;
        }
    }
}
