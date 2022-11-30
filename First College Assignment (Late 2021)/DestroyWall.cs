using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWall : MonoBehaviour
{
    public float hp; // This creates a new float within Unity where you can manipulate how much health the wall has //
    public GameObject Destroyed; // This creates a new section within the script within Unity where you can put the destroyed version of this wall // 

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Collider")
        {
            hp--;
        }
    } // This makes sure that when a object with a tag "Collider" it takes health from the wall //

    private void Update()
    {
        if(hp == 0)
        {
            Instantiate(Destroyed, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    } // This makes it that when the health of the wall is 0, it replaces the wall with the destroyed variant and simultaneously destroyes the in-tact wall // 
}