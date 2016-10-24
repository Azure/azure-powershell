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

namespace Microsoft.Azure.Commands.Management.IotHub
{
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Linq;
    using Microsoft.Azure.Commands.Management.IotHub.Common;
    using Microsoft.Azure.Commands.Management.IotHub.Models;
    using Microsoft.Azure.Management.IotHub;
    using Microsoft.Azure.Management.IotHub.Models;

    [Cmdlet(VerbsCommon.Add, "AzureRmIotHubKey")]
    [OutputType(typeof(PSSharedAccessSignatureAuthorizationRule), typeof(List<PSSharedAccessSignatureAuthorizationRule>))]
    public class AddAzureRmIotHubKey : IotHubBaseCmdlet
    {

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the Resource Group")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the Iot Hub")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Name of the Key")]
        [ValidateNotNullOrEmpty]
        public string KeyName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "PrimaryKey")]
        [ValidateNotNullOrEmpty]
        public string PrimaryKey { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "SecondaryKey")]
        [ValidateNotNullOrEmpty]
        public string SecondaryKey { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Access Rights")]
        [ValidateNotNullOrEmpty]
        public PSAccessRights Rights { get; set; }

        public override void ExecuteCmdlet()
        {
            var psAuthRule = new PSSharedAccessSignatureAuthorizationRule()
            {
                KeyName = this.KeyName,
                PrimaryKey = this.PrimaryKey,
                SecondaryKey = this.SecondaryKey,
                Rights = this.Rights
            };

            var authRule = IotHubUtils.ToSharedAccessSignatureAuthorizationRule(psAuthRule);

            IotHubDescription iothubDesc = this.IotHubClient.IotHubResource.Get(this.ResourceGroupName, this.Name);
            IList<SharedAccessSignatureAuthorizationRule> authRules = (List<SharedAccessSignatureAuthorizationRule>) this.IotHubClient.IotHubResource.ListKeys(this.ResourceGroupName, this.Name).ToList();
            authRules.Add(authRule);
            iothubDesc.Properties.AuthorizationPolicies = authRules;

            this.IotHubClient.IotHubResource.CreateOrUpdate(this.ResourceGroupName, this.Name, iothubDesc);
            IEnumerable<SharedAccessSignatureAuthorizationRule> updatedAuthRules = this.IotHubClient.IotHubResource.ListKeys(this.ResourceGroupName, this.Name);
            this.WriteObject(IotHubUtils.ToPSSharedAccessSignatureAuthorizationRules(updatedAuthRules), true);
        }
    }
}
