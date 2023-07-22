using StoreManagement.SubscribeTableDependencies;

namespace StoreManagement.MiddlewareExtension
{
    public static class ApplicationBuilderExtension
    {
        public static void UseProductTableDependency(this IApplicationBuilder app)
        {
            var serviceProvider = app.ApplicationServices;
            var service = serviceProvider.GetService<SubscribeProductTableDependency>();
            service.SubscribeTableDependency();
        }

        public static void UseEmployeeTableDependency(this IApplicationBuilder app)
        {
            var serviceProvider = app.ApplicationServices;
            var service = serviceProvider.GetService<SubscribeEmployeeTableDependency>();
            service.SubscribeTableDependency();
        }
    }
}
