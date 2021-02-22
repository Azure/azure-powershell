// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Microsoft.Azure.Commands.Profile.Utilities
{
    public static class CustomAssemblyResolver
    {
        private static IDictionary<string, Version> NetFxPreloadAssemblies =
            new Dictionary<string, Version>(StringComparer.InvariantCultureIgnoreCase)
            {
                {"Azure.Core", new Version("1.8.1.0")},
                {"Microsoft.Bcl.AsyncInterfaces", new Version("1.0.0.0")},
                {"Microsoft.Identity.Client", new Version("4.21.0.0") },
                {"Microsoft.Identity.Client.Extensions.Msal", new Version("2.16.2.0") },
                {"Microsoft.IdentityModel.Clients.ActiveDirectory", new Version("3.19.2.6005")},
                {"Microsoft.IdentityModel.Clients.ActiveDirectory.Platform", new Version("3.19.2.6005")},
                {"Newtonsoft.Json", new Version("10.0.0.0")},
                {"System.Buffers", new Version("4.0.3.0")},
                {"System.Diagnostics.DiagnosticSource", new Version("4.0.4.0")},
                {"System.Memory", new Version("4.0.1.1")},
                {"System.Memory.Data", new Version("1.0.0.0")},
                {"System.Net.Http.WinHttpHandler", new Version("4.0.2.0")},
                {"System.Numerics.Vectors", new Version("4.1.3.0")},
                {"System.Private.ServiceModel", new Version("4.1.2.1")},
                {"System.Reflection.DispatchProxy", new Version("4.0.3.0")},
                {"System.Runtime.CompilerServices.Unsafe", new Version("4.0.5.0")},
                {"System.Security.AccessControl", new Version("4.1.1.0")},
                {"System.Security.Cryptography.Cng", new Version("4.3.0.0")},
                {"System.Security.Permissions", new Version("4.0.1.0")},
                {"System.Security.Principal.Windows", new Version("4.1.1.0")},
                {"System.ServiceModel.Primitives", new Version("4.2.0.0")},
                {"System.Text.Encodings.Web", new Version("4.0.4.0")},
                {"System.Text.Json", new Version("4.0.0.0")},
                {"System.Threading.Tasks.Extensions", new Version("4.2.0.0")},
                {"System.Xml.ReaderWriter", new Version("4.1.0.0")}
            };

        private static string PreloadAssemblyFolder { get; set; }

        public static void Initialize()
        {
            //This function is call before loading assemblies in PreloadAssemblies folder, so NewtonSoft.Json could not be used here
            var accountFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            PreloadAssemblyFolder = Path.Combine(accountFolder, "PreloadAssemblies");
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        }

        /// <summary>
        /// When the resolution of an assembly fails, if will try to redirect to the higher version
        /// </summary>
        public static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            try
            {
                AssemblyName name = new AssemblyName(args.Name);
                if (NetFxPreloadAssemblies.TryGetValue(name.Name, out Version version))
                {
                    //For Newtonsoft.Json, allow to use bigger version to replace smaller version
                    if (version >= name.Version && (version.Major == name.Version.Major || string.Equals(name.Name, "Newtonsoft.Json", StringComparison.OrdinalIgnoreCase)))
                    {
                        string requiredAssembly = Path.Combine(PreloadAssemblyFolder, $"{name.Name}.dll");
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
