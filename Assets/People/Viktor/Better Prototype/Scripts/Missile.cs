using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public AudioSource explosionSource;
    public AudioClip explosion;
    public float explosionVolume;
    private SpriteRenderer sr;
    public GameObject explosionObject;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            StartCoroutine(Camera.main.GetComponent<Shake>().Shaking());
            sr.enabled = false;
            explosionSource.PlayOneShot(explosion, explosionVolume);
            Instantiate(explosionObject, transform.position, transform.rotation);
            Invoke("DestroyAfter", 0.5f);
        }

        
    }

    private void DestroyAfter()
    {
        Destroy(gameObject);

    }

    
}
