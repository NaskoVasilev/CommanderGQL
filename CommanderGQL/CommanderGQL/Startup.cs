using CommanderGQL.Data;
using CommanderGQL.GraphQL;
using GraphQL.Server.Ui.Voyager;
using Microsoft.EntityFrameworkCore;

namespace CommanderGQL
{
    public class Startup
    {
        private readonly IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPooledDbContextFactory<AppDbContext>(opt => opt
                .UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddProjections();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseWebSockets();

            app.UseRouting();

            app.UseEndpoints(endpoints => endpoints.MapGraphQL());

            app.UseGraphQLVoyager(new VoyagerOptions
            {
                GraphQLEndPoint = "/graphql"
            }, "/graphql-voyager");
        }
    }
}