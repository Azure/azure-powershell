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

namespace Microsoft.Azure.Commands.Intune.Flagged
{
    using Management.Intune;
    using Management.Intune.Models;
    using System.Management.Automation;

    /// <summary>
    /// Cmdlet to get the MAM summary status.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmIntuneMAMStatus"), OutputType(typeof(StatusesDefault))]
    public sealed class GetIntuneMAMStatusCmdlet : IntuneBaseCmdlet
    {
        /// <summary>
        /// Contains the cmdlet's execution logic.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            GetMAMDefaultStatus();
        }

        /// <summary>
        /// Get MAM summary status
        /// </summary>
        private void GetMAMDefaultStatus()
        {
            var result = IntuneClient.GetMAMStatuses(this.AsuHostName);
            this.WriteObject(result);
        }
    }
}