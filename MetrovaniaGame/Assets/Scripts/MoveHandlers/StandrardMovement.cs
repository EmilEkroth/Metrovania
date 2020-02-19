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
    [SerializeField] private float playerWidth = 1f;
    [SerializeField] private float touchGroundDrag = 10;
    [SerializeField] private int toutchGroundSpeedDivider = 6;
    [SerializeField] private int maximumFallVelocity = 500;

    private Vector2 direction = new Vector2(0, 0);
   
    private int jumps = 1000;
    private float actualMoveSpeed = 0;

    public override void FixedUpdate()
    {
        if (rBody.velocity.y < -500f)
        {
            rBody.velocity = new Vector2(rBody.velocity.x, -500f);
        }

        if (rBody.drag > 1)
        {
            if (rBody.drag > 1)
            {
                rBody.drag--;
                if (rBody.drag < 2)
                {
                    jumps = 1;
                    actualMoveSpeed = moveSpeed;
                }
            }
        }

        transform.position = Vector3.Slerp(transform.position, new Vector3(transform.position.x + direction.x * actualMoveSpeed, transform.position.y, transform.position.z), 1f);

        if (rBody.velocity.y < 0f)
        {
            RaycastHit2D hitL = Physics2D.Raycast(new Vector3(transform.position.x - playerWidth/5, transform.position.y, transform.position.z), Vector2.down, groundDetectionDistance);
            RaycastHit2D hitR = Physics2D.Raycast(new Vector3(transform.position.x + playerWidth / 5, transform.position.y, transform.position.z), Vector2.down, groundDetectionDistance);

            Debug.DrawLine(new Vector3(transform.position.x - playerWidth / 5, transform.position.y), new Vector3(transform.position.x - playerWidth / 5, transform.position.y - groundDetectionDistance), Color.red);
            Debug.DrawLine(new Vector3(transform.position.x + playerWidth / 5, transform.position.y), new Vector3(transform.position.x + playerWidth / 5, transform.position.y - groundDetectionDistance), Color.red);
            if (hitL.collider != null || hitR.collider != null)
            {
                rBody.drag = touchGroundDrag;
                actualMoveSpeed = moveSpeed/toutchGroundSpeedDivider;
            }
        }
    }

    public override  void Move(Vector2 dir)
    {
        direction = dir;            
    }

    public override void Jump()
    {
        RaycastHit2D hitL = Physics2D.Raycast(new Vector3(transform.position.x - playerWidth / 5, transform.position.y, transform.position.z), Vector2.down, groundDetectionDistance,1);
        RaycastHit2D hitR = Physics2D.Raycast(new Vector3(transform.position.x + playerWidth / 5, transform.position.y, transform.position.z), Vector2.down, groundDetectionDistance,1);

        Debug.DrawLine(new Vector3(transform.position.x - playerWidth / 5, transform.position.y), new Vector3(transform.position.x - playerWidth / 5, transform.position.y-groundDetectionDistance), Color.red);
        Debug.DrawLine(new Vector3(transform.position.x + playerWidth / 5, transform.position.y), new Vector3(transform.position.x + playerWidth / 5, transform.position.y- groundDetectionDistance), Color.red);
        if ((hitL.collider != null || hitR.collider != null) && rBody.drag == 1)
        {
            rBody.AddForce(Vector2.up * jumpStrength);
        }
        else if (jumps < maxJumps && rBody.velocity.y < 200)
        {
            rBody.AddForce(Vector2.up * jumpStrength);
            jumps++;
        }
    }

    public override Vector2 GetDirection()
    {
        Vector2 dir = new   Vector2(((Mathf.Abs(direction.x)>0f)? direction.x : 0) , ((Mathf.Abs(direction.y)>0f)? direction.y : 0));
        return dir;
    }
}
