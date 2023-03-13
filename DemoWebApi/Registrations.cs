//using NuGet;
using SimpleInjector;
using SimpleInjector.Packaging;
using WebApi.BusinessLogic.AuthServices;
using WebApi.BusinessLogic.Services;
using WebApi.Repository.Context;
using WebApi.Repository.RepositoryActions;

namespace DemoWebApi
{
    public class Registrations : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<IDapperContext, DapperContext>(Lifestyle.Scoped);
            container.Register<IContactServices, ContactServices>(Lifestyle.Scoped);
            container.Register<IContactRepository, ContactRepository>(Lifestyle.Scoped);
            container.Register<IAuthRepository, AuthRepository>(Lifestyle.Scoped);
            container.Register<IAuthenticationServices, AuthenticationServices>(Lifestyle.Scoped);
            container.Register<ITokenHandler, WebApi.BusinessLogic.AuthServices.TokenHandler>(Lifestyle.Scoped);
        }
    }
}
