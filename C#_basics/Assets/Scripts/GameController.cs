using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public sealed class GameController : MonoBehaviour, IDisposable
{
    private LevelState state;
    private string datapath;

    private InteractiveObject[] _interactiveObjects;
    bool gameHasEnded = false;
    public float restartDelay = 1f;
    public GameObject menu;

    void Start()
    {
        datapath = Application.dataPath + "/Scripts/SavedData"  + "data.xml";

        if (File.Exists(datapath))
        {
            state = Serializator.DeXml(datapath);
        }
        else
        {
            //setDefault();
        }        

        //Generate();
    }

    private void Awake()
    {
        _interactiveObjects = FindObjectsOfType<InteractiveObject>();

        foreach (var interactiveObject in _interactiveObjects)
        {
            if (interactiveObject is BadBonus badBonus)
            {                
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

    void setDefault()
    {
        state = new LevelState();        
        state.AddItem(new BonusData("GBonus", new Vector3(-11f, 1f, -18f)));
        state.AddItem(new BonusData("GBonus", new Vector3(-5f, 1f, 14f)));
        state.AddItem(new BonusData("GBonus", new Vector3(13f, 1f, -8f)));
        state.AddItem(new BonusData("GBonus", new Vector3(15f, 1f, -22f)));

    }

    void Generate()
    {
        foreach (BonusData felt in state.bonus)
        {  
            felt.inst = Instantiate(Resources.Load(felt.Name), felt.position, Quaternion.identity) as GameObject;
           
            felt.Estate();
        }
    }

    void Dump()
    {
        state.Update();
        Serializator.SaveXml(state, datapath);
    }

}