using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using System;

public class PlayerInputHandler : MonoBehaviour, ControllHandler
{
    private InputManager controls;
    [SerializeReference] private Character puppet;

    private void Awake()
    {
        controls = new InputManager();
        controls.Player.Jump.performed += _ => Jump();
        controls.Player.MoveHorizontal.performed += ctx => Move(ctx.ReadValue<float>());
        controls.Player.Attack.performed += _=> Attack();
    }

    private void Jump()
    {
        puppet.GetMoveHandler().Jump();
    }

    private void Move (float dir)
    {
        puppet.GetMoveHandler().Move(new Vector2(dir, 0));
    }

    private void Attack()
    {
        puppet.GetAttackHandeler().Attack();
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
