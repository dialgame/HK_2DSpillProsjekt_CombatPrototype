using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthSpell : MonoBehaviour
{
    private CircleCollider2D aoeHitbox;

    Color brown;
    private SpriteRenderer sr;


    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        aoeHitbox = GetComponent<CircleCollider2D>();

        aoeHitbox.enabled = false;
    }

    void Start()
    {
        viktorAudioManager.instance.audioSource.PlayOneShot(viktorAudioManager.instance.thunderStrike);
        brown = new Color(168f / 255f, 85f / 255f, 2f / 255f, 1f);
        Invoke("EarthRaise", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void EarthRaise()
    {
        aoeHitbox.enabled = true;     
        StartCoroutine(Camera.main.GetComponent<Shake>().Shaking());
        sr.color = brown;
        Debug.Log("The wrath of Thor is on your hands!");
        //viktorAudioManager.instance.audioSource.PlayOneShot(viktorAudioManager.instance.thunderStrike);
        Invoke("RemoveEarthRaise", 10f);
    }

    private void RemoveEarthRaise()
    {
        Destroy(gameObject);
    }

}
