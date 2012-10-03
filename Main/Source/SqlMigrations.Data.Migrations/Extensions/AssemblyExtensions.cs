namespace SqlMigrations.Data.Migrations.Extensions
{
    using System.Linq;
    using System.Reflection;

    internal static class AssemblyExtensions
    {
        public static string GetInformationalVersion(this Assembly assembly)
        {
            return assembly.GetCustomAttributes(false).OfType<AssemblyInformationalVersionAttribute>().Single().InformationalVersion;
        }
    }
}
