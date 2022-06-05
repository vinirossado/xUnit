using Autofac;
using GameProject.Infra.Configs;
using GameProject.Infra.Repository;

namespace GameProject.Infra
{
    public class NativeInjectorBootStrapper
    {
        public static void LoadService(ContainerBuilder builder)
        {
            builder.RegisterType<DataService>().As<IDataService>().InstancePerLifetimeScope();
        }

        public static void LoadRepository(ContainerBuilder builder)
        {

            //builder.RegisterType<CharacterRepository>().As<ICharacterRepository>().InstancePerLifetimeScope();
        }

        public static void LoadOthers(ContainerBuilder builder)
        {

            //builder.RegisterType<IdentityPasswordHasher<User>>().As<IPasswordHasher<User>>().InstancePerLifetimeScope();
        }
    }
}
