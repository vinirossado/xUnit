using Autofac;

namespace GameProject.Infra
{
    public class NativeInjectorBootStrapper
    {
        public static void LoadService(ContainerBuilder builder)
        {

            //builder.RegisterType<AttractionService>().As<IAttractionService>().InstancePerLifetimeScope();


        }

        public static void LoadRepository(ContainerBuilder builder)
        {

            //builder.RegisterType<AttractionRepository>().As<IAttractionRepository>().InstancePerLifetimeScope();
        }

        public static void LoadOthers(ContainerBuilder builder)
        {

            //builder.RegisterType<IdentityPasswordHasher<User>>().As<IPasswordHasher<User>>().InstancePerLifetimeScope();
        }
    }
}
