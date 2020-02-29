using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoveHandler : MonoBehaviour
{
    public abstract void Move(Vector2 direction);
    public abstract void Jump();

    public abstract Vector2 GetDirection();
}