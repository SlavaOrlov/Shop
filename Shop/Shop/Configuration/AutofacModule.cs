using Autofac;
using Shop.Core;
using Shop.Data;

namespace Shop.Api.Configuration
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DatabaseOptions>().As<IDatabaseOptions>();
            builder.RegisterType<OrderProductRepository>().As<IOrderProductRepository>();
        }
    }
}
