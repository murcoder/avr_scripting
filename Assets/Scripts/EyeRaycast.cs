using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeRaycast : MonoBehaviour
{
    [SerializeField] private float _rayLength = 50f;
    private Transform _cameraTransform;
    private GazeTarget _currentGazedObject;

    [SerializeField] private Reticle _reticle;


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
        // Perform the Raycast forwards to see if we hit an interactive item
        if (Physics.Raycast(ray, out hit, _rayLength) && hit.collider != null)
        {
            Debug.Log("Hit: " + hit.point);
            _reticle.SetPosition(hit);
            
            // Get the GazeTarget of the target GameObject
            var interactive = hit.collider.GetComponent<GazeTarget>();
            if (interactive != _currentGazedObject)
            {
                // Send GazeOut event to previous interactable
                DeactiveateLastInteractible();
            }

            // If we hit an interactive item and it's not the same as
            // the last interactive item, then call OnGazeEntered
            if (interactive)
            {
                // Send GazeEntered event to new interactable
                interactive.OnGazeEntered(hit.point);
            }

            _currentGazedObject = interactive;
        }
        else
        {
            _reticle.SetPosition();
            // Nothing was hit, deactivate the last interactive item.
            DeactiveateLastInteractible();
        }
    }

    private void DeactiveateLastInteractible()
    {
        if (_currentGazedObject == null)
            return;
        _currentGazedObject.OnGazeOut();
        _currentGazedObject = null;
    }
}