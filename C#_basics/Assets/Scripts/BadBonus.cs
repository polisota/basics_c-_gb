﻿using System;
using UnityEngine;
using Random = UnityEngine.Random;


public class BadBonus : InteractiveObject, IFlay, IRotation, ICloneable
{
    private float _lengthFlay;
    private float _speedRotation;
    public event DeathBonusDelegate StartDying;
    public GameObject cam;

    private void Awake()
    {
        _lengthFlay = Random.Range(1.0f, 9.0f);
        _speedRotation = Random.Range(10.0f, 50.0f);
    }


    protected override void Interaction(GameObject interacted)
    {
        StartDying?.Invoke(new DeathBonusEventArgs(cam));
        FindObjectOfType<GameController>().EndGame();
    }

    public void Flay()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, Mathf.PingPong(Time.time, _lengthFlay), transform.localPosition.z);
    }

    public void Rotation()
    {
        transform.Rotate(Vector3.up * (Time.deltaTime * _speedRotation), Space.World);
    }
    
    public object Clone()
    {
        var result = Instantiate(gameObject, transform.position, transform.rotation, transform.parent);
        return result;
    }
}
