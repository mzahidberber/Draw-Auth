using AuthServer.Business.Abstract;
using AuthServer.Business.Concrete;
using Ninject.Modules;

namespace AuthServer.Business.DependencyResolvers.Ninject
{
    internal class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAuthenticationService>().To<AuthenticationService>();
            Bind<ITokenService>().To<TokenService>().InSingletonScope();
            Bind<IUserSevice>().To<UserService>().InSingletonScope();
        }
    }
}
