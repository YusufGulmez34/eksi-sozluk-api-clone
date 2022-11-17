using EksiSozlukAPI.Persistence.Contexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozlukTest
{
    public class TestFactory<T> : WebApplicationFactory<T> where T : class
    {
       
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Testing")
                .ConfigureTestServices(services =>
                {
                    var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<EksiSozlukAPIDbContext>));
                    if (descriptor != null) services.Remove(descriptor);
                    
                    var options = new DbContextOptionsBuilder<EksiSozlukAPIDbContext>().UseInMemoryDatabase("test").Options;
                    services.AddScoped<EksiSozlukAPIDbContext>(p => new TestDbContext(options));

                    var serviceProvider = services.BuildServiceProvider();
                    using var scope = serviceProvider.CreateScope();
                    var scopedService = scope.ServiceProvider;
                    var db = scopedService.GetRequiredService<EksiSozlukAPIDbContext>();
                    db.Database.EnsureCreated();
                });

            
        }
    }
}
