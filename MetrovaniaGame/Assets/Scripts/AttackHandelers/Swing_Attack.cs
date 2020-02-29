using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Swing_Attack", menuName = "ScriptableObjects/AttackHandelers/Swing_Attack", order = 1)]
public class Swing_Attack : AttackHandeler
{
    [SerializeField] int damage = 10;
    [SerializeField] float attackDistance = 1f;
    [SerializeField] MoveHandler moveHandler;
    
    public override void Attack ()
    {
        Vector2 dir = moveHandler.GetDirection();
        dir *= attackDistance;
        Debug.DrawLine(moveHandler.transform.position, new Vector2(dir.x + moveHandler.transform.position.x, dir.y + moveHandler.transform.position.y), Color.red);
        Vector2 attackPoint = new Vector2(dir.x + moveHandler.transform.position.x, dir.y + moveHandler.transform.position.y);

        RaycastHit2D [] hits = Physics2D.CircleCastAll(attackPoint, attackDistance / 2, attackPoint);

        foreach (RaycastHit2D hit in hits)
        {

            if(!(hit.collider.name.Equals(moveHandler.name, System.StringComparison.CurrentCulture)) && hit.collider.CompareTag ("Character"))
            {
                Debug.Log(hit.collider.name + " : " + moveHandler.name);
                hit.collider.GetComponent<HealthHandler>().Damage(damage);
            }
        }
    }
}
