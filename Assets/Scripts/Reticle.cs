using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticle : MonoBehaviour
{
    [SerializeField] private float _defaultDistance = 5.0f;
    [SerializeField] private float _surfaceReticleDistance = 0.02f;
    [SerializeField] private Transform _reticleTransform;
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private Reticle _reticle;

    // Store the original scale of the reticle.
    private Vector3 _originalScale;

    // Store the original rotation of the reticle.
    private Quaternion _originalRotation;

    private void Start()
    {
        // Store the original scale and rotation.
        _originalScale = _reticleTransform.localScale;
        _originalRotation = _reticleTransform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
    }

    // Set position of the reticle if no hit was detected. Places
    // it at default distance from the camera, based on original rotation.
    public void SetPosition()
    {
        // Set the position of the reticle to the default distance in front of the camera
        _reticleTransform.position = _cameraTransform.position
                                     + _cameraTransform.forward * _defaultDistance;
        // Set the scale based on the original and the distance from the camera
        _reticleTransform.localScale = _originalScale * _defaultDistance;
        // The rotation should just be the default
        _reticleTransform.localRotation = _originalRotation;
    }


    // A hit was detected by the raycast. Position the reticle at the
    // hit point, orient it to the surface normal and scale it according
    // to the hit distance. Add a small offset to the surface to prevent clipping.
    public void SetPosition(RaycastHit hit)
    {
        if (!_reticleTransform) return;
        
        // Set the position to the hit point plus a small offset to avoid clipping
        _reticleTransform.position = hit.point
                                     + hit.normal * _surfaceReticleDistance;
        // Scale based on the distance of the hit from the camera (= raycast origin)
        _reticleTransform.localScale = _originalScale * hit.distance;
        // Set the rotation based on its forward vector facing along the hit normal
        _reticleTransform.rotation = Quaternion.FromToRotation(Vector3.forward,
            hit.normal);
    }
}