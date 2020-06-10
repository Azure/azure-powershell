using System;
using System.IO;
using System.Reflection;

namespace Microsoft.Azure.Commands.Profile.Utilities
{
    public static class CustomAssemblyResolver
    {
        public static void Initialize()
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        }

        /// <summary>
        /// When the resolution of an assembly fails, if it's Newtonsoft.Json 9, redirect to 10
        /// </summary>
        public static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            try
            {
                AssemblyName name = new AssemblyName(args.Name);
                if(string.Equals(name.Name, "Azure.Core", StringComparison.OrdinalIgnoreCase)
                    && name.Version?.Major == 1 && (name.Version?.Minor == 2 && name.Version?.Build <= 1 || 
                    name.Version?.Minor == 1))
                {
                    string accountFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    string azureCorePath = Path.Combine(accountFolder, @"PreloadAssemblies\Azure.Core.dll");
                    return Assembly.LoadFrom(azureCorePath);
                }
            }
            catch
            {
            }
            return null;
        }
    }
}
