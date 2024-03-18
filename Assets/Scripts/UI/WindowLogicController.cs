using UnityEngine;

public class WindowLogicController : MonoBehaviour
{
    [SerializeField]
    protected BaseWindow currentBaseWindow;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        SetupLogic(currentBaseWindow);
    }

    protected virtual void SetupLogic(BaseWindow someBaseWindow)
    {
        someBaseWindow.OnButtonClick += FuncButtonClick;
    }

    protected virtual void FuncButtonClick()
    {

    }
}
