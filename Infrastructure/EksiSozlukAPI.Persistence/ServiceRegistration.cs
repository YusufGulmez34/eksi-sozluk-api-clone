using EksiSozlukAPI.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using EksiSozlukAPI.Persistence.Mapping;
using EksiSozlukAPI.Application.Services;
using EksiSozlukAPI.Persistence.Services;
using EksiSozlukAPI.Application.Repositories.User;
using EksiSozlukAPI.Persistence.Repositories.User;
using EksiSozlukAPI.Application.Repositories.Title;
using EksiSozlukAPI.Persistence.Repositories.Title;
using EksiSozlukAPI.Persistence.Repositories.Entry;
using EksiSozlukAPI.Application.Repositories.Entry;

namespace EksiSozlukAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceService(this IServiceCollection services)
        {
            services.AddDbContext<EksiSozlukAPIDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));


            services.AddScoped<IUserWriteRepository, UserWriteRepository>();
            services.AddScoped<IUserReadRepository, UserReadRepository>();

            services.AddScoped<ITitleWriteRepository, TitleWriteRepository>();

            services.AddScoped<IEntryWriteRepository, EntryWriteRepository>();
            services.AddScoped<IEntryReadRepository, EntryReadRepository>();



            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<ITitleService, TitleService>();
            services.AddScoped<IEntryService, EntryService>();




            services.AddAutoMapper(typeof(MappingProfile));
        } 
    }
}
