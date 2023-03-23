using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorFader : MonoBehaviour
{
    private Color fromWhiteColor = new Color(1f, 1f, 1f);//white/default
    private Color toBlackColor = new Color(0f, 0f, 0f); //black
    private Material material;

    private Color fromBlackColor = new Color(0f, 0f, 0f,1f);//white/default
    private Color toTransparentColor = new Color(0f, 0f, 0f, 0f); //black
    private bool reset = false;
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    public void Reset()
    {
        reset = true;
        material.color = fromWhiteColor;
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
                material.color = Color.Lerp(fromWhiteColor, toBlackColor, t);
                t += Time.deltaTime; //change this value to change the speed of fading.
                yield return null;

            }
        }

        if (!reset)
        {
            material.color = toBlackColor;

        }

    }

    public void ReverseColorFading()
    {
        StartCoroutine(ReverseColorFadingCoroutine());
    }

    private IEnumerator ReverseColorFadingCoroutine()
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
                material.color = Color.Lerp(fromBlackColor, toTransparentColor, t);
                t += Time.deltaTime; //change this value to change the speed of fading.
                yield return null;

            }
        }

        if (!reset)
        {
            material.color = toTransparentColor;

        }

    }
}
