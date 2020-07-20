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

using System.Management.Automation;
using Microsoft.Azure.Commands.Cdn.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Collections.Generic;
using System;
using Microsoft.Azure.Commands.Cdn.Models.OriginGroup;
using Microsoft.Azure.Management.Cdn;

namespace Microsoft.Azure.Commands.Cdn.OriginGroups
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CdnOriginGroup", SupportsShouldProcess = true, DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSOriginGroup))]
    public class NewAzCdnOriginGroup : AzureCdnCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = "Azure CDN endpoint name.", ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string EndpointName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Azure CDN origin group name.", ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string OriginGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Azure CDN origin group ids.", ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public List<Object> OriginIds { get; set; } //PSOriginId[]

        [Parameter(Mandatory = false, HelpMessage = "The number of seconds between health probes.", ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public int? ProbeIntervalInSeconds { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The path relative to the origin that is used to determine the health of the origin.", ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ProbePath { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Protocol to use for health probe.", ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ProbeProtocol { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The type of health probe request that is made.", ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ProbeRequestType { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Azure CDN profile name.", ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ProfileName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The resource group of the Azure CDN profile.", ParameterSetName = FieldsParameterSet)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The CDN origin group object.", ParameterSetName = ObjectParameterSet)]
        [ValidateNotNull]
        public PSOriginGroup CdnOriginGroup { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ObjectParameterSet)
            {
                ResourceGroupName = CdnOriginGroup.ResourceGroupName;
                ProfileName = CdnOriginGroup.ProfileName;
                EndpointName = CdnOriginGroup.EndpointName;
                OriginGroupName = CdnOriginGroup.Name;

                // todo : implement remaining properties on the origin group
            }

            ConfirmAction(MyInvocation.InvocationName, OriginGroupName, CreateOriginGroup);

        }

        public void CreateOriginGroup()
        {
            Management.Cdn.Models.OriginGroup originGroupProperties = new Management.Cdn.Models.OriginGroup();

            // populate properties here

            CdnManagementClient.OriginGroups.Create(
                ResourceGroupName,
                ProfileName,
                EndpointName,
                OriginGroupName,
                originGroupProperties);
        }
    }
}
