using UnityEngine;

public sealed class EndBonus : BadBonus
{
    protected override void Interaction(GameObject interacted)
    {
        Debug.Log("3");
        FindObjectOfType<GameController>().EndGame();
        Destroy(gameObject);
        Debug.Log("You're dead(");
    }
}