using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface MoveHandler
{
    void Move(Movement move);
}

public enum Movement
{
    Right, Left, Jump
}
