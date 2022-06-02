using Autofac;

namespace GameProject.Infra
{
    public class AutoFacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            #region Carrega IOC

            NativeInjectorBootStrapper.LoadService(builder);
            NativeInjectorBootStrapper.LoadRepository(builder);
            NativeInjectorBootStrapper.LoadOthers(builder);

            #endregion
        }
    }
}
