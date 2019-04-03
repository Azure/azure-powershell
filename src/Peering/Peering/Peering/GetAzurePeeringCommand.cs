// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Microsoft" file="GetAzurePeeringCommand.cs">
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//  http://www.apache.org/licenses/LICENSE-2.0
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Microsoft.Azure.PowerShell.Cmdlets.Peering.Peering
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;

    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Peering;
    using Microsoft.Azure.Management.Peering.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Common;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Models;

    /// <inheritdoc />
    /// <summary>
    ///     The Get Az InputObject cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzPeering", DefaultParameterSetName = Constants.ParameterSetNameBySubscription)]
    [OutputType(typeof(PSPeering))]
    public class GetAzurePeeringCommand : PeeringBaseCmdlet
    {
        /// <summary>
        ///     Gets or sets the InputObject name.
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.PeeringNameHelp,
            ParameterSetName = Constants.ParameterSetNamePeeringByResourceAndName)]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        /// <summary>
        ///     Gets or sets the ResourceGroupName
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.ResourceGroupNameHelp,
            ParameterSetName = Constants.ParameterSetNameBySubscription)]
        [Parameter(
            Mandatory = true,
            HelpMessage = Constants.ResourceGroupNameHelp,
            ParameterSetName = Constants.ParameterSetNamePeeringByResourceAndName)]
        [Parameter(
            Position = Constants.PositionPeeringZero,
            Mandatory = true,
            HelpMessage = Constants.ResourceGroupNameHelp,
            ParameterSetName = Constants.ParameterSetNamePeeringByResource)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        /// <summary>
        ///     Gets or sets the Kind of InputObject
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.KindHelp,
            ParameterSetName = Constants.ParameterSetNamePeeringByResource)]
        [Parameter(
            Mandatory = true,
            HelpMessage = Constants.KindHelp,
            ParameterSetName = Constants.ParameterSetNamePeeringByKind)]
        [PSArgumentCompleter(Constants.Direct, Constants.Partner, Constants.Exchange)]
        [ValidateSet(Constants.Direct, Constants.Partner, Constants.Exchange, IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public virtual string Kind { get; set; }

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
                    Constants.ParameterSetNamePeeringByResourceAndName,
                    StringComparison.OrdinalIgnoreCase))
                {
                    var resourceAndName = this.GetPeeringByResourceAndName();
                    this.WriteObject(resourceAndName, true);
                }
                else if (string.Equals(
                    this.ParameterSetName,
                    Constants.ParameterSetNamePeeringByResource,
                    StringComparison.OrdinalIgnoreCase))
                {
                    var resource = this.GetPeeringByResource();
                    this.WriteObject(resource, true);
                }
                else if (this.ParameterSetName.Contains(Constants.ParameterSetNamePeeringByKind))
                {
                    var byKind = this.GetPeeringByKind();
                    this.WriteObject(byKind, true);
                }
                else
                {
                    var bySubscription = this.GetPeeringBySubscription();
                    this.WriteObject(bySubscription, true);
                }
            }
            catch (InvalidOperationException mapException)
            {
                throw new InvalidOperationException($"Failed to map object {mapException}");
            }
            catch (ErrorResponseException ex)
            {
                throw new ErrorResponseException($"Error:{ex.Response.ReasonPhrase} reason:{ex.Body.Code} message:{ex.Body.Message}");
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
            foreach (var psIc in ics)
                if (icList.FirstOrDefault()?.Kind == this.Kind)
                {
                    if (string.Equals(Constants.Exchange, this.Kind, StringComparison.InvariantCultureIgnoreCase))
                    {
                        kindPeering.Add(new PSExchangePeeringModelView((PSPeering)psIc));
                    }
                    if (string.Equals(Constants.Direct, this.Kind, StringComparison.InvariantCultureIgnoreCase))
                    {
                        kindPeering.Add(new PSDirectPeeringModelView((PSPeering)psIc));
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
            var ics = icList.Select(this.ToPeeringPs).ToList();

            var kindPeering = new List<object>();
            foreach (var peer in ics)
                if (icList.FirstOrDefault()?.Kind == this.Kind)
                {
                    if (peer.Exchange != null)
                    {
                        kindPeering.Add(new PSExchangePeeringModelView(peer));
                    }

                    if (peer.Direct != null)
                    {
                        kindPeering.Add(new PSDirectPeeringModelView(peer));
                    }
                }
                else
                {
                    if (peer.Exchange != null)
                    {
                        kindPeering.Add(new PSExchangePeeringModelView(peer));
                    }

                    if (peer.Direct != null)
                    {
                        kindPeering.Add(new PSDirectPeeringModelView(peer));
                    }
                }

            return kindPeering;
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
                return (object)obj;
            }

            if (peer.Direct != null)
            {
                var obj = new PSDirectPeeringModelView(peer);
                return (object)obj;
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