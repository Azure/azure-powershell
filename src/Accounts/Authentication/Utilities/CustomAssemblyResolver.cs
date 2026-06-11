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
            "Newtonsoft.Json",
            "System.Memory.Data",
            "System.Text.Json",
            "Microsoft.Bcl.AsyncInterfaces",
            "Microsoft.IdentityModel.Abstractions", // Azure.Identity 1.13 depends on v6, MSAL 4.82 depends on v8 (what we ship)
            "System.Text.Encodings.Web"
        };

        /// <summary>
        /// System.Memory is a special case on Windows PowerShell / .NET Framework. Newer
        /// packages (e.g. System.Text.Json 10.x) are compiled against reference assemblies
        /// that record a System.Memory reference version of 4.0.5.0, but no NuGet
        /// System.Memory package has ever shipped a DLL with that assembly version - the
        /// highest shipping version is 4.0.2.0 (from package 4.6.x), which is what we
        /// carry. On .NET Framework the binder cannot satisfy the 4.0.5.0 request on its
        /// own, so we redirect down to the 4.0.2.0 DLL we ship.
        /// </summary>
        private static ISet<string> LowerVersionRedirectionAllowList = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "System.Memory"
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
                AssemblyName requested = new AssemblyName(args.Name);
                if (NetFxPreloadAssemblies.TryGetValue(requested.Name, out var available))
                {
                    if (CanProvideAssembly(requested, available.Version))
                    {
                        return Assembly.LoadFrom(available.Path);
                    }
                }
            }
            catch
            {
            }
            return null;
        }

        private static bool CanProvideAssembly(AssemblyName requested, Version availableVersion)
        {
            // Normal case: the on-disk asm is at least as new as what fusion asked for.
            if (availableVersion >= requested.Version)
            {
                return availableVersion.Major == requested.Version.Major
                    || IsCrossMajorVersionRedirectionAllowed(requested.Name);
            }

            // Special case for System.Memory: newer packages bind against a reference
            // version (4.0.5.0) that no NuGet System.Memory package has ever shipped.
            // .NET Framework cannot satisfy that request on its own, so we hand back the
            // highest shipping NuGet assembly (4.0.2.0) we already carry.
            if (IsLowerVersionRedirectionAllowed(requested.Name))
            {
                return true;
            }

            return false;
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

        /// <summary>
        /// We allow downward redirection only for System.Memory, whose highest shipped
        /// NuGet assembly version is lower than the reference version newer packages bind against.
        /// </summary>
        private static bool IsLowerVersionRedirectionAllowed(string assemblyName)
        {
            return LowerVersionRedirectionAllowList.Contains(assemblyName);
        }
    }
}
