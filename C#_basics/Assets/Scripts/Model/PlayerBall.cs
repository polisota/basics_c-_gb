using UnityEngine;

public sealed class PlayerBall : Player
{
    private void FixedUpdate()
    {
        Move();
    }
}