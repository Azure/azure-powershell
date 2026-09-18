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

using AutoMapper;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using CNM = Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DdosCustomPolicy"), OutputType(typeof(PSDdosCustomPolicy))]
    public partial class GetAzureRmDdosCustomPolicy : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "Specifies the name of the DDoS custom policy resource group.",
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "Specifies the name of the DDoS custom policy.",
            ValueFromPipelineByPropertyName = true)]
        [ResourceNameCompleter("Microsoft.Network/ddosCustomPolicies", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void Execute()
        {
            base.Execute();

            var vDdosCustomPolicy = this.NetworkClient.NetworkManagementClient.DdosCustomPolicies.Get(ResourceGroupName, Name);
            var vDdosCustomPolicyModel = NetworkResourceManagerProfile.Mapper.Map<CNM.PSDdosCustomPolicy>(vDdosCustomPolicy);
            vDdosCustomPolicyModel.ResourceGroupName = this.ResourceGroupName;
            vDdosCustomPolicyModel.Tag = TagsConversionHelper.CreateTagHashtable(vDdosCustomPolicy.Tags);
            WriteObject(vDdosCustomPolicyModel, true);
        }
    }
}
