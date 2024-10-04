using Zenject;

namespace WTFGames.Hephaestus.MobileSocial
{
    public class HephaestusMobileSocialInstaller : Installer<HephaestusMobileSocialInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<GameCenterSocialService>().AsSingle().NonLazy();
        }
    }
}