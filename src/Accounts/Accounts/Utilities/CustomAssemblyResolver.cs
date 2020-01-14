using System;
using System.IO;
using System.Reflection;

namespace Microsoft.Azure.Commands.Profile.Utilities
{
    public static class CustomAssemblyResolver
    {
        private static Version NewtonSoftJsonVersion = new Version(9, 0);

        public static void Initialize()
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        }

        public static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            try
            {
                AssemblyName name = new AssemblyName(args.Name);
                if(string.Equals(name.Name, "Newtonsoft.Json", StringComparison.OrdinalIgnoreCase) 
                    && name.Version?.CompareTo(NewtonSoftJsonVersion) == 0)
                {
                    string accountFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    string newtonsoftJsonPath = Path.Combine(accountFolder, @"PreloadAssemblies\Newtonsoft.Json.10.dll");
                    return Assembly.LoadFrom(newtonsoftJsonPath);
                }
            }
            catch
            {
            }
            return null;
        }
    }
}