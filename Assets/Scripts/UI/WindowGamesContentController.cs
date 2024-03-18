using Client.DTO;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class WindowGamesContentController : WindowLogicController
{
    [SerializeField]
    private string nameAssetFull;
    [SerializeField]
    private GameObject isLoadingStateObj;
    [SerializeField]
    private TMP_Text exceptionText;
    [SerializeField]
    private Transform contentScrollParent;

    private GameObject cachedAssetPrefab;
    private List<GameTypeItemView> cachedGameTypeItemViews;

    [Inject]
    private LoaderAssetController loaderAssetController;
    [Inject]
    private GameTypesService gameTypesService;

    protected override void SetupLogic(BaseWindow someBaseWindow)
    {
        base.SetupLogic(someBaseWindow);
        loaderAssetController.LoadAsset<GameObject>(nameAssetFull, (x) => cachedAssetPrefab = x, default).Forget();
    }

    protected override void FuncButtonClick()
    {
        base.FuncButtonClick();
        CallLoadGameContent();
    }

    private void CallLoadGameContent()
    {
        isLoadingStateObj.SetActive(true);
        Clear();
        gameTypesService.GetAllGamesUpdate(OnSuccess, OnFail, OnFinally).Forget();
    }

    private void Clear()
    {
        exceptionText.SetText(string.Empty);

        if (cachedGameTypeItemViews == null || cachedGameTypeItemViews.Count == 0)
        {
            cachedGameTypeItemViews = new List<GameTypeItemView>();
            return;
        }

        foreach (var item in cachedGameTypeItemViews)
            Destroy(item.gameObject);

        cachedGameTypeItemViews.Clear();
    }

    private void OnSuccess(GameTypesAllGamesDTO content)
    {
        var contentGamesList = content.Games;

        foreach (var item in contentGamesList)
        {
            var itemViewObj = Instantiate(cachedAssetPrefab, contentScrollParent);
            var itemView = itemViewObj.GetComponent<GameTypeItemView>();
            itemView.SetupContent(item);
            cachedGameTypeItemViews.Add(itemView);
        }
    }

    private void OnFail(string onFail)
    {
        exceptionText.SetText(onFail);
    }

    private void OnFinally()
    {
        isLoadingStateObj.SetActive(false);
    }
}
