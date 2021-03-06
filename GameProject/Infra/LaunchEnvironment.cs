namespace GameProject.Infra
{
    public class LaunchEnvironment
    {
        public LaunchEnvironment() { }

        public static string DbConnection { get => Environment.GetEnvironmentVariable("DB_CONNECTION"); }
        public static string DbName { get => Environment.GetEnvironmentVariable("DB_NAME"); }

        public static string AllowedOrigins { get => Environment.GetEnvironmentVariable("ALLOWED_ORIGINS"); }

    }
}
