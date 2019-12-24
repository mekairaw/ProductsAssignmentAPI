using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductsAssignmentAPI;
using ProductsAssignmentAPI.Domain.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsAssignmentAPI.IntegrationTests
{
    public class ProductsAssignmentTestFactory<T>: WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

                services.AddDbContext<AppDbContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryProductsAssignmentTest");
                    options.UseInternalServiceProvider(serviceProvider);
                });

                services.AddMvc(options => {
                    options.EnableEndpointRouting = false;
                });

                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    using(var appContext = scope.ServiceProvider.GetRequiredService<AppDbContext>())
                    {
                        appContext.Database.EnsureCreated();
                        try
                        {
                            Utilities.InitializeDbWithProducts(appContext);
                        }
                        catch(Exception ex)
                        {
                            throw;
                        }
                    }
                }
            });
        }
    }
}
