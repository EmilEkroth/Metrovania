using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HealthHandler
{
    int GetHealth();
    void Damage(int damage);
    void Heal(int healing);
}
