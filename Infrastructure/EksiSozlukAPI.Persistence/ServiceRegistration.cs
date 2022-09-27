using EksiSozlukAPI.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;


namespace EksiSozlukAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceService(this IServiceCollection services)
        {
            services.AddDbContext<EksiSozlukAPIDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
            
        } 
    }
}
