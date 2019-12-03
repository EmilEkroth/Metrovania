using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackHandeler : ScriptableObject
{
    protected Character character;

    public void SetCharacter (Character character) { this.character = character; }

    public abstract void Attack();
}
