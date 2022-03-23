using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Debug;

public sealed class VictoryController : MonoBehaviour
{
    [SerializeField] private List<InteractiveObject> VictoryBonus;
    public GameObject final;

    private void Update()
    {
        int count = 0;
        foreach (var victoryBonus in VictoryBonus)
        {
            if (victoryBonus == null)
            {
                count++;
            }
        }

        if (count == VictoryBonus.Count || VictoryBonus.Count == 0)
        {
            LogError("Go to the final point!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        LogError("Victory!");       

    }
}