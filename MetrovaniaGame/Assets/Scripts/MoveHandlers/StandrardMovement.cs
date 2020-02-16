using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StandardMovement", menuName = "ScriptableObjects/MoveHandelers/StandardMovement", order = 1)]
public class StandrardMovement : MoveHandler
{
    [SerializeField] private float moveSpeed = 0.2f;
    [SerializeField] private float jumpStrength = 800f;
    [SerializeField] private int maxJumps = 1;
    [SerializeField] private float groundDetectionDistance = .5f;

    private Vector2 direction = new Vector2(0, 0);
   
    private int jumps = 1000;
    private float actualMoveSpeed = 0;

    public override void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x + direction.x * actualMoveSpeed, transform.position.y);

        if (rBody.drag > 1)
        {
            if (rBody.drag > 1)
            {
                rBody.drag--;
                if (rBody.drag < 2)
                    actualMoveSpeed = moveSpeed;
            }
        }

        if (rBody.velocity.y < -1000f)
        {
            rBody.velocity = new Vector2(rBody.velocity.x, -1000f);
        }
        if(rBody.velocity.y < 0f)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundDetectionDistance);
            if(hit.collider != null)
            {
                jumps = 1; rBody.drag = 5;
                actualMoveSpeed = moveSpeed/2;
            }
        }
    }

    public override  void Move(Vector2 dir)
    {
        direction = dir;            
    }

    public override void Jump()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundDetectionDistance);
        if (hit.collider != null)
        {
            rBody.AddForce(Vector2.up * jumpStrength);
        }
        else if (jumps < maxJumps && rBody.velocity.y < 200)
        {
            rBody.AddForce(Vector2.up * jumpStrength);
            jumps++;
        }
    }
}
