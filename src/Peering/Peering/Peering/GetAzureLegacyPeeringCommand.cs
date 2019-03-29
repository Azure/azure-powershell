// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Microsoft" file="GetAzureLegacyPeeringCommand.cs">
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Microsoft.Azure.PowerShell.Cmdlets.Peering.Peering
{
    using System;
    using System.Linq;
    using System.Management.Automation;

    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Peering;
    using Microsoft.Azure.Management.Peering.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Common;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Models;

    /// <inheritdoc />
    /// <summary>
    ///     The Get Az Peering Legacy peering.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzLegacyPeering")]
    [OutputType(typeof(PSPeering))]
    public class GetAzureLegacyPeeringCommand : PeeringBaseCmdlet
    {

        /// <summary>
        /// Gets or sets the PeeringLocation.
        /// </summary>
        [Parameter(
            Mandatory = true,
            Position = Constants.PositionPeeringZero,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.KindHelp)]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter(Constants.Direct, Constants.Exchange)]
        public virtual string PeeringLocation { get; set; }

        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        [Parameter(
            Mandatory = true,
            Position = Constants.PositionPeeringOne,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.KindHelp)]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter(Constants.Direct, Constants.Exchange)]
        public virtual string Kind { get; set; }

        /// <inheritdoc />
        /// <summary>
        ///     The base execute method.
        /// </summary>
        public override void Execute()
        {
            base.Execute();
            var psPeeringions = this.PeeringByLegacyPeering;
            this.WriteObject(psPeeringions, true);
        }

        /// <summary>
        ///     Gets the legacy peering associated with the subscription.
        /// </summary>
        /// <returns></returns>
        public object PeeringByLegacyPeering
        {
            get
            {
                try
                {
                    var icList = this.PeeringLegacyClient.List(this.PeeringLocation, this.Kind);

                    return icList.Select(this.ToPeeringPs).ToList();
                }
                catch (ErrorResponseException ex)
                {
                    throw new Exception($"Error:{ex.Response.ReasonPhrase} reason:{ex.Body.Code} message:{ex.Body.Message}");
                }
            }
        }
    }
}