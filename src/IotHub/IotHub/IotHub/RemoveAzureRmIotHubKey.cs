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
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Management.Automation;
    using System.Linq;
    using Microsoft.Azure.Commands.Management.IotHub.Common;
    using Microsoft.Azure.Commands.Management.IotHub.Models;
    using Microsoft.Azure.Management.IotHub;
    using Microsoft.Azure.Management.IotHub.Models;
    using PSIotHubProperties = Microsoft.Azure.Commands.Management.IotHub.Properties;
    using ResourceManager.Common.ArgumentCompleters;

    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IotHubKey", DefaultParameterSetName = ResourceParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSSharedAccessSignatureAuthorizationRule))]
    public class RemoveAzureRmIotHubKey : IotHubBaseCmdlet
    {
        private const string ResourceIdParameterSet = "ResourceIdSet";
        private const string ResourceParameterSet = "ResourceSet";

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "IotHub Resource Id")]
        [ValidateNotNullOrEmpty]
        public string HubId { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ResourceParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the Resource Group")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = ResourceParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the Iot Hub")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }


        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = ResourceIdParameterSet,
            HelpMessage = "Name of the Key")]
        [Parameter(
            Position = 2,
            Mandatory = true,
            ParameterSetName = ResourceParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the Key")]
        [ValidateNotNullOrEmpty]
        public string KeyName { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(KeyName, Properties.Resources.RemoveIotHubKey))
            {
                if (ParameterSetName.Equals(ResourceIdParameterSet))
                {
                    this.ResourceGroupName = IotHubUtils.GetResourceGroupName(this.HubId);
                    this.Name = IotHubUtils.GetIotHubName(this.HubId);
                }

                IotHubDescription iothubDesc = this.IotHubClient.IotHubResource.Get(this.ResourceGroupName, this.Name);
                IList<SharedAccessSignatureAuthorizationRule> authRules = (List<SharedAccessSignatureAuthorizationRule>)this.IotHubClient.IotHubResource.ListKeys(this.ResourceGroupName, this.Name).ToList();

                foreach (var authRule in authRules)
                {
                    if (authRule.KeyName.Equals(this.KeyName, StringComparison.OrdinalIgnoreCase))
                    {
                        authRules.Remove(authRule);
                        break;
                    }
                }

                iothubDesc.Properties.AuthorizationPolicies = authRules;

                this.IotHubClient.IotHubResource.CreateOrUpdate(this.ResourceGroupName, this.Name, iothubDesc);
                IEnumerable<SharedAccessSignatureAuthorizationRule> updatedAuthRules = this.IotHubClient.IotHubResource.ListKeys(this.ResourceGroupName, this.Name);
                this.WriteObject(IotHubUtils.ToPSSharedAccessSignatureAuthorizationRules(updatedAuthRules), true);
            }
        }
    }
}
