using UnityEngine;

public sealed class VictoryBonus : InteractiveObject
{
    protected override void Interaction(GameObject interacted)
    {
        Destroy(gameObject);
    }
}