using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : SingletonBase<PlayerInput>
{
    private PlayerInputAction m_Action;

    public event EventHandler OnPlayerAttack;

    private void Awake()
    {
        SetInstance();
        m_Action = new PlayerInputAction();
        m_Action.Enable();
    }

    private void Start()
    {        
        m_Action.Combat.Attack.started += AttackStarted;
    }

    private void AttackStarted(InputAction.CallbackContext obj)
    {
        OnPlayerAttack?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementVector()
    {
        Vector2 inputVector = m_Action.Player.Move.ReadValue<Vector2>();
        return inputVector;
    }

    public Vector3 GetMousePosition()
    {
        Vector3 mousePosition = Mouse.current.position.ReadValue();
        return mousePosition;
    }
}
