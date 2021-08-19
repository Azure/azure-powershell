﻿// ----------------------------------------------------------------------------------
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
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RestorePointCollection", DefaultParameterSetName = "DefaultParameter", SupportsShouldProcess = true)]
    [OutputType(typeof(PSRestorePointCollection))]
    public class NewAzureRestorePointCollection : ComputeAutomationBaseCmdlet
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
        [Alias("RestorePointCollectionName")]
        public string Name { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true,
            ValueFromPipeline = true)]
        public string VmId { get; set; }

        [Parameter(
            Position = 3,
            Mandatory = true,
            ValueFromPipeline = true)]
        public string Location { get; set; }


        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                if (ShouldProcess(this.Name, VerbsCommon.New))
                {
                    string resourceGroup = this.ResourceGroupName;
                    string restorePointCollectionName = this.Name;
                    string vmId = this.VmId;
                    string location = this.Location;

                    RestorePointCollection restorePointCollection = new RestorePointCollection(location);
                    restorePointCollection.Source = new RestorePointCollectionSourceProperties() { Id = vmId }; 

                    var result = RestorePointCollectionsClient.CreateOrUpdate(resourceGroup, restorePointCollectionName, restorePointCollection);
                    var psObject = new PSRestorePointCollection();
                    ComputeAutomationAutoMapperProfile.Mapper.Map<RestorePointCollection, PSRestorePointCollection>(result, psObject);
                    WriteObject(psObject);
                }
            });
        }
    }
}
