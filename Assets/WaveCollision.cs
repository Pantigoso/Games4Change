using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveCollision : MonoBehaviour
{

    float firstWaveDelay = .06f;
    float secondWaveDelay = .07f;
    float thirdWaveDelay = .08f;
    float fourthWaveDelay = .09f;
    float fifthWaveDelay = .09f;

    public GameObject firstWave;
    public GameObject secondWave;
    public GameObject thirdWave;
    public GameObject fourthWave;
    

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered");

        if(other.gameObject.tag == "Wave")
        {
            StartCoroutine(ActivateFirstWave());
        }
    }

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
}
