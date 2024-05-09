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

using Microsoft.Azure.Commands.Maintenance.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Maintenance;
using Microsoft.Azure.Management.Maintenance.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Maintenance
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ScheduledEvent", DefaultParameterSetName = "DefaultParameter", SupportsShouldProcess = true)]
    [OutputType(typeof(PSApplyUpdate))]
    public partial class NewAzureRmScheduledEvent : MaintenanceAutomationBaseCmdlet
    {
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                if (ShouldProcess("default", VerbsCommon.New))
                {
                    string resourceGroupName = this.ResourceGroupName;
                    string resourceType = this.ResourceType;
                    string resourceName = this.ResourceName;
                    string ScheduledEvent = this.ScheduledEventId;
                    ScheduledEventApproveResponse response;
                    response = ScheduledEventClient.Acknowledge(resourceGroupName, resourceType, resourceName, ScheduledEventId);
                    var psObject = new PSSchueduledEvent();
                    MaintenanceAutomationAutoMapperProfile.Mapper.Map<ScheduledEventApproveResponse, PSSchueduledEvent>(response, psObject);
                    WriteObject(psObject);
                }
            });
        }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Position = 0,
            Mandatory = true,
            HelpMessage = "The resource Group Name.",
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Position = 2,
            Mandatory = true,
            HelpMessage = "The resource type.",
            ValueFromPipelineByPropertyName = true)]
        public string ResourceType { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Position = 3,
            Mandatory = true,
            HelpMessage = "The resource name.",
            ValueFromPipelineByPropertyName = true)]
        public string ResourceName { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Mandatory = true,
            HelpMessage = "The ScheduledEvent Id",
            ValueFromPipelineByPropertyName = true)]
        public string ScheduledEventId { get; set; }        
    }
}