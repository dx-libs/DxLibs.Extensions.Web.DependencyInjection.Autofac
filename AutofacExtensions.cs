using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DxLibs.Extensions.Web.DependencyInjection.Autofac
{
    public static class AutofacExtensions
    {
        public static IServiceProvider BuildServiceProvider(this IServiceCollection services, Action<IServiceCollection> preBuildProvider = null)
        {
            var builderFactory = new ContainerBuilder();

            var builder = new ContainerBuilder();

            builder.Populate(services);

            preBuildProvider?.Invoke(services);

            var container = builder.Build();

            return container.Resolve<IServiceProvider>();
        }
    }
}
