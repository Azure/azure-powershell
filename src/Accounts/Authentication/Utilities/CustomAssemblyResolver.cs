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

using Microsoft.Azure.PowerShell.AssemblyLoading;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Microsoft.Azure.Commands.Profile.Utilities
{
    /// <summary>
    /// Handles how common dependency assemblies like Azure.Core are loaded on .NET framework.
    /// </summary>
    public static class CustomAssemblyResolver
    {
        private static IDictionary<string, (string Path, Version Version)> NetFxPreloadAssemblies = ConditionalAssemblyProvider.GetAssemblies();
        private static ISet<string> CrossMajorVersionRedirectionAllowList = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "System.Diagnostics.DiagnosticSource",
            "System.Runtime.CompilerServices.Unsafe",
            "Newtonsoft.Json"
        };

        public static void Initialize()
        {
            //This function is call before loading assemblies in PreloadAssemblies folder, so NewtonSoft.Json could not be used here
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
                if (NetFxPreloadAssemblies.TryGetValue(name.Name, out var assembly))
                {
                    if (assembly.Version >= name.Version
                        && (assembly.Version.Major == name.Version.Major
                            || IsCrossMajorVersionRedirectionAllowed(name.Name)))
                    {
                        return Assembly.LoadFrom(assembly.Path);
                    }
                }
            }
            catch
            {
            }
            return null;
        }

        /// <summary>
        /// We allow cross major version redirection for some assemblies to avoid shipping multiple versions of the same assembly.
        /// Cautious should be taken when adding new assemblies to the allow list - make sure the new version is backward compatible.
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <returns></returns>
        private static bool IsCrossMajorVersionRedirectionAllowed(string assemblyName)
        {
            return CrossMajorVersionRedirectionAllowList.Contains(assemblyName);
        }
    }
}
