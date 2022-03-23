using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class GoodBonus : InteractiveObject, IFlay, IEquatable<GoodBonus>
{
    public int Point;    
    private float _lengthFlay;
    private DisplayBonuses _displayBonuses;

    protected virtual void Awake()
    {        
        _lengthFlay = Random.Range(1.0f, 5.0f);
        _displayBonuses = new DisplayBonuses();
    }

    protected override void Interaction(GameObject interacted)
    {
        _displayBonuses.Display(5);
        // Add bonus
    }

    public void Flay()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, Mathf.PingPong(Time.time, _lengthFlay), transform.localPosition.z);
    }


    public bool Equals(GoodBonus other)
    {
        return Point == other.Point;
    }
}
