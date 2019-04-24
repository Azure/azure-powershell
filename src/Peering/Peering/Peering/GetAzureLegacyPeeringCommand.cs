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
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;

    using Microsoft.Azure.Commands.Peering.Properties;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Peering;
    using Microsoft.Azure.Management.Peering.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Common;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Models;

    using Newtonsoft.Json;

    /// <inheritdoc />
    /// <summary>
    ///     The Get Az InputObject Legacy peering.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzLegacyPeering")]
    [OutputType(typeof(PSPeering))]
    public class GetAzureLegacyPeeringCommand : PeeringBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the PeeringLocation.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, HelpMessage = Constants.KindHelp)]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter(Constants.Direct, Constants.Exchange)]
        public string PeeringLocation { get; set; }

        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, HelpMessage = Constants.KindHelp)]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter(Constants.Direct, Constants.Exchange)]
        public string Kind { get; set; }

        /// <inheritdoc />
        /// <summary>
        ///     The base execute method.
        /// </summary>
        public override void Execute()
        {
            base.Execute();
            var psPeeringions = this.PeeringByLegacyPeering();
            this.WriteObject(psPeeringions, true);
        }

        /// <summary>
        /// The peering by legacy peering.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        /// <exception cref="ErrorResponseException">Http Response 
        /// </exception>
        private object PeeringByLegacyPeering()
        {
            try
            {
                var icList = this.PeeringLegacyClient.List(this.PeeringLocation, this.Kind);
                return icList.Select(this.ToPeeringPs).ToList();
            }
            catch (ErrorResponseException ex)
            {
                                var error = ex.Response.Content.Contains("\"error\\\":") ? JsonConvert.DeserializeObject<Dictionary<string, ErrorResponse>>(JsonConvert.DeserializeObject(ex.Response.Content).ToString()).FirstOrDefault().Value : JsonConvert.DeserializeObject<ErrorResponse>(ex.Response.Content);
                throw new ErrorResponseException(string.Format(Resources.Error_CloudError, error.Code, error.Message));
            }
        }
    }
}