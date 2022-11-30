using UnityEngine;

public class spawnBlock : MonoBehaviour
{
    public GameObject block; // Fetches the block GameObject
    public Transform spawnPoint; // Fetches the spawnPoint Empty GameObject
    public bool isActive = true;
    private void OnTriggerEnter(Collider other)
    {
       if (other.CompareTag("Player")) // If the tag "Player" is hit against the trigger, the following will occur
        {
            Instantiate(block, spawnPoint.position, Quaternion.identity); // Spawns the "Block" GameObject on the "spawnPoint" Empty GameObject, mirroring its position
            Destroy(gameObject);
            isActive = false;
        }
    }

    private void Update()
    {
        if(isActive == false)
        {
            Destroy(gameObject);
        }
    }
}