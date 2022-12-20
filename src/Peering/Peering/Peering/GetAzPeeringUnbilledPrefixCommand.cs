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

using Track2Peering = Azure.ResourceManager.Peering;

namespace Microsoft.Azure.PowerShell.Cmdlets.Peering.Peering
{
    using System;
    using System.Linq;
    using System.Management.Automation;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

    using Microsoft.Azure.Commands.Peering.Properties;

    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Common;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

    /// <inheritdoc />
    /// <summary>
    ///  The Get Az InputObject cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, Constants.AzPeeringUnbilledPrefix,
        DefaultParameterSetName = Constants.ParameterSetNameByResourceAndName)]
    [OutputType(typeof(PSUnbilledPrefix))]
    public class GetAzPeeringUnbilledPrefixCommand : PeeringBaseCmdlet
    {

        /// <summary>
        ///     Gets or sets the ResourceGroupName
        /// </summary>
        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = Constants.ResourceGroupNameHelp,
            ParameterSetName = Constants.ParameterSetNameByResourceAndName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = Constants.PeeringNameHelp,
            ParameterSetName = Constants.ParameterSetNameByResourceAndName)]
        public string Name { get; set; }

        /// <summary>
        /// The resource  id
        /// </summary>
        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = Constants.ResourceIdHelp,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = Constants.ParameterSetNameByResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <inheritdoc />
        /// <summary>
        ///  The base execute method.
        /// </summary>
        public override void Execute()
        {
            base.Execute();
            try
            {
                if (string.Equals(this.ParameterSetName, Constants.ParameterSetNameByResourceId))
                {
                    var resourceId = new ResourceIdentifier(this.ResourceId);
                    this.ResourceGroupName = resourceId.ResourceGroupName;
                    this.Name = resourceId.ResourceName;
                }
                var list = this.ListUnbilledPrefixes();
                this.WriteObject(list, true);
            }
            catch (InvalidOperationException mapException)
            {
                throw new InvalidOperationException(string.Format(Resources.Error_Mapping, mapException));
            }
        }

        /// <summary>
        /// The list of unbilled prefixes for this peering.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        private object ListUnbilledPrefixes()
        {
            try
            {
                var subscriptionId = this.DefaultProfile.DefaultContext.Subscription.Id;
                var resourceId = Track2Peering.PeeringResource.CreateResourceIdentifier(subscriptionId, ResourceGroupName, Name);
                var peeringResourceClient = Track2Peering.PeeringExtensions.GetPeeringResource(this.ArmClient, resourceId);
                var list = peeringResourceClient.GetRpUnbilledPrefixes();

                if (list != null)
                {
                    return list.Select(this.ToPSUnbilledPrefix).ToList();
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
