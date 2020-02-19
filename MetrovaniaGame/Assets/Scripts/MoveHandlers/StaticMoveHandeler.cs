using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticMoveHandeler : MoveHandler
{
    public override void FixedUpdate()
    {
    }

    public override Vector2 GetDirection()
    {
        return Vector2.zero; 
    }

    public override void Jump()
    {
    }

    public override void Move(Vector2 direction)
    {
    }
}
