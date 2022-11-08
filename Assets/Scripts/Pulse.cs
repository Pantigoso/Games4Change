using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]

public class Pulse : MonoBehaviour
{
    #region Camera Variables
    public enum CameraDirection { x, z };
    public CameraDirection cameraDirection = CameraDirection.x;
    public float cameraHeight = 20f;
    public float cameraDistance = 7f;
    public Camera playerCamera;
    public GameObject reticlePrefab;
    #endregion]

    #region Movement Variable
    public float speed = 5.0f;
    public float gravity = 14.0f;
    public float maxVelocityChange = 10.0f;
    #endregion

    //local variables
    Rigidbody rb;
    GameObject reticleObject;

    //Cursor- Camera offset variables
    Vector2 playerPosOnScreen;
    Vector2 cursorPostiion;
    Vector2 offsetVector;

    //Plane that represents imaginary floor that will be used to calculate Reticle position
    Plane surfacePlane = new Plane();


    #region Wave Objects
    public GameObject firstWave;
    public GameObject secondWave;
    public GameObject thirdWave;
    public GameObject fourthWave;
    public GameObject fiftthWave;
    #endregion

    #region Wave Delays
    [Range(.01f, .1f)]
    public float firstWaveDelay = .1f;
    [Range(.01f, .1f)]
    public float secondWaveDelay = .2f;
    [Range(.01f, .1f)]
    public float thirdWaveDelay = .3f;
    [Range(.01f, .1f)]
    public float fourthWaveDelay = .4f;
    [Range(.01f, .1f)]
    public float fifthWaveDelay = .5f;
    #endregion

    void Awake()
    {
        firstWave.SetActive(false);
        secondWave.SetActive(false);
        thirdWave.SetActive(false);
        fourthWave.SetActive(false);

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.useGravity = false;

        //if there is a Reticle Prefab
        //Make one int he scene
        //if (reticlePrefab)
        //{
        //    reticleObject = Instantiate(reticlePrefab, Vector3.zero, Quaternion.identity) as GameObject;
        //}

        //Cursor.visible = false;
    }
    //private void FixedUpdate()
    //{
    //    //set camera offset
    //    Vector3 cameraOffset = Vector3.zero;

    //    if (cameraDirection == CameraDirection.x)
    //    {
    //        cameraOffset = new Vector3(cameraDistance, cameraHeight, 0);
    //    }
    //    else if (cameraDirection == CameraDirection.z)
    //    {
    //        cameraOffset = new Vector3(0, cameraHeight, cameraDistance);
    //    }

    //    Vector3 targetVelocity = Vector3.zero;

    //    if (cameraDirection == CameraDirection.x)
    //    {
    //        targetVelocity = new Vector3(Input.GetAxis("Vertical") * (cameraDistance >= 0 ? -1 : 1), 0, Input.GetAxis("Horizontal") * (cameraDistance >= 0 ? 1 : -1));
    //    }
    //    else if (cameraDirection == CameraDirection.x)
    //    {
    //        targetVelocity = new Vector3(Input.GetAxis("Horizontal") * (cameraDistance >= 0 ? -1 : 1), 0, Input.GetAxis("Vertical") * (cameraDistance >= 0 ? 1 : -1));
    //    }
    //    targetVelocity *= speed;

    //    //Apply a fore that attempts to reach our target velocity
    //    Vector3 velocity = rb.velocity;
    //    Vector3 velocityChange = (targetVelocity - velocity);
    //    velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
    //    velocityChange.z = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
    //    velocityChange.y = 0;
    //    rb.AddForce(velocityChange, ForceMode.VelocityChange);

    //    //mouse cursor offset effect
    //    playerPosOnScreen = playerCamera.WorldToViewportPoint(transform.position);
    //    cursorPostiion = playerCamera.ScreenToViewportPoint(Input.mousePosition);
    //    offsetVector = cursorPostiion - playerPosOnScreen;

    //    //camera follow
    //    playerCamera.transform.position = Vector3.Lerp(playerCamera.transform.position, transform.position + cameraOffset, Time.deltaTime * 7.47f);
    //    playerCamera.transform.LookAt(transform.position + new Vector3(-offsetVector.y * 2, 0, offsetVector.x *2));

    //    //aim reticle position and rotation
    //    reticleObject.transform.position = GetReticlePos();
    //    reticleObject.transform.LookAt(new Vector3(transform.position.x, reticleObject.transform.position.y, transform.position.z));

    //    //palyer rotation
    //    transform.LookAt(new Vector3(reticleObject.transform.position.x, transform.position.y, reticleObject.transform.position.z));
    //}


    //void GetReticlePos()
    //{
    //    //update surface plane
    //    surfacePlane.SetNormalAndPosition(Vector3.up, transform.position);

    //    //create a ray from the mouse  clikc position
    //    Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);

    //    //initialize the enter variable
    //    float enter = 0.0f;

    //    if(surfacePlane.Raycast(ray, out enter))
    //    {
    //        Vector3 hitPoint = ray.GetPoint(enter);

    //        //return hitPoint;

    //    }
    //}


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            StartCoroutine(ActivateFirstWave());
        }


    }

    #region Wave Coroutines
    IEnumerator ActivateFirstWave()
    {
        yield return new WaitForSeconds(firstWaveDelay);
        firstWave.SetActive(true);
        StartCoroutine(ActivateSecondWave());
    }


    IEnumerator ActivateSecondWave()
    {

        yield return new WaitForSeconds(secondWaveDelay);
        firstWave.SetActive(false);
        secondWave.SetActive(true);
        StartCoroutine(ActivateThirdWave());
    }


    IEnumerator ActivateThirdWave()
    {
        yield return new WaitForSeconds(thirdWaveDelay);
        secondWave.SetActive(false);
        thirdWave.SetActive(true);
        StartCoroutine(ActivateFourthWave());
    }


    IEnumerator ActivateFourthWave()
    {
        yield return new WaitForSeconds(fourthWaveDelay);
        thirdWave.SetActive(false);
        fourthWave.SetActive(true);
        yield return new WaitForSeconds(fifthWaveDelay);
        fourthWave.SetActive(false);

    }
    #endregion

}
