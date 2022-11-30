using UnityEditor;
using UnityEngine;

public class ForcedPerspective : MonoBehaviour
{
    [Header("Components")]
    public Transform target;
    
    [Header("Parameters")]
    public LayerMask targetMask;
    public LayerMask ignoreTargetMask;
    public float offsetFactor;
    
    [Header("Object Data")]
    float originalDistance;
    float originalScale;
    Vector3 targetScale;
    public bool isHeld = false;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        HandleInput();
        
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            if (target == null)
            {
                RaycastHit hit;
                if(Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, targetMask))
                {
                    target = hit.transform;
                    target.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    originalDistance = Vector3.Distance(transform.position, target.position);
                    originalScale = target.localScale.x;
                    targetScale = target.localScale;
                    isHeld = true;
                    
                }
            }
            else
            {
                target.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                isHeld = false;
                target = null;
            }
        }
    }

    //void ResizeTarget()
    //{
    //    if(target == null)
    //    {
    //        return;
    //    }
    //
    //    RaycastHit hit;
    //    if(Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, ignoreTargetMask))
    //    {
    //        target.position = hit.point - transform.forward * offsetFactor * targetScale.x;
    //        
    //        float currentDistance = Vector3.Distance(transform.position, target.position);
    //        float s = currentDistance / originalDistance;
    //        targetScale.x = targetScale.y = targetScale.z = s;
    //
    //        target.transform.localScale = targetScale * originalScale;
    //    }
    //}

    
}