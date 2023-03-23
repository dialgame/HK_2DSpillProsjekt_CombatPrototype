using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatteredScreenTestManager : MonoBehaviour
{
    public GameObject sceneCamera;
    public GameObject sceneCameraCaptureCamera;
    public GameObject shatteredScreenCamera;
    public ShatteredScreen shatteredScreen;

    [SerializeField] GameManager gameManager;
    public ColorFader backgroundColorFader;

    //T_PlayerStats playerStats;
    //T_PlayerMovement playerMovement;
   // T_EnemyStats enemyStats;
    

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

    public void ShatterScreen()
    {
        StartCoroutine(ShatterScreenCoroutine());
    }

    public void ResetScreen()
    {
        sceneCamera.SetActive(true);
        shatteredScreen.Reset();

        sceneCameraCaptureCamera.SetActive(false);
        shatteredScreenCamera.SetActive(false);

        gameManager.currentState = GameState.Overworld;
        gameManager.EndCombat();
    }

    private IEnumerator ShatterScreenCoroutine()
    {
        sceneCameraCaptureCamera.SetActive(true);
        yield return null;

        sceneCamera.SetActive(false);
        sceneCameraCaptureCamera.SetActive(false);//got the render texture when it was True for 1 frame.
        shatteredScreenCamera.SetActive(true);

        shatteredScreen.Shatter();

        gameManager.currentState = GameState.Combat;
        gameManager.StartCombat();

        //yield return new WaitForSeconds(0.5f);

        sceneCameraCaptureCamera.SetActive(false);
        yield return null;
        sceneCamera.SetActive(true);
        //yield return null;

        yield return new WaitForSeconds(1.5f);
        shatteredScreenCamera.SetActive(false);
        backgroundColorFader.ReverseColorFading();

    }
}
