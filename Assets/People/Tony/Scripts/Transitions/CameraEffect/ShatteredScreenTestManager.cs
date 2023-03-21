using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatteredScreenTestManager : MonoBehaviour
{
    public GameObject sceneCamera;
    public GameObject sceneCameraCaptureCamera;
    public GameObject shatteredScreenCamera;
    public ShatteredScreen shatteredScreen;

    private void Awake()
    {
        sceneCamera.SetActive(true);
        sceneCameraCaptureCamera.SetActive(false);
        shatteredScreenCamera.SetActive(false);

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ShatterScreen();

        }
        else if (Input.GetKeyUp(KeyCode.R))
        {
            ResetScreen();
        }
    }

    private void ShatterScreen()
    {
        StartCoroutine(ShatterScreenCoroutine());
    }

    private void ResetScreen()
    {
        sceneCamera.SetActive(true);
        shatteredScreen.Reset();

        sceneCameraCaptureCamera.SetActive(false);
        shatteredScreenCamera.SetActive(false);
    }

    private IEnumerator ShatterScreenCoroutine()
    {
        sceneCameraCaptureCamera.SetActive(true);
        yield return null;

        sceneCamera.SetActive(false);
        sceneCameraCaptureCamera.SetActive(false);//got the render texture when it was True for 1 frame.
        shatteredScreenCamera.SetActive(true);

        shatteredScreen.Shatter();
    }
}
