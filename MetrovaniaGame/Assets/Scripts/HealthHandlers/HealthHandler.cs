using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HealthHandler : MonoBehaviour
{
    public abstract int GetHealth();
    public abstract void Damage(int damage);
    public abstract void Heal(int healing);
}
