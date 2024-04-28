using UnityEngine;
using UnityEngine.EventSystems;

public class ActiveWeapons : SingletonBase<ActiveWeapons>
{
    [SerializeField] private Sword sword;

    private void Awake()
    {
        SetInstance();
    }

    private void Update()
    {
        FollowMousePosition();
    }

    public Sword GetActiveWeapon()
    {
        return sword;
    }


    private void FollowMousePosition()
    {
        Vector3 mousePos = PlayerInput.Instance.GetMousePosition();
        Vector3 playerPosition = PlayerMovement.Instance.GetPlayerScreenPosition();

        if (mousePos.x < playerPosition.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
