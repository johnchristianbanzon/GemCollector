using Zenject;

public class GameViewInstaller : MonoInstaller<GameViewInstaller>
{
    public override void InstallBindings()
    {

        ModelInstaller.Install(Container);
        Container.Bind<AIThiefAlienBehavior>().FromComponentInHierarchy().AsCached();
    }
}
