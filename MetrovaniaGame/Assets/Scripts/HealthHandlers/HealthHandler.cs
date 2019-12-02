using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HealthHandler : ScriptableObject
{
    public abstract int GetHealth();
    public abstract void Damage(int damage);
    public abstract void Heal(int healing);
}
