using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private Transform target;
    [SerializeField] private Vector2 playerOffset;
    [SerializeField] private float onScreenZone;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (Mathf.Abs(Vector2.Distance(target.position, new Vector2(transform.position.x - playerOffset.x, transform.position.y -playerOffset.y))) > onScreenZone)
        {
            transform.position = Vector3.Slerp(transform.position, new Vector3(target.position.x + playerOffset.x, target.position.y + playerOffset.y, transform.position.z), .03f);

            if (Mathf.Abs(target.position.y - transform.position.y) >= camera.orthographicSize -.5f)
            {
                float yMod = (transform.position.y - target.position.y) / Mathf.Abs(transform.position.y - target.position.y);
                transform.position = new Vector3(transform.position.x, target.position.y + yMod * camera.orthographicSize -(yMod/2), -10);
            }

            if (Mathf.Abs(target.position.x - transform.position.x) >= camera.orthographicSize * camera.aspect -.5f )
            {
                float xMod = (transform.position.x - target.position.x) / Mathf.Abs(transform.position.x - target.position.x);
                transform.position = new Vector3(target.position.x + xMod * camera.orthographicSize * camera.aspect -(xMod/2), transform.position.y, -10);
            }
        }
    }
}
