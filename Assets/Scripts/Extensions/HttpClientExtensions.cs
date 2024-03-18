using Cysharp.Threading.Tasks;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

public static class HttpClientExtensions
{
    public static async UniTask<HttpResponseMessage> CustomPostAsJsonAsync<T>(this HttpClient httpClient, string url, T content)
    {
        var json = JsonConvert.SerializeObject(content);
        var data = new StringContent(json, Encoding.UTF8, "application/json");
        return await httpClient.PostAsync(url, data);
    }

    public static async UniTask<HttpResponseMessage> CustomPutAsJsonAsync<T>(this HttpClient httpClient, string url, T content)
    {
        var json = JsonConvert.SerializeObject(content);
        var data = new StringContent(json, Encoding.UTF8, "application/json");
        return await httpClient.PutAsync(url, data);
    }

    public static async UniTask<T> CustomReadFromJsonAsync<T>(this HttpContent content)
    {
        var responseBody = await content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(responseBody);
    }
}