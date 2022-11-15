using Autofac;
using Castle.DynamicProxy;
using EksiSozlukAPI.Application.Repositories.Entry;
using EksiSozlukAPI.Application.Repositories.Title;
using EksiSozlukAPI.Application.Repositories.User;
using EksiSozlukAPI.Application.Services;
using EksiSozlukAPI.Persistence.Contexts;
using EksiSozlukAPI.Persistence.Repositories.Entry;
using EksiSozlukAPI.Persistence.Repositories.Title;
using EksiSozlukAPI.Persistence.Repositories.User;
using EksiSozlukAPI.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Autofac.Extras.DynamicProxy;
using EksiSozlukAPI.Persistence.Interceptors;


namespace EksiSozlukAPI.Persistence
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c =>
            {
                var opt = new DbContextOptionsBuilder<EksiSozlukAPIDbContext>();
                opt.UseNpgsql(Configuration.ConnectionString);
                return new EksiSozlukAPIDbContext(opt.Options);
            }).AsSelf().SingleInstance();

            builder.RegisterType<UserReadRepository>().As<IUserReadRepository>().SingleInstance();
            builder.RegisterType<UserWriteRepository>().As<IUserWriteRepository>().SingleInstance();

            builder.RegisterType<TitleReadRepository>().As<ITitleReadRepository>().SingleInstance();
            builder.RegisterType<TitleWriteRepository>().As<ITitleWriteRepository>().SingleInstance();

            builder.RegisterType<EntryReadRepository>().As<IEntryReadRepository>().SingleInstance();
            builder.RegisterType<EntryWriteRepository>().As<IEntryWriteRepository>().SingleInstance();

            builder.RegisterType<EntryService>().As<IEntryService>().SingleInstance();
            builder.RegisterType<TitleService>().As<ITitleService>().SingleInstance();
            builder.RegisterType<AuthService>().As<IAuthService>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
