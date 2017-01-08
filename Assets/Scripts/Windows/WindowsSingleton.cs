using UnityEngine;

public class WindowsSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T _instance;
	protected static Transform _cachedTransform;

    /// <summary>
    /// Получение ссылки на себя
    /// </summary>
    public static T Instance
    {
        get
        {
            return _instance;
        }
    }

    /// <summary>
    /// Получение трансформы
    /// </summary>
    public static Transform CachedTransform
    {
        get
        {
            return _cachedTransform;
        }
    }

    public GameObject Root;
    public bool HideAtAwake;

    /// <summary>
    /// При создании
    /// </summary>
    public virtual void Awake()
    {
        _instance = GetComponent<T>();
        _cachedTransform = transform;
 
        if (HideAtAwake)
            Hide();
        else
            Open();
    }

    /// <summary>
    /// Открыть окно
    /// </summary>
    static public void Open(bool _action = true)
    {
        //Если надо вызвать событие
        if (_action)
            _cachedTransform.SendMessage("OpenAction", SendMessageOptions.DontRequireReceiver);
    }

    /// <summary>
    /// Закрыть окно
    /// </summary>
    static public void Hide(bool _action = true)
    {
        //Если надо вызвать событие
        if (_action)
            _cachedTransform.SendMessage("CloseAction", SendMessageOptions.DontRequireReceiver);
    }

    /// <summary>
    /// Событие по открыванию
    /// </summary>
    public virtual void OpenAction()
    {
        Root.SetActive(true);
    }

    /// <summary>
    /// Событие закрытия
    /// </summary>
    public virtual void CloseAction()
    {
        Root.SetActive(false);
    }
}