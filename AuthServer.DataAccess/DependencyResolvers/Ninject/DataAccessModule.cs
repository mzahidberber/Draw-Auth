using AuthServer.DataAccess.Abstract;
using AuthServer.DataAccess.Concrete;
using Ninject.Modules;

namespace AuthServer.DataAccess.DependencyResolvers.Ninject
{
    internal class DataAccessModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IGenericRepository<>)).To(typeof(GenericRepository<>)).InSingletonScope();
            Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
        }
    }
}
