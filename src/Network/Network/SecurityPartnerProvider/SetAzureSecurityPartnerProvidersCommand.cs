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

using System;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SecurityPartnerProvider", SupportsShouldProcess = true), OutputType(typeof(PSSecurityPartnerProvider))]
    public class SetAzureSecurityPartnerProvidersCommand : SecurityPartnerProviderBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The SecurityPartnerProvider")]
        public PSSecurityPartnerProvider SecurityPartnerProvider { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (!this.IsSecurityPartnerProviderPresent(this.SecurityPartnerProvider.ResourceGroupName, this.SecurityPartnerProvider.Name))
            {
                throw new ArgumentException(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound);
            }

            // Map to the sdk object
            var securityPartnerProviderModel = NetworkResourceManagerProfile.Mapper.Map<MNM.SecurityPartnerProvider>(this.SecurityPartnerProvider);
            securityPartnerProviderModel.Tags = TagsConversionHelper.CreateTagDictionary(this.SecurityPartnerProvider.Tag, validate: true);

            // Execute the PUT SecurityPartnerProvider call
            this.SecurityPartnerProviderClient.CreateOrUpdate(this.SecurityPartnerProvider.ResourceGroupName, this.SecurityPartnerProvider.Name, securityPartnerProviderModel);

            var getSecurityPartnerProvider = this.GetSecurityPartnerProvider(this.SecurityPartnerProvider.ResourceGroupName, this.SecurityPartnerProvider.Name);
            WriteObject(getSecurityPartnerProvider);
        }
    }
}
