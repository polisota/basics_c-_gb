﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class GameController : MonoBehaviour, IDisposable
{
    private InteractiveObject[] _interactiveObjects;
    bool gameHasEnded = false;
    public float restartDelay = 1f;

    private void Awake()
    {
        try
        {
            _interactiveObjects = FindObjectsOfType<InteractiveObject>();
        }
        catch (NullReferenceException ex)
        {
            Debug.Log(ex + "No interactive objects were found.");
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
            gameHasEnded = true;
            Invoke("Restart", restartDelay);
        }
    }

    void Restart()
    {
        try
        {
            if (SceneManager.GetActiveScene().name != "MainScene")
            {
                throw new NullReferenceException("Wrong scene name.");
            }
            SceneManager.LoadScene("MainScene");
        }
        catch (NullReferenceException ex)
        {
            Debug.Log(ex + "Check scene name.");
        }

        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Dispose()
    {
        foreach (var o in _interactiveObjects)
        {
            Destroy(o.gameObject);
        }
    }
}