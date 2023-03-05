using Ninject;

namespace AuthServer.DataAccess.DependencyResolvers.Ninject
{
    public class DataAccessInstanceFactory
    {
        public static T GetInstance<T>()
        {
            var kernel = new StandardKernel(new DataAccessModule());
            return kernel.Get<T>();
        }
    }
}
