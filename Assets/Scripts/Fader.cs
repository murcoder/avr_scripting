using System.Collections;
using UnityEngine;

public class Fader : MonoBehaviour
{
    public GameObject Cube;
    public float fadeDuration = 1.0F;
    
    void Awake()
    {
        StartCoroutine(FadeIn());
    }
    
    //Fade In Coroutine
    private IEnumerator FadeIn()
    {
        Renderer cubeRenderer = Cube.transform.GetComponent<Renderer>();
        Color initialColor = cubeRenderer.material.color;
        initialColor.a = 0f;
        
        // Assign random color
        Color targetColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            Color currentColor = Color.Lerp(initialColor, targetColor, elapsedTime / fadeDuration);
            cubeRenderer.material.color = currentColor;
            yield return null;
        }
    }
}