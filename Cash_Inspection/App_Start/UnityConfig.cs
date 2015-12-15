using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using Cash_Inspection.Data.Model.Interfaces;
using Microsoft.AspNet.Identity;
using Cash_Inspection.Data.Identity;
using System;
using Cash_Inspection.Data.Repositories;

namespace Cash_Inspection
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager(), new InjectionConstructor("Cash_Inspection"));
            container.RegisterType<IUserStore<IdentityUser, Guid>, UserStore>(new TransientLifetimeManager());
            container.RegisterType<RoleStore>(new TransientLifetimeManager());

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}