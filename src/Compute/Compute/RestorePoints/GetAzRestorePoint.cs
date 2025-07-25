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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RestorePoint", DefaultParameterSetName = "DefaultParameter")]
    [OutputType(typeof(PSRestorePoint))]
    public class GetAzureRestorePoint : ComputeAutomationBaseCmdlet
    {

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        public string RestorePointCollectionName{ get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [Alias("RestorePointName")]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        public SwitchParameter InstanceView { get; set; }


        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                string resourceGroup = this.ResourceGroupName;
                string restorePointName = this.Name;
                string restorePointCollectionName = this.RestorePointCollectionName;
                bool instanceViewTrue = this.InstanceView.IsPresent;

                if (instanceViewTrue == true)
                {
                    var result = RestorePointClient.Get(resourceGroup, restorePointCollectionName, restorePointName, "InstanceView");
                    var psObject = new PSRestorePoint();
                    ComputeAutomationAutoMapperProfile.Mapper.Map<RestorePoint, PSRestorePoint>(result, psObject);
                    WriteObject(psObject);
                }
                else
                {
                    var result = RestorePointClient.Get(resourceGroup, restorePointCollectionName, restorePointName);
                    var psObject = new PSRestorePoint();
                    ComputeAutomationAutoMapperProfile.Mapper.Map<RestorePoint, PSRestorePoint>(result, psObject);
                    WriteObject(psObject);
                }
            });
        }
    }
}
