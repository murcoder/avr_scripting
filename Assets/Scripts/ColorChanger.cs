using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private GameObject obj;
    public GazeTarget gazeTargetComponent;
    public Material NormalMaterial;
    public Material OverMaterial;

    private void OnEnable()
    {
        // Subscribe to events
        gazeTargetComponent.GazeEntered += OnGazeEntered;
        gazeTargetComponent.GazeOut += OnGazeOut;
    }

    private void OnDisable()
    {
        // Unsubscribe
        gazeTargetComponent.GazeEntered -= OnGazeEntered;
        gazeTargetComponent.GazeOut -= OnGazeOut;
    }

    private void OnGazeEntered(object sender, Vector3 impactPoint)
    {
        obj = (GameObject) sender;
        MeshRenderer meshRenderer = obj.GetComponent<MeshRenderer>();

        if (meshRenderer)
        {
            Debug.Log("meshRenderer");
            meshRenderer.material = OverMaterial;
        }
    }

    private void OnGazeOut()
    {
        if (obj)
        {
            MeshRenderer meshRenderer = obj.GetComponent<MeshRenderer>();
            meshRenderer.material = NormalMaterial;
        }
        Debug.Log("Gaze out ");
        // TODO: Change material to "normal" material
    }
}