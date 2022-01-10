using System;
using UnityEngine;

public class GazeTarget : MonoBehaviour
{
    public GameObject gazeTarget;
    
    // Called when gaze moves over the GameObject
    // Defined as EventHandler with one parameter - the impact point
    public event EventHandler<Vector3> GazeEntered;

    // Called when gaze leaves the GameObject
    // Defined as custom delegate
    public delegate void GazeOutEventHandler();

    public event GazeOutEventHandler GazeOut;

    public void OnGazeEntered(Vector3 impactPoint)
    {
        GazeEntered?.Invoke(gazeTarget, impactPoint);
    }

    public void OnGazeOut()
    {
        GazeOut?.Invoke();
    }
}