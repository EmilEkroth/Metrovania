using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using System;

public class PlayerInputHandler : MonoBehaviour, ControllHandler
{
    private InputManager controls;
    [SerializeReference] private MoveHandler puppetMove;
    [SerializeReference] private AttackHandeler puppetAttack;

    private void Awake()
    {
        controls = new InputManager();
        controls.Player.Jump.performed += _ => Jump();
        controls.Player.MoveHorizontal.performed += ctx => Move(ctx.ReadValue<float>());
        controls.Player.Attack.performed += _=> Attack();
    }

    private void Jump()
    {
        puppetMove.Jump();
    }

    private void Move (float dir)
    {
        puppetMove.Move(new Vector2(dir, 0));
    }

    private void Attack()
    {
        puppetAttack.Attack();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
