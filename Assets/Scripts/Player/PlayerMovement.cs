using System;
using UnityEngine;

public class PlayerMovement : SingletonBase<PlayerMovement>
{
    [SerializeField] private Rigidbody2D m_Rigidbody;
    [SerializeField] private float m_MovingSpeed;

    private float minMovingSpeed = 0.1f;
    private bool isMoving = false;

    private void Awake()
    {
        SetInstance();
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        PlayerInput.Instance.OnPlayerAttack += GameInput_OnPlayerAttack;
    }

    private void GameInput_OnPlayerAttack(object sender, EventArgs e)
    {
        ActiveWeapons.Instance.GetActiveWeapon().Attack();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector2 inputVector = PlayerInput.Instance.GetMovementVector();
        m_Rigidbody.MovePosition(m_Rigidbody.position + inputVector * (m_MovingSpeed * Time.fixedDeltaTime));

        if (Mathf.Abs(inputVector.x) > minMovingSpeed || Mathf.Abs(inputVector.y) > minMovingSpeed)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }

    public bool IsMoving()
    {
        return isMoving;
    }

    public Vector3 GetPlayerScreenPosition()
    {
        Vector3 playerScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
        return playerScreenPosition;
    }
}
