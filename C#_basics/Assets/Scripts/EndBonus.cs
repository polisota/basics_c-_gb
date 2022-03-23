using UnityEngine;

public sealed class EndBonus : BadBonus
{
    protected override void Interaction(GameObject interacted)
    {
        FindObjectOfType<GameController>().EndGame();
        Destroy(gameObject);
        Debug.Log("You're dead(");
    }
}