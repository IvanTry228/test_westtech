using System.Net.Http;
using Zenject;

public class ClientInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<HttpClient>().FromMethod(GetHttpClient).AsSingle();

        Container.BindInterfacesAndSelfTo<LoaderAssetController>().AsSingle();
        Container.BindInterfacesAndSelfTo<GameTypesService>().AsSingle();
    }

    //Helpers getters
    private HttpClient httpClient = new HttpClient(); //todo: factory
    private HttpClient GetHttpClient()
    {
        return httpClient;
    }
}