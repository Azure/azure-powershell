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
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Management.IotHub.Common;
    using Microsoft.Azure.Commands.Management.IotHub.Models;
    using Microsoft.Azure.Management.IotHub;
    using Microsoft.Azure.Management.IotHub.Models;

    [Cmdlet(VerbsCommon.Get, "AzureRmIotHubKey")]
    [OutputType(typeof(PSSharedAccessSignatureAuthorizationRule), typeof(List<PSSharedAccessSignatureAuthorizationRule>))]
    public class GetAzureRmIotHubKey : IotHubBaseCmdlet
    {
        const string GetIotHubKeyParameterSet = "GetIotHubKey";
        const string ListIotHubKeysParameterSet = "ListIotHubKeys";

        [Parameter(
            Position = 0,
            ParameterSetName = GetIotHubKeyParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the Resource Group")]
        [Parameter(
            Position = 0,
            ParameterSetName = ListIotHubKeysParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the Resource Group")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            ParameterSetName = GetIotHubKeyParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the Iot Hub")]
        [Parameter(
            Position = 1,
            ParameterSetName = ListIotHubKeysParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the Iot Hub")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            ParameterSetName = GetIotHubKeyParameterSet,
            Mandatory = true,
            HelpMessage = "Name of the Key")]
        [ValidateNotNullOrEmpty]
        public string KeyName { get; set; }

        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case GetIotHubKeyParameterSet:
                    SharedAccessSignatureAuthorizationRule authPolicy = this.IotHubClient.IotHubResource.GetKeysForKeyName(this.ResourceGroupName, this.Name, this.KeyName);
                    this.WriteObject(IotHubUtils.ToPSSharedAccessSignatureAuthorizationRule(authPolicy), false);
                    break;
                case ListIotHubKeysParameterSet:
                    IEnumerable<SharedAccessSignatureAuthorizationRule> authPolicies = this.IotHubClient.IotHubResource.ListKeys(this.ResourceGroupName, this.Name);
                    this.WriteObject(IotHubUtils.ToPSSharedAccessSignatureAuthorizationRules(authPolicies), true);
                    break;
                default:
                    throw new ArgumentException("BadParameterSetName");
            }
        }
    }
}
