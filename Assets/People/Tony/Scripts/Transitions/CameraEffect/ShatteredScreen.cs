using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatteredScreen : MonoBehaviour
{
    public GameObject[] screenPieces;

    private bool reset = false;

    //Force
    public GameObject explosionObject;
    [SerializeField] float explosionForce = 10f;
    [SerializeField] float explosionRadius = 5f;
    [SerializeField] Vector3 explosionPosition;

    //Rotation
    [SerializeField] float minTorque = 100f;
    [SerializeField] float maxTorque = 500f;
    private Vector3[] piecesStartPosition;
    private Quaternion[] piecesStartRotation;

    //BG fading effect
    public ColorFader backgroundColorFader;

    //GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        explosionPosition = explosionObject.transform.position;

        piecesStartPosition = new Vector3[screenPieces.Length];
        piecesStartRotation = new Quaternion[screenPieces.Length];

        for (int i = 0; i < screenPieces.Length; i++)
        {
            piecesStartPosition[i] = screenPieces[i].transform.position;
            piecesStartRotation[i] = screenPieces[i].transform.rotation;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Shatter()
    {
        reset = false;
        //StartCoroutine(ShatterCoroutine());
        StartCoroutine(ShatterWithExplosionForceCoroutine());
    }


    public void Reset()
    {
        reset = true; //fail safe variable.
        for (int i = 0; i < screenPieces.Length; i++)
        {
            Rigidbody rb = screenPieces[i].GetComponent<Rigidbody>();
            rb.Sleep();
            screenPieces[i].transform.position = piecesStartPosition[i];
            screenPieces[i].transform.rotation = piecesStartRotation[i];
            rb.useGravity = false;
            // Physics.gravity = new Vector3(0, 0, 0);
            //screenPieces[i].SetActive(true);


        }

        backgroundColorFader.Reset();
    }
    private IEnumerator ShatterWithExplosionForceCoroutine()
    {
        //small crack before it burst out
        for (int i = 0; i < screenPieces.Length; i++)
        {
            screenPieces[i].transform.Rotate(new Vector3(Random.Range(-50f, 50f), Random.Range(-50f, 50f), Random.Range(-50f, 50f)));
        }

        yield return new WaitForSeconds(0.5f);
        //yield return null; //means wait 1 frame.

        if (!reset)
        {
            for (int i = 0; i < screenPieces.Length; i++)
            {
                float torqueX = Random.Range(minTorque, maxTorque);
                float torqueY = Random.Range(minTorque, maxTorque);
                float torqueZ = Random.Range(minTorque, maxTorque);

                Rigidbody rb = screenPieces[i].GetComponent<Rigidbody>();
                rb.AddExplosionForce(explosionForce, explosionPosition, explosionRadius);
                rb.AddExplosionForce(explosionForce / 2f, explosionPosition, explosionRadius * 2f);
                rb.AddForce(new Vector3(Random.Range(-2f, 2f), Random.Range(0f, 2f), 0f));

                rb.AddTorque(new Vector3(torqueX, torqueY, torqueZ));

                rb.useGravity = true;
                //Physics.gravity = new Vector3(0, -100, 0);
            }
            backgroundColorFader.StartColorFading();

        }


        yield return null;

    }

    //private IEnumerator ShatterCoroutine()
    //{
    //    for (int i = 0; i < screenPieces.Length; i++)
    //    {
    //        if (reset) //if reset is True
    //        {
    //            i = screenPieces.Length;
    //        }
    //        else
    //        {
    //            screenPieces[i].SetActive(false);

    //            yield return new WaitForSeconds(0.0005f); //creates delay after each piece.

    //        }

    //    }
    //}

}

