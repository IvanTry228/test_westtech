using Zenject;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class WindowMenuController : WindowLogicController
{
    [SerializeField]
    private string nameAssetFull;

    [Inject]
    private LoaderAssetController loaderAssetController;

    protected override void FuncButtonClick()
    {
        base.FuncButtonClick();
        CallLoadWindow();
    }

    private void CallLoadWindow()
    {
        loaderAssetController.LoadAsset<GameObject>(nameAssetFull, 
                (x) => loaderAssetController.SpawnGameObject(x, transform.parent), default).Forget();
    }
    
}