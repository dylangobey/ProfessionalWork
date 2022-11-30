using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTriggerElevator2 : MonoBehaviour
{
    public GameObject moveplatform; // Fetches the "MovePlatform" GameObject
    float timeElapsed; // Creates a float called "timeElapsed"
    [SerializeField] float moveDuration; // Creates a float called "moveDuration"
    [SerializeField] float waitBetweenLerp; // Creates a float called "waitBetweenLerp"
    float waitElapsed; // Creates a float "waitElapsed"
    Vector3 startPos; // Fetches a vector called "startPos"

    [SerializeField] Transform endPosTransform; // Fetches a transform called "endPosTransform"
    Vector3 endPos; // Fetches a vector called "endPos"

    void Start()
    {
        startPos = moveplatform.transform.position; // Sets the startPos Vector to the MovePlatform's Position
        endPos = endPosTransform.position; // Sets the endPos Vector to the endPosTransform's Position
        gameObject.tag = "Box"; // Fetches the gameObject tag called "Box"
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Box") // If the tag "Box" hits the trigger, the following occurs
        {
            new WaitForSeconds(2); // Waits for 2 seconds then does the following
            moveplatform.GetComponent<Animator>().SetFloat("speed", 1f); // Fetches the moveplatform Animator component and sets the float "speed" to 1
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Box") // If the tag "Box" hits the trigger, the following occurs
        {
            moveplatform.GetComponent<Animator>().SetFloat("speed", -1f); // Fetches the moveplatform Animator component and sets the float "speed" to -1
        }
    }
}
