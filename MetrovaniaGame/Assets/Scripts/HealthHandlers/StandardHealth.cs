using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StandardHealth", menuName = "ScriptableObjects/HealthHandelers/StandardHealth", order = 1)]
public class StandardHealth : HealthHandler
{
   [SerializeField] private int health;

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

    public override int GetHealth() { return health; }
    public override void Damage (int damage) {
        health -= damage;
        if (health < 0) death.die();
    }

    public override void Heal (int healing) {
        health += healing;
        if (health > maxHealth) health = maxHealth;
    }
}
