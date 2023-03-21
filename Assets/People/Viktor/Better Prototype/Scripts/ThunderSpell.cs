using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderSpell : MonoBehaviour
{


    private CircleCollider2D aoeHitbox;
    public GameObject childLightning;

    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        aoeHitbox = sr.GetComponent<CircleCollider2D>();

        aoeHitbox.enabled = false;
        childLightning.SetActive(false);
        
    }

    void Start()
    {
        Invoke("LightningStrike", 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void LightningStrike()
    {
        aoeHitbox.enabled = true;
        childLightning.SetActive(true);
        StartCoroutine(Camera.main.GetComponent<Shake>().Shaking());
        sr.color = new Color(0, 94, 255, 0);
        Debug.Log("The wrath of Thor is on your hands!");
        viktorAudioManager.instance.audioSource.PlayOneShot(viktorAudioManager.instance.thunderStrike);
        Invoke("RemoveThunderSpell", 0.5f);
    }

    private void RemoveThunderSpell()
    {
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {


        if (other.gameObject.tag == "enemy")
        {
            Debug.Log("An enemy takes 518 damage!"); 

        }
    }
}
