using UnityEngine;

public sealed class VictoryBonus : GoodBonus //InteractiveObject
{
    protected override void Interaction(GameObject interacted)
    {
        Destroy(gameObject);
    }
}