using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public sealed class GameController : MonoBehaviour, IDisposable
{
    private InteractiveObject[] _interactiveObjects;
    bool gameHasEnded = false;
    public float restartDelay = 1f;
    public GameObject menu;

    private void Awake()
    {
        _interactiveObjects = FindObjectsOfType<InteractiveObject>();

        foreach (var interactiveObject in _interactiveObjects)
        {
            if (interactiveObject is BadBonus badBonus)
            {
                Debug.Log("1");
                badBonus.StartDying += BadBonusOnStartDying;
            }
        }
    }

    private void Update()
    {
        for (var i = 0; i < _interactiveObjects.Length; i++)
        {
            var interactiveObject = _interactiveObjects[i];

            if (interactiveObject == null)
            {
                continue;
            }

            if (interactiveObject is IFlay flay)
            {
                flay.Flay();
            }

            if (interactiveObject is IRotation rotation)
            {
                rotation.Rotation();
            }
        }
    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            Debug.Log("4");
            gameHasEnded = true;
            Invoke("Restart", restartDelay);
        }
    }

    public void OpenMenu()
    {
        menu.SetActive(true);
    }

    public void CloseMenu()
    {
        menu.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void Restart()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void BadBonusOnStartDying(DeathBonusEventArgs deathbonuseventargs)
    {        
        Debug.Log("Cam shake");
        GetComponent<CameraController>().enabled = false;
        GetComponent<Animator>().enabled = true;

        StartCoroutine(Shake());

        GetComponent<CameraController>().enabled = true;
        GetComponent<Animator>().enabled = false;

        EndGame();
    }      


    private IEnumerator Shake()
    {
        yield return new WaitForSeconds(1);

    }

    public void Dispose()
    {
        foreach (var o in _interactiveObjects)
        {
            Destroy(o.gameObject);
        }
    }
}