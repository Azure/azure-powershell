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

namespace AzDev.Models.Assembly
{
    /// <summary>
    /// Represents an assembly managed directly by developers.
    /// </summary>
    internal class DevAssembly
    {
        /// <summary>
        /// The name of the nuget package. It is also the name of the assembly.
        /// </summary>
        public string PackageName { get; set; }

        /// <summary>
        /// The version of the nuget package. It is NOT the assembly version nor the file version.
        /// </summary>
        public string PackageVersion { get; set; }

        /// <summary>
        /// The target framework of the assembly, e.g. netstandard2.0, net471.
        /// </summary>
        public string TargetFramework { get; set; }

        /// <summary>
        /// Whether to copy the runtime assemblies to the output directory. This is necessary when the assembly has extra runtime dependencies.
        /// </summary>
        public bool CopyRuntimeAssemblies { get; set; } = false;

        /// <summary>
        /// Whether to use the assembly in Windows PowerShell.
        /// </summary>
        public bool WindowsPowerShell { get; set; }

        /// <summary>
        /// Whether to use the assembly in PowerShell 7+.
        /// </summary>
        public bool PowerShell7Plus { get; set; }
    }
}
