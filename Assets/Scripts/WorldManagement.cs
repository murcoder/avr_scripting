using System.Collections;
using UnityEngine;

public class WorldManagement : MonoBehaviour
{
    [SerializeField] private int _cubes = 8;
    [SerializeField] private float _distance = 1.5F;
    public GameObject Cube;

    void Start()
    {
        StartCoroutine(createCubes());
    }

    private IEnumerator createCubes()
    {
        GameObject lastCube = Cube;
        for (int x = 0; x < _cubes; ++x)
        {
            yield return new WaitForSeconds(lastCube.GetComponent<Fader>().fadeDuration + 0.5f);
            GameObject newCube = Instantiate(lastCube, new Vector3(lastCube.transform.position.x + _distance, 0, 0),
                Quaternion.identity);
            Debug.Log("Created");
            lastCube = newCube;
        }

        yield return null;
    }
}