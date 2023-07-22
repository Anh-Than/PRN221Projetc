using LiveShop.Hubs;
using LiveShop.MiddlewareExtensions;
using LiveShop.SubscribeTableDependencies;

namespace LiveShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddSignalR();

            //DI
            builder.Services.AddSingleton<DashboardHub>();
            builder.Services.AddSingleton<SubscribeProductTableDependency>();
            builder.Services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromSeconds(1800);
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();
            
            app.MapRazorPages();

            app.MapHub<DashboardHub>("/dashboardHub");

            /*
             * we must call SubsribeTableDependency() here
             * we create one middleware and call SubscribeTableDependency() method in the middleware
             */
            app.UseProductTableDependency();

            app.Run();
        }
    }
}