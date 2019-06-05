using AutoDealer.Core.Config;
using AutoDealer.Core.Infrastructure;
using AutoDealer.Core.Infrastucture;
using AutoDealer.Core.Log;
using AutoDealer.Data;
using AutoDealer.WebCore.Infrastucture;
using System;
using System.Configuration;
using Unity;

namespace AutoDealer.Web
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        //private static Lazy<IUnityContainer> container =
        //  new Lazy<IUnityContainer>(() =>
        //  {
        //      var container = new UnityContainer();
        //      RegisterTypes(container);
        //      return container;
        //  });

        public static IUnityContainer GetConfiguredContainer()
        {
            RegisterTypes(ServiceContainer.Current);
            return ServiceContainer.Current;
        }

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        //public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType(typeof(ILogger), typeof(NLogLogger));
            container.RegisterInstance(container);

            ITypeFinder typeFinder = new WebTypeFinder();

            var config = ConfigurationManager.GetSection("applicationConfig") as ApplicationConfig;

            container.RegisterInstance(config);

            var registerTypes = typeFinder.FindClassesOfType<IDependencyRegister>();

            foreach (Type registerType in registerTypes)
            {
                var register = (IDependencyRegister)Activator.CreateInstance(registerType);
                register.RegisterTypes(container);
            }
        }
    }
}