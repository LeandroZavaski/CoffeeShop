using CoffeeShop.Data;
using CoffeeShop.Interfaces;
using CoffeeShop.Mutation;
using CoffeeShop.Query;
using CoffeeShop.Schema;
using CoffeeShop.Services;
using CoffeeShop.Type;
using CoffeeShop.Type.Input;
using GraphiQl;
using GraphQL.Server;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CoffeeShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Services
            services.AddTransient<IMenu, MenuService>();
            services.AddTransient<ISubMenu, SubMenuService>();
            services.AddTransient<IReservation, ReservationService>();

            // Types
            services.AddScoped<MenuType>();
            services.AddScoped<SubMenuType>();
            services.AddScoped<ReservationType>();

            // Queries
            services.AddScoped<MenuQuery>();
            services.AddScoped<SubMenuQuery>();
            services.AddScoped<ReservationQuery>();
            services.AddScoped<RootQuery>();

            // Mutations
            services.AddScoped<MenuMutation>();
            services.AddScoped<SubMenuMutation>();
            services.AddScoped<ReservationMutation>();
            services.AddScoped<RootMutation>();

            // Inputs
            services.AddScoped<MenuInputType>();
            services.AddScoped<SubMenuInputType>();
            services.AddScoped<ReservationInputType>();

            // Schema
            services.AddScoped<ISchema, RootSchema>();

            services.AddGraphQL(options =>
            {
                options.EnableMetrics = false;

            }).AddSystemTextJson();

            services.AddDbContext<GraphQLDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("GrapQlDbConnection"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, GraphQLDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            dbContext.Database.EnsureCreated();
            app.UseGraphiQl("/graphql");
            app.UseGraphQL<ISchema>();

            //app.UseHttpsRedirection();

            //app.UseRouting();

            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
        }
    }
}
