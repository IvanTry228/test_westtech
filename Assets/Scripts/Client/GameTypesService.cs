using System;
using System.Net.Http;
using UnityEngine;
using Client.DTO;
using Cysharp.Threading.Tasks;

public class GameTypesService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    public GameTypesService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _baseUrl = ApiUrl.BaseUrl;
    }

    public async UniTask GetAllGamesUpdate(Action<GameTypesAllGamesDTO> OnSuccess, Action<string> OnFail, Action onFinally)
    {
        try
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/Game/GetAllGames");
            response.EnsureSuccessStatusCode();

            var cachedResult = await response.Content.CustomReadFromJsonAsync<GameTypesAllGamesDTO>();

            OnSuccess?.Invoke(cachedResult);
        }
        catch (Exception ex)
        {
            Debug.LogError(ex.Message);
            OnFail?.Invoke(ex.Message);
        }
        finally
        {
            onFinally?.Invoke();
        }
    }
}