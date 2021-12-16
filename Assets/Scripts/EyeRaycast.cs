using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeRaycast : MonoBehaviour
{
    [SerializeField] private float _rayLength = 50f;
   
    private Transform _cameraTransform;
    
    
    //TODO Add Gaze & Events
    
    // Start is called before the first frame update
    void Start()
    {
        _cameraTransform = GetComponent<Camera>().transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PerformRaycast();
    }

    private void PerformRaycast()
    {
        var fwd = _cameraTransform.forward;
        var ray = new Ray(_cameraTransform.position, fwd);
        
        // Only visible in editor (scene)
        Debug.DrawRay(_cameraTransform.position, fwd * _rayLength, Color.green);

        RaycastHit hit;
        // Perform the Raycast forwards to see if we hit an itneractive item
        if (Physics.Raycast(ray, out hit, _rayLength) && hit.collider != null)
        {
            Debug.Log("Hit: " + hit.point);
        }
    }

}
