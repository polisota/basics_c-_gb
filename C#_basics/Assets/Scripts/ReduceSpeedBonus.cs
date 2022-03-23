using System;
using UnityEngine;


public sealed class ReduceSpeedBonus : BadBonus, IDisposable
{
    protected override void Interaction(GameObject interacted)
    {
        IsInteractable = false;
        var player = interacted.GetComponent<Player>();
        player.Speed = Mathf.Min(player.Speed, 1);
        Dispose();
    }

    public void Dispose()
    {
        Destroy(gameObject);
    }
}