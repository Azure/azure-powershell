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

namespace Microsoft.AzureStack.Commands
{
    using Microsoft.AzureStack.Management;
    using Microsoft.AzureStack.Management.Models;
    using System;
    using System.Linq;
    using System.Management.Automation;

    /// <summary>
    /// Add Resource Provider Registration Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Add, Nouns.ResourceProviderRegistration, DefaultParameterSetName = CommonPSConst.ParameterSet.ByProperty)]
    [OutputType(typeof(ProviderRegistrationModel))]
    public class AddResourceProviderRegistration : SetResourceProviderRegistration
    {
        /// <summary>
        /// Validates the prerequisites.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <param name="parameters">The parameters.</param>
        protected override void ValidatePrerequisites(AzureStackClient client, ProviderRegistrationCreateOrUpdateParameters parameters)
        {
            ArgumentValidator.ValidateNotNull("client", client);
            ArgumentValidator.ValidateNotNull("parameters", parameters);

            client.ResourceGroups.CreateOrUpdate(new ResourceGroupCreateOrUpdateParameters()
            {
                ResourceGroup = new ResourceGroupDefinition()
                {
                    Location = this.ArmLocation,
                    Name = this.ResourceGroup,
                }
            });

            var name = parameters.ProviderRegistration.Properties.Name;
            var location = parameters.ProviderRegistration.Properties.Location;

            if (client.ProviderRegistrations.List(this.ResourceGroup).ProviderRegistrations
                .Any(p =>
                    string.Equals(p.Properties.Manifest.Namespace, name, StringComparison.OrdinalIgnoreCase)
                    && string.Equals(p.Properties.Location, location, StringComparison.OrdinalIgnoreCase)))
            {
                throw new PSInvalidOperationException(Resources.ProviderRegistrationAlreadyExists.FormatArgs(name, location));
            }
        }
    }
}
