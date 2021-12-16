using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManagement : MonoBehaviour
{
    [SerializeField] private int _playerHealth;
    
    public GameObject Cube;

    public int PlayerHealth
    {
        get => _playerHealth;
        set
        {
            if (value >= 0 && value <= 100)
            {
                _playerHealth = value;
            }
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(HelloWorld());
        Instantiate(Cube);
        PlayerHealth = -20;
        var x = PlayerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator HelloWorld()
    {
        Debug.Log("In Hello World");
        yield return new WaitForSeconds(2.0F);
        Debug.Log("Still here!");
        yield break;
    }
}
