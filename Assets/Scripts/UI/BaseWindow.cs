using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Events;

public class BaseWindow : MonoBehaviour
{
    [SerializeField]
    private Button currentButton;

    [SerializeField]
    private Button closeButton;

    [SerializeField]
    private UnityEvent OnCloseWindow;

    [Header("Params")]
    [SerializeField]
    private bool isDestroyOnExit;

    public event Action OnButtonClick;

    private void Start()
    {
        Init();
    }

    private void OnDestroy()
    {
        Unsubsribe();
    }

    private void Init()
    {
        Subsribe();
    }

    private void Subsribe()
    {
        currentButton.onClick.AddListener(CallMainButtonClick);
        closeButton.onClick.AddListener(CallCloseWindow);
    }

    private void Unsubsribe()
    {
        currentButton.onClick.RemoveListener(CallMainButtonClick);
        closeButton.onClick.RemoveListener(CallCloseWindow);
    }

    private void CallMainButtonClick()
    {
        OnButtonClick?.Invoke();
    }

    private void CallCloseWindow()
    {
        OnCloseWindow?.Invoke();
        if (isDestroyOnExit)
            Destroy(this);
    }
}
