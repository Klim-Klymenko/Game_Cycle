using VContainer;
using VContainer.Unity;

namespace GameCycle
{
    public sealed class GameCycleLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder) => RegisterManagers(builder);
        
        private void RegisterManagers(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<GameManager>().AsSelf();
            builder.RegisterEntryPoint<GameManagerInstaller>();
        }
    }
}