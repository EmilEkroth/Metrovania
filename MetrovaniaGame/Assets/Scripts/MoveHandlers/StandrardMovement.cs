using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandrardMovement : MoveHandler
{
    [SerializeField] private Rigidbody2D rBody; 
    [SerializeField] private Transform transform;
    [SerializeField] private float moveSpeed = 0.2f;
    [SerializeField] private float jumpStrength = 800f;
    [SerializeField] private int maxJumps = 1;
    [SerializeField] private float groundDetectionDistance = 1f;

    private Vector2 direction = new Vector2(0, 0);
   
    private int jumps = 1000;

    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x + direction.x * moveSpeed, transform.position.y);


        if (rBody.velocity.y < -1000f)
        {
            rBody.velocity = new Vector2(rBody.velocity.x, -1000f);
        }
        if(rBody.velocity.y < 0f)
        {
            Debug.Log(rBody.velocity);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, .5f);
            Debug.Log(hit.collider);
            if(hit.collider != null)
            {
                jumps = 1;
            }
        }
    }

    public override  void Move(Vector2 dir)
    {
        direction = dir;
    }

    public override void Jump()
    {
        Debug.Log("jumps " + jumps);

        Debug.Log(rBody.velocity);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, .5f);
        Debug.Log(hit.collider);
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
