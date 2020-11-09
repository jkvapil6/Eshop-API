using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Eshop.GraphQL;
using Eshop.GraphQL.Types;
using Eshop.GraphQL.Data;
using Eshop.GraphQL.DataLoader;
using Eshop.GraphQL.Users;
using Eshop.GraphQL.Orders;
using Eshop.GraphQL.Products;
using Eshop.GraphQL.OrderItems;
using HotChocolate.AspNetCore.Voyager;

namespace GraphQL
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPooledDbContextFactory<ApplicationDbContext>(
                options => options.UseSqlite("Data Source=eshop.db"));

            services
                .AddGraphQLServer()
                .AddQueryType(d => d.Name("Query"))
                    .AddTypeExtension<UserQueries>()
                    .AddTypeExtension<OrderQueries>()
                    .AddTypeExtension<ProductQueries>()
                    .AddTypeExtension<OrderItemQueries>()
                .AddMutationType(d => d.Name("Mutation"))
                    .AddTypeExtension<UserMutations>()
                    .AddTypeExtension<OrderMutations>()
                    .AddTypeExtension<ProductMutations>()
                    .AddTypeExtension<OrderItemMutations>()
                .AddType<UserType>()
                .AddType<OrderType>()
                .AddType<OrderItemType>()
                // .EnableRelaySupport()
                .AddDataLoader<OrderByIdDataLoader>()
                .AddDataLoader<UserByIdDataLoader>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseVoyager(new VoyagerOptions {
                Path = "/voyager",
                QueryPath = "/graphql"
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
        }
    }
}
