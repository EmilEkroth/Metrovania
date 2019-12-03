using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Dictionary<Collider2D, Character> characters = new Dictionary<Collider2D, Character>();

    public void AddCharacter (Collider2D collider, Character ch)
    {
        if (ObjectExists(collider))
            Debug.Log("Object " + collider.name + " is already added!!!");
        else characters.Add(collider, ch);
    }

    public Character GetCharacter(Collider2D collider)
    {
        Character ret;
        if(characters.TryGetValue(collider, out ret))
        {
            return ret;
        }
        Debug.Log("Character " + collider.name + " not found");
        return null;
    }

    public bool ObjectExists(Collider2D collider)
    {
        return characters.ContainsKey(collider);
    }
}
