using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
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
            transform.position = Vector3.Slerp(transform.position,  new Vector3(target.position.x + playerOffset.x, target.position.y + playerOffset.y,transform.position.z), .03f);
        }
    }
}
