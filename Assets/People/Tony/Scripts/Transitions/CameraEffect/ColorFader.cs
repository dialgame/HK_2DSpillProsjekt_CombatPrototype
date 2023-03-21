using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorFader : MonoBehaviour
{
    private Color fromColor = new Color(1f, 1f, 1f);//white/default
    private Color toColor = new Color(0f, 0f, 0f); //black
    private Material material;

    private bool reset = false;
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Reset()
    {
        reset = true;
        material.color = fromColor;
    }

    public void StartColorFading()
    {
        reset = false;
        StartCoroutine(ColorFadingCoroutine());
    }

    private IEnumerator ColorFadingCoroutine()
    {
        float t = 0f;

        while (t < 1f)
        {
            if (reset)
            {
                t = 1f; //go out of loop
            }
            else
            {
                material.color = Color.Lerp(fromColor, toColor, t);
                t += Time.deltaTime; //change this value to change the speed of fading.
                yield return null;

            }
        }

        if (!reset)
        {
            material.color = toColor;

        }

    }
}
