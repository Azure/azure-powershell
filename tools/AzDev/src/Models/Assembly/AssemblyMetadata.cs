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

namespace AzDev.Models.Assembly
{
    /// <summary>
    /// Represents an assembly managed by the runtime.
    /// This is used to hold the metadata that are useful at runtime, or unavailable at dev time.
    /// </summary>
    internal class RuntimeAssembly
    {
        /// <summary>
        /// Name of the assembly.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Assembly version. This is the version of the assembly, not the nuget package.
        /// </summary>
        public Version Version { get; set; }

        /// <summary>
        /// Target framework of the assembly, e.g. netstandard2.0, net471.
        /// </summary>
        public string TargetFramework { get; set; }
    }
}
