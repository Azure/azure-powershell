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
    using Microsoft.Azure.Management.Peering;
    using Microsoft.Azure.Management.Peering.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Common;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Models;

    /// <summary>
    /// The get azure peering service provider command.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, Constants.AzPeeringServiceProvider)]
    [OutputType(typeof(PSPeeringServiceProvider))]
    public class GetAzurePeeringServiceProviderCommand : PeeringBaseCmdlet
    {
        /// <summary>
        /// The execute.
        /// </summary>
        public override void Execute()
        {
            base.Execute();
            var psPeeringions = this.GetPeeringServiceProvider();
            this.WriteObject(psPeeringions, true);
        }

        /// <summary>
        /// The get peering service provider.
        /// </summary>
        /// <returns>
        /// The <see cref="List{PSPeeringServiceProvider}"/>.
        /// </returns>
        /// <exception cref="ErrorResponseException">
        /// </exception>
        private List<PSPeeringServiceProvider> GetPeeringServiceProvider()
        {
            try
            {
                var icList = this.PeeringServiceProvidersClient.List();
                return icList.Select(this.ToPeeringServiceProviderPS).ToList();
            }
            catch (ErrorResponseException ex)
            {
                var error = this.GetErrorCodeAndMessageFromArmOrErm(ex);
                throw new ErrorResponseException(string.Format(Resources.Error_CloudError, error.Code, error.Message));
            }
        }
    }
}