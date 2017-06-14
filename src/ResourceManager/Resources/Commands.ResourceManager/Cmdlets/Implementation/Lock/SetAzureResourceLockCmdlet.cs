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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    using System.Management.Automation;

    /// <summary>
    /// The set resource lock cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmResourceLock", SupportsShouldProcess = true, DefaultParameterSetName = ResourceLockManagementCmdletBase.ScopeLevelLock), OutputType(typeof(PSObject))]
    public class SetAzureResourceLockCmdlet : NewAzureResourceLockCmdlet
    {
        /// <summary>
        /// Gets the action message.
        /// </summary>
        /// <param name="resourceId">The resource Id.</param>
        protected override string GetActionMessage(string resourceId)
        {
            return "Are you sure you want to update the following lock: " + resourceId;
        }

        /// <summary>
        /// Gets the process message.
        /// </summary>
        protected override string GetProccessMessage()
        {
            return "Updating the lock.";
        }
    }
}