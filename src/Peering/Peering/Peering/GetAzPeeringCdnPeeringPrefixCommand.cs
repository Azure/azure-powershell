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
using System.Linq;
using System.Management.Automation;

using Microsoft.Azure.Commands.Peering.Properties;
using Microsoft.Azure.Management.Peering;
using Microsoft.Azure.Management.Peering.Models;
using Microsoft.Azure.PowerShell.Cmdlets.Peering.Common;
using Microsoft.Azure.PowerShell.Cmdlets.Peering.Models;

namespace Microsoft.Azure.PowerShell.Cmdlets.Peering.Peering
{
    /// <inheritdoc />
    /// <summary>
    ///  The Get Az InputObject cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, Constants.AzPeeringCdnPeeringPrefix)]
    [OutputType(typeof(PSCdnPeeringPrefix))]
    public class GetAzPeeringCdnPeeringPrefixCommand : PeeringBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the PeeringLocation.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, HelpMessage = Constants.PeeringLocationForCdnPrefixesHelp)]
        [ValidateNotNullOrEmpty]
        public string PeeringLocation { get; set; }

        /// <inheritdoc />
        /// <summary>
        ///  The base execute method.
        /// </summary>
        public override void Execute()
        {
            base.Execute();
            var cdnPeeringPrefixes = this.ListCdnPeeringPrefixes();
            this.WriteObject(cdnPeeringPrefixes, true);
        }

        /// <summary>
        /// The list of cdn peering prefixes.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        /// <exception cref="ErrorResponseException">Http Response
        /// </exception>
        private object ListCdnPeeringPrefixes()
        {
            try
            {
                var icList = this.CdnPeeringPrefixesOperationsClient.List(this.PeeringLocation);
                if (icList != null)
                {
                    return icList.Select(this.ToPSCdnPeeringPrefix).ToList();
                }
                return icList;
            }
            catch (ErrorResponseException ex)
            {
                var error = this.GetErrorCodeAndMessageFromArmOrErm(ex);
                throw new ErrorResponseException(string.Format(Resources.Error_CloudError, error.Code, error.Message));
            }
        }
    }
}