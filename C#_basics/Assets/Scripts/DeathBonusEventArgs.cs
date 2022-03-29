using System;
using UnityEngine;
using System.Collections;

public class DeathBonusEventArgs : EventArgs
{
    public DeathBonusEventArgs(Camera cam)
    {
        
    }
}

public delegate void DeathBonusDelegate(DeathBonusEventArgs deathBonusEventArgs);
