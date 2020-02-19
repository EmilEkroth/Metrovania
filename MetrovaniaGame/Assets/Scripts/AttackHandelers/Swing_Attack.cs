using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Swing_Attack", menuName = "ScriptableObjects/AttackHandelers/Swing_Attack", order = 1)]
public class Swing_Attack : AttackHandeler
{
    [SerializeField] int damage = 10;
    [SerializeField] float attackDistance = 1f;
    
    public override void Attack ()
    {
        Debug.Log(character.name + " attacked!");
        Vector2 dir = character.GetMoveHandler().GetDirection();
        dir *= attackDistance;
        Debug.DrawLine(character.transform.position, new Vector2(dir.x + character.transform.position.x, dir.y + character.transform.position.y), Color.red);
        Vector2 attackPoint = new Vector2(dir.x + character.transform.position.x, dir.y + character.transform.position.y);

        RaycastHit2D [] hits = Physics2D.CircleCastAll(attackPoint, attackDistance / 2, attackPoint);

        foreach (RaycastHit2D hit in hits)
        {

            if(!(hit.collider.name.Equals(character.name, System.StringComparison.CurrentCulture)) && hit.collider.CompareTag ("Character"))
            {
                Debug.Log(hit.collider.name + " : " + character.name);
                hit.collider.GetComponent<Character>().GetHealthHandler().Damage(damage);
            }
        }
    }
}
