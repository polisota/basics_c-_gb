using System;
using UnityEngine;
using System.Collections;

public class DeathBonusEventArgs : MonoBehaviour
{
    public DeathBonusEventArgs(GameObject cam)
    {
        //cam = GameObject.FindGameObjectWithTag("MainCamera");
    }
   
    public GameObject cam;
  
    public void Do(GameObject cam)
    {
        Debug.Log("Cam shake");
        GetComponent<CameraController>().enabled = false;
        GetComponent<Animator>().enabled = true;

        StartCoroutine(Shake());

        GetComponent<CameraController>().enabled = true;
        GetComponent<Animator>().enabled = false;
    }
    //cam = GameObject.FindGameObjectWithTag("MainCamera");      
    

    private IEnumerator Shake()
    {
        yield return new WaitForSeconds(1);
    }
}

public delegate void DeathBonusDelegate(DeathBonusEventArgs deathBonusEventArgs);
