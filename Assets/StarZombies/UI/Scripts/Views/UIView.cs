using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public abstract class UIView : MonoBehaviour
{
    [SerializeField]
    private bool isHideOnStart = true;

    protected CanvasGroup _canvasGroup;

    public bool isVisable { get; protected set; }

   protected virtual void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        ViewsManager.Register(this);

        if (isHideOnStart)
        {
            Hide();
        }
    }

    protected virtual void OnDestroy()
    {
        ViewsManager.UnRegister(this);
    }

    public virtual void Show()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.interactable= true;
        isVisable = true;
    }

    public virtual void Hide()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
        isVisable = false;
    }
}
