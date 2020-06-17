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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.PowerShell.Cmdlets.Peering.Common;
using Microsoft.Azure.PowerShell.Cmdlets.Peering.Models;

namespace Microsoft.Azure.PowerShell.Cmdlets.Peering.PeerAsn
{
    /// <summary>
    ///     New Azure InputObject Command-let
    /// </summary>
    [Cmdlet(VerbsCommon.New, Constants.AzPeerAsnContactDetail, DefaultParameterSetName = Constants.ParameterSetNameDefault)]
    [OutputType(typeof(PSContactDetail))]
    public class NewPeerAsnContactDetailCommand : PeeringBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = Constants.RoleHelp, ParameterSetName = Constants.ParameterSetNameDefault)]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter(Models.Role.Noc, Models.Role.Service, Models.Role.Escalation, Models.Role.Technical, Models.Role.Policy, Models.Role.Other)]
        public string Role { get; set; }

        /// <summary>
        ///     Gets or sets the Email
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = Constants.EmailsHelp, ParameterSetName = Constants.ParameterSetNameDefault)]
        [ValidateNotNullOrEmpty]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = Constants.PhoneHelp, ParameterSetName = Constants.ParameterSetNameDefault)]
        public string Phone { get; set; }

        /// <summary>
        ///     The inherited Execute function.
        /// </summary>
        public override void Execute()
        {
            base.Execute();
            if (HelperExtensionMethods.IsValidEmail(this.Email))
                this.WriteObject(new PSContactDetail(this.Role, this.Email, this.Phone));

        }
    }
}