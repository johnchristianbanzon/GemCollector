
using UnityEngine;
using Zenject;

public class ModelInstaller : Installer<ModelInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<UIManager>().To<UIManager>().FromNew().AsSingle();
        Container.Bind<GameManager>().To<GameManager>().FromNew().AsSingle();
        Container.Bind<InputManager>().To<InputManager>().FromNew().AsSingle();
        Container.Bind<PlayerManager>().To<PlayerManager>().FromNew().AsSingle();
        Container.Bind<SoundManager>().To<SoundManager>().FromNew().AsSingle();
        Container.Bind<LoadingManager>().To<LoadingManager>().FromNew().AsSingle();
        
    }
}
