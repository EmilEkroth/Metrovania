using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardHealth : MonoBehaviour, HealthHandler
{
    private int health;
    private int maxHealth;
    DeathHandler death;

    StandardHealth(int health, DeathHandler death)
    {
        this.health = health;
        this.maxHealth = health;
        this.death = death;
    }


    void Start()
    {
        maxHealth = health;
    }

    public int GetHealth() { return health; }
    public void Damage (int damage) {
        health -= damage;
        if (health < 0) death.die();
    }

    public void Heal (int healing) {
        health += healing;
        if (health > maxHealth) health = maxHealth;
    }
}
