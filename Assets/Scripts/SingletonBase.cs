using UnityEngine;

[DisallowMultipleComponent]
public abstract class SingletonBase<T> : MonoBehaviour where T : MonoBehaviour
{
    [Header("Singleton")]
    [SerializeField] private bool m_DoNotDestroyOnLoad;

    public static T Instance { get; private set; }

    protected void SetInstance()
    {
        if (Instance != null)
        {
            Debug.LogWarning("MonoSingleton: object of type already exist, instance will be destroed = " + typeof(T).Name);
            Destroy(this);
            return;
        }

        Instance = this as T;

        if (m_DoNotDestroyOnLoad)
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
