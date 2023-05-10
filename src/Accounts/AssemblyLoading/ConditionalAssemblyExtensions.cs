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
using System.Runtime.InteropServices;

namespace Microsoft.Azure.PowerShell.AssemblyLoading
{
    /// <summary>
    /// Contains a set of definitions of constraints of conditional assemblies here, using builder pattern.
    /// </summary>
    public static class ConditionalAssemblyExtensions
    {
        /// <summary>
        /// The given assembly should be loaded in Windows PowerShell.
        /// </summary>
        public static IConditionalAssembly WithWindowsPowerShell(this IConditionalAssembly assembly)
        {
            // In PowerShell 4 and below, this variable does not exist.
            // $PSEdition being null should be treated as the same as having the value Desktop.
            // https://learn.microsoft.com/en-us/powershell/module/microsoft.powershell.core/about/about_powershell_editions?view=powershell-7.3
            var psEdition = assembly.Context.PSEdition ?? Constants.PSEditionDesktop;
            bool shouldLoad = psEdition.Equals(Constants.PSEditionDesktop, StringComparison.OrdinalIgnoreCase);
            assembly.UpdateShouldLoad(shouldLoad);
            return assembly;
        }

        /// <summary>
        /// The given assembly should be loaded in PowerShell Core (6+).
        /// </summary>
        public static IConditionalAssembly WithPowerShellCore(this IConditionalAssembly assembly)
        {
            var psEdition = assembly.Context.PSEdition ?? Constants.PSEditionDesktop;
            bool shouldLoad = psEdition.Equals(Constants.PSEditionCore, StringComparison.OrdinalIgnoreCase);
            assembly.UpdateShouldLoad(shouldLoad);
            return assembly;
        }

        /// <summary>
        /// The given assembly should be loaded when the version of PowerShell lies in
        /// [<paramref name="lower"/>, <paramref name="upper"/>).
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="lower">Lower limit of PowerShell version, inclusive.</param>
        /// <param name="upper">Upper limit of PowerShell version, exclusive.</param>
        public static IConditionalAssembly WithPowerShellVersion(this IConditionalAssembly assembly, Version lower, Version upper = null)
        {
            bool shouldLoad;
            var psVersion = assembly.Context.PSVersion;
            if (psVersion == null)
            {
                shouldLoad = false;
            }
            else
            {
                shouldLoad = lower <= assembly.Context.PSVersion;
                if (upper != null)
                {
                    shouldLoad = shouldLoad && assembly.Context.PSVersion < upper;
                }
            }
            assembly.UpdateShouldLoad(shouldLoad);
            return assembly;
        }

        /// <summary>
        /// The given assembly should be loaded on Windows.
        /// </summary>
        public static IConditionalAssembly WithWindows(this IConditionalAssembly assembly)
            => assembly.WithOS(OSPlatform.Windows);

        /// <summary>
        /// The given assembly should be loaded on Mac OS.
        /// </summary>
        public static IConditionalAssembly WithMacOS(this IConditionalAssembly assembly)
            => assembly.WithOS(OSPlatform.OSX);

        /// <summary>
        /// The given assembly should be loaded on Linux.
        /// </summary>
        public static IConditionalAssembly WithLinux(this IConditionalAssembly assembly)
            => assembly.WithOS(OSPlatform.Linux);

        private static IConditionalAssembly WithOS(this IConditionalAssembly assembly, OSPlatform os)
        {
            assembly.UpdateShouldLoad(assembly.Context.IsOSPlatform(os));
            return assembly;
        }

        /// <summary>
        /// The given assembly should be loaded on x86 platform.
        /// </summary>
        public static IConditionalAssembly WithX86(this IConditionalAssembly assembly)
            => assembly.WithOSArchitecture(Architecture.X86);

        /// <summary>
        /// The given assembly should be loaded on x64 platform.
        /// </summary>
        public static IConditionalAssembly WithX64(this IConditionalAssembly assembly)
            => assembly.WithOSArchitecture(Architecture.X64);

        /// <summary>
        /// The given assembly should be loaded on ARM64 platform.
        /// </summary>
        public static IConditionalAssembly WithArm64(this IConditionalAssembly assembly)
            => assembly.WithOSArchitecture(Architecture.Arm64);

        private static IConditionalAssembly WithOSArchitecture(this IConditionalAssembly assembly, Architecture arch)
        {
            assembly.UpdateShouldLoad(assembly.Context.OSArchitecture.Equals(arch));
            return assembly;
        }
    }
}
