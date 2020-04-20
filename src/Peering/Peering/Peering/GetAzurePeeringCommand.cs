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
namespace Microsoft.Azure.PowerShell.Cmdlets.Peering.Peering
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;

    using Microsoft.Azure.Commands.Peering.Properties;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Peering;
    using Microsoft.Azure.Management.Peering.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Common;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Models;

    /// <inheritdoc />
    /// <summary>
    ///     The Get Az InputObject cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, Constants.AzPeering,
        DefaultParameterSetName = Constants.ParameterSetNameBySubscription)]
    [OutputType(typeof(PSPeering))]
    public class GetAzurePeeringCommand : PeeringBaseCmdlet
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
            Mandatory = false,
            HelpMessage = Constants.PeeringNameHelp,
            ParameterSetName = Constants.ParameterSetNameByResourceAndName)]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the Kind
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.KindHelp,
            ParameterSetName = Constants.ParameterSetNameBySubscription)]
        [PSArgumentCompleter(Constants.Direct, Constants.Partner, Constants.Exchange)]
        public string Kind { get; set; }

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
        ///     Execute Override for powershell cmdlet
        /// </summary>
        public override void Execute()
        {
            base.Execute();
            try
            {
                if (string.Equals(
                    this.ParameterSetName,
                    Constants.ParameterSetNameByResourceAndName,
                    StringComparison.OrdinalIgnoreCase))
                {
                    if (this.Name != null)
                    {
                        var item = this.GetPeeringByResourceAndName();
                        this.WriteObject(item);
                    }
                    else
                    {
                        var list = this.GetPeeringByResource();
                        this.WriteObject(list, true);
                    }
                }
                else if (string.Equals(this.ParameterSetName, Constants.ParameterSetNameByResourceId))
                {
                    var resourceId = new ResourceIdentifier(this.ResourceId);
                    this.ResourceGroupName = resourceId.ResourceGroupName;
                    this.Name = resourceId.ResourceName;
                    this.WriteObject(this.GetPeeringByResourceAndName());
                }
                else
                {
                    var list = this.Kind != null ? this.GetPeeringByKind() : this.GetPeeringBySubscription();
                    this.WriteObject(list);
                }
            }
            catch (InvalidOperationException mapException)
            {
                throw new InvalidOperationException(string.Format(Resources.Error_Mapping, mapException));
            }
            catch (ErrorResponseException ex)
            {
                var error = GetErrorCodeAndMessageFromArmOrErm(ex);
                throw new ErrorResponseException(string.Format(Resources.Error_CloudError, error.Code, error.Message));
            }
        }

        /// <summary>
        ///     Gets InputObject by its Kind
        /// </summary>
        /// <returns>List of InputObject resources</returns>
        public List<object> GetPeeringByKind()
        {
            var ics = new List<object>();
            var icList = this.PeeringClient.ListBySubscription();
            ics.AddRange(icList.Select(this.ToPeeringPs));
            var kindPeering = new List<object>();
            foreach (PSPeering psIc in ics)
                if (psIc.Kind.Equals(this.Kind, StringComparison.CurrentCultureIgnoreCase))
                {
                    if (string.Equals(Constants.Exchange, this.Kind, StringComparison.InvariantCultureIgnoreCase))
                    {
                        kindPeering.Add(new PSExchangePeeringModelView(psIc));
                    }

                    if (string.Equals(Constants.Direct, this.Kind, StringComparison.InvariantCultureIgnoreCase))
                    {
                        kindPeering.Add(new PSDirectPeeringModelView(psIc));
                    }
                }

            return kindPeering;
        }

        /// <summary>
        ///     Gets InputObject Resource by ResourceGroupName
        /// </summary>
        /// <returns>List of InputObject Resources</returns>
        public List<object> GetPeeringByResource()
        {
            var icList = this.PeeringClient.ListByResourceGroup(this.ResourceGroupName);
            var peering = icList.Select(this.ToPeeringPs).ToList();
            List<object> psList = new List<object>();
            foreach (var peer in peering)
            {
                if (peer.Exchange != null)
                {
                    psList.Add(new PSExchangePeeringModelView(peer));
                }

                if (peer.Direct != null)
                {
                    psList.Add(new PSDirectPeeringModelView(peer));
                }
            }

            return psList;
        }

        /// <summary>
        ///     Gets the InputObject Resource by ResourceGroupName and InputObject Name
        /// </summary>
        /// <returns>InputObject Resource</returns>
        public object GetPeeringByResourceAndName()
        {
            var ic = this.PeeringClient.Get(this.ResourceGroupName, this.Name);
            var peer = this.ToPeeringPs(ic);
            if (peer.Exchange != null)
            {
                var obj = new PSExchangePeeringModelView(peer);
                return obj;
            }

            if (peer.Direct != null)
            {
                var obj = new PSDirectPeeringModelView(peer);
                return obj;
            }

            return null;
        }

        /// <summary>
        ///     Gets all InputObject for a subscription.
        /// </summary>
        /// <returns>List of all InputObject for a subscription</returns>
        public List<object> GetPeeringBySubscription()
        {
            var icList = this.PeeringClient.ListBySubscription();
            var peering = icList.Select(this.ToPeeringPs).ToList();
            List<object> psList = new List<object>();
            foreach (var peer in peering)
            {
                if (peer.Exchange != null)
                {
                    psList.Add(new PSExchangePeeringModelView(peer));
                }

                if (peer.Direct != null)
                {
                    psList.Add(new PSDirectPeeringModelView(peer));
                }
            }

            return psList;
        }
    }
}