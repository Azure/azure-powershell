using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Profile.Utilities
{
    public static class CustomAssemblyResolver
    {
        private static IDictionary<string, Version> NetFxPreloadAssemblies =
            new Dictionary<string, Version>(StringComparer.InvariantCultureIgnoreCase);

        private static string PreloadAssemblyFolder { get; set; }

        public static void Initialize()
        {
            var accountFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            PreloadAssemblyFolder = Path.Combine(accountFolder, "PreloadAssemblies");
            var assemblyInfo = File.ReadAllText(Path.Combine(accountFolder, "PreloadAssemblyInfo.json"));

            var root = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(assemblyInfo);
            var netfx = root["netfx"];
            foreach(var info in netfx)
            {
                NetFxPreloadAssemblies[info.Key] = new Version(info.Value);
            }

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
                if (NetFxPreloadAssemblies.TryGetValue(args.Name, out Version version))
                {
                    if (version >= name.Version && version.Major == name.Version.Major)
                    {
                        string requiredAssembly = Path.Combine(PreloadAssemblyFolder, $"{args.Name}.dll");
                        return Assembly.LoadFrom(requiredAssembly);
                    }
                }
            }
            catch
            {
            }
            return null;
        }
    }
}
