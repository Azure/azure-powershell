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
    /// Context with information about the current environment.
    /// Used to calculate if this assembly should be loaded.
    /// </summary>
    public interface IConditionalAssemblyContext
    {
        /// <summary>
        /// Edition of PowerShell, "Desktop" or "Core".
        /// </summary>
        string PSEdition { get; }

        /// <summary>
        /// Version of PowerShell. For example "5.1.22621.608".
        /// </summary>
        Version PSVersion { get; }

        /// <summary>
        /// Returns if the current operating system matches <paramref name="os"/>.
        /// </summary>
        /// <param name="os">The expected operating system</param>
        bool IsOSPlatform(OSPlatform os);

        /// <summary>
        /// OS Architecture. For example "X86".
        /// </summary>
        /// <value></value>
        Architecture OSArchitecture { get; }
    }
}
