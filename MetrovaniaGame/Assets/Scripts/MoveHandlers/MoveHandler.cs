using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoveHandler : ScriptableObject
{
    protected Transform transform;
    protected Rigidbody2D rBody;

    public void SetTransform(Transform transform) { this.transform = transform; }
    public void SetRigidbody(Rigidbody2D rBody) { this.rBody = rBody; }

    public abstract void Move(Vector2 direction);
    public abstract void Jump();

    public abstract void FixedUpdate();
}