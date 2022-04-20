using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Debug;

public sealed class VictoryController : MonoBehaviour
{
    [SerializeField] private List<InteractiveObject> VictoryBonus;
    public GameObject final;    
    public bool flag = false;
    public GameObject winUI;
    public Text myText;

    private void Update()
    {
        int count = 0;
        myText.text = $"Score: {count}/4";

        foreach (var victoryBonus in VictoryBonus)
        {
            if (victoryBonus == null)
            {
                count++;
                myText.text = $"Score: {count}/4";
            }
        }

        if (count == VictoryBonus.Count || VictoryBonus.Count == 0)
        {
            myText.text = "Go to the final point!";

            if (flag == true)
            {
                LogError("Victory!");
                winUI.SetActive(true);
            }           
        }
    }    

    private void OnTriggerEnter(Collider other)
    {  
        if (other.gameObject.CompareTag("Player"))
        {
            flag = true;
        }
    }


}