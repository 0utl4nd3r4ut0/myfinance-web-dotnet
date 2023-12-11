using System.Reflection;

namespace myFinance_web_dotnet.Infrastructure
{
    public class AssemblyUtil
    {
        public static IEnumerable<Assembly> GetCurrentAssemblies()
        {
            return new Assembly[]
            {
                Assembly.Load("myFinance_web_dotnet"),
            };
        }

    }
}