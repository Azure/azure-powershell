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

namespace Microsoft.Azure.PowerShell.AssemblyLoading
{
    /// <summary>
    /// Represents a dependency assembly of Az modules.
    /// </summary>
    public interface IConditionalAssembly
    {
        /// <summary>
        /// Whether the assembly should be loaded given the constraints it comes with
        /// and the current <see cref="Context"/>.
        /// </summary>
        bool ShouldLoad { get; }

        /// <summary>
        /// Name of the assembly. Should be its file name without extension.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Path to the assembly file.
        /// </summary>
        string Path { get; }

        /// <summary>
        /// Assembly version.
        /// </summary>
        Version Version { get; }

        /// <summary>
        /// Context with information about the current environment.
        /// Used to calculate if this assembly should be loaded.
        /// </summary>
        IConditionalAssemblyContext Context { get; }

        /// <summary>
        /// Update <see cref="ShouldLoad"/>.
        /// </summary>
        /// <remarks>
        /// This method shortcuts, meaning if <see cref="ShouldLoad"/> is false, it can never be updated.
        /// </remarks>
        /// <param name="shouldLoad">The new value of <see cref="ShouldLoad"/></param>
        void UpdateShouldLoad(bool shouldLoad);
    }
}
