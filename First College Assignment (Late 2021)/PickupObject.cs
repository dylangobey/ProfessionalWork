using UnityEngine;
/// <summary>
/// Simple example of Grabbing system.
/// </summary>
public class PickupObject : MonoBehaviour
{
    [SerializeField]
    private Camera characterCamera; // Fetches the "Camera" for the player
    [SerializeField]
    private Transform slot; // Fetches a empty GameObject where the item will be placed
    private PickableItem pickedItem; // Fetches the "PickableItem" Script
    /// <summary>
    /// Method called very frame.
    /// </summary>
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // When the key "E" is pressed the following will happen
        {
            if (pickedItem)
            {
                DropItem(pickedItem); // If the item is already in the empty GameObject, then you will drop the item
            }
            else
            {
                var ray = characterCamera.ViewportPointToRay(Vector3.one * 0.5f); // Fetches which direction the players camera is looking
                RaycastHit hit; 
                if (Physics.Raycast(ray, out hit, 1.5f))
                {
                    var pickable = hit.transform.GetComponent<PickableItem>(); // Fetches to see if the object the player is trying to pickup has the "PickableItem" script on it
                    if (pickable) // If the item does have the script then
                    {
                        PickItem(pickable); // Run the "PickItem" function
                    }
                }
            }
        }
    }
    /// <summary>
    /// Method for picking up item.
    /// </summary>
    /// <param name="item">Item.</param>
    private void PickItem(PickableItem item) // When the function is called, the following will occur
    {
        pickedItem = item; 
        item.Rb.isKinematic = true; // Changes the items Rigidbody kinematics to true
        item.Rb.velocity = Vector3.zero; // Sets the items velocity to zero
        item.Rb.angularVelocity = Vector3.zero; // Set the items angular velocity to zero
        item.transform.SetParent(slot); // Sets the items parent to the empty GameObject
        item.transform.localPosition = Vector3.zero; // Sets the local position to zero
        item.transform.localEulerAngles = Vector3.zero; // sets the Euler Angles to zero
    }
    /// <summary>
    /// Method for dropping item.
    /// </summary>
    /// <param name="item">Item.</param>
    private void DropItem(PickableItem item) // When the function is called, the following will occur
    {
        pickedItem = null; // Sets the pickedItem to nothing
        item.transform.SetParent(null); // Sets the parent to nothing
        item.Rb.isKinematic = false; // Changes the items Rigidbody kinematics to false
        item.Rb.AddForce(item.transform.forward * 2, ForceMode.VelocityChange); // Sets the items velocity to 2 on the forward offset
    }
}