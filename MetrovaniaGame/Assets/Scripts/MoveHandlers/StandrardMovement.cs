using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandrardMovement : MonoBehaviour, MoveHandler
{
    public void Move(Movement movement)
    {
        switch (movement)
        {
            case Movement.Right:
                Walk(1);
                return;
            case Movement.Left:
                Walk(-1);
                return;
            case Movement.Jump:
                Jump();
                return;
        }
    }

    private void Walk(int dir)
    {
        
    }

    private void Jump()
    {

    }
}
