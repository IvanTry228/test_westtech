using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

public class LoaderAssetController
{
    [Inject]
    private DiContainer _diContainer;

    public async UniTask LoadAsset<T>(string name, Action<T> OnSuccess, Action<string> onFail)
    {
        var someAsset = Addressables.LoadAssetAsync<T>(name);
        try
        {
            await someAsset;
            OnSuccess?.Invoke(someAsset.Result);
        }
        catch (Exception ex)
        {
            Debug.LogError(ex);
            onFail?.Invoke(ex.Message);
        }
    }

    //private async UniTask SpawnAsync<T>()
    //{
    //    var prefab = await LoadAsset<T>("Windows/GUI.prefab", GetType());
    //    _gui = _diContainer.InstantiatePrefabForComponent<Canvas>(prefab);
    //    _gui.name = "GUI";
    //    _faderTemplate = _gui.transform.Find("FaderTemplate").GetComponent<Image>();
    //}

    public void SpawnGameObject(GameObject prefab, Transform parent = null)
    {
        _diContainer.InstantiatePrefab(prefab, parent); //Instantiate(prefab, Vector3.zero, Quaternion.identity);
    }
}
