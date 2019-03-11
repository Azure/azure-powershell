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

using System.Management.Automation;

namespace Microsoft.Azure.Commands.Common
{
    /// <summary>
    /// Extnesion methods for PSCmdlet
    /// </summary>
    internal static class PSModuleExtensions
    {
        /// <summary>
        /// Generate module class for a given PS Cmdlet
        /// </summary>
        /// <param name="cmdlet">The cmdlet</param>
        /// <returns>AN AzModule class for the given cmdlet</returns>
        internal static AzModule GetModule(this PSCmdlet cmdlet)
        {
            return new AzModule(cmdlet.CommandRuntime);
        }
    }

}
