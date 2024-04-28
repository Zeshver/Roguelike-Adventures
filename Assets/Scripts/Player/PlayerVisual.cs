using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private Animator m_Animator;
    private SpriteRenderer m_SpriteRenderer;
    private PlayerMovement m_PlayerMovement;

    private const string IS_RUNNING = "IsRunning";

    private void Awake()
    {
        m_Animator = GetComponent<Animator>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_PlayerMovement = GetComponentInParent<PlayerMovement>();
    }

    private void Update()
    {
        m_Animator.SetBool(IS_RUNNING, m_PlayerMovement.IsMoving());
        PlayerFacingDirection();
    }

    private void PlayerFacingDirection()
    {
        Vector3 mousePosition = PlayerInput.Instance.GetMousePosition();
        Vector3 playerPosition = m_PlayerMovement.GetPlayerScreenPosition();

        if (mousePosition.x < playerPosition.x)
        {
            m_SpriteRenderer.flipX = true;
        }
        else
        {
            m_SpriteRenderer.flipX= false;
        }
    }
}
