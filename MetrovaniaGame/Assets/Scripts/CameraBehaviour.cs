using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector2 offset;
    [SerializeField] private int onScreenZone;

    void Start()
    {
        
    }

    void Update()
    {
        if (Mathf.Abs(Vector2.Distance(target.position, new Vector2(transform.position.x - offset.x, transform.position.y -offset.y))) > onScreenZone)
        {
            transform.position = Vector3.Slerp(transform.position,  new Vector3(target.position.x + offset.x, target.position.y + offset.y,transform.position.z), .03f);
        }
    }
}
