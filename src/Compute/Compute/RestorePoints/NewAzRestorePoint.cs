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
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RestorePoint", DefaultParameterSetName = "DefaultParameter", SupportsShouldProcess = true)]
    [OutputType(typeof(PSRestorePoint))]
    public class NewAzureRestorePoint : ComputeAutomationBaseCmdlet
    {

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource group name this resource belongs to")]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the restore point collection this restore point is part of")]
        public string RestorePointCollectionName{ get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the restore point")]
        [Alias("RestorePointName")]
        public string Name { get; set; }

        [Parameter(
            Position = 3,
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = "Set the region of the restore point")]
        public string Location { get; set; }


        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            HelpMessage = "ARM Id of the source restore point")]
        public string RestorePointId { get; set; }


        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            HelpMessage = "List of disk resource Id values that the customer wishes to exclude from the restore point. If no disks are specified, all disks will be included.")]
        public string[] DisksToExclude { get; set; }


        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            HelpMessage = "ConsistencyMode of the restore point. Can be specified in the input while creating a restore point. For now, only CrashConsistent is accepted as a valid input. Please refer to https://aka.ms/RestorePoints for more details.")]
        [PSArgumentCompleter("CrashConsistent", "FileSystemConsistent", "ApplicationConsistent")]
        public string ConsistencyMode { get; set; }


        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                if (ShouldProcess(this.Name, VerbsCommon.New))
                {
                    string resourceGroup = this.ResourceGroupName;
                    string restorePointName = this.Name;
                    string restorePointCollectionName = this.RestorePointCollectionName;
                    string location = this.Location;
                    string restorePointId = this.RestorePointId;
                    List<ApiEntityReference> disksExclude = new List<ApiEntityReference>();

                    RestorePoint restorePoint = new RestorePoint();

                    if(this.IsParameterBound(c=> c.RestorePointId))
                    {
                        restorePoint.SourceRestorePoint = new ApiEntityReference { Id = restorePointId };
                    }

                    if (this.IsParameterBound(c => c.DisksToExclude))
                    {
                        foreach (string s in DisksToExclude)
                        {
                            disksExclude.Add(new ApiEntityReference(s));
                        }
                        restorePoint.ExcludeDisks = disksExclude;
                    }

                    restorePoint.ConsistencyMode = this.ConsistencyMode;

                    var result = RestorePointClient.Create(resourceGroup, restorePointCollectionName, restorePointName, restorePoint);
                        
                    var psObject = new PSRestorePoint();
                    ComputeAutomationAutoMapperProfile.Mapper.Map<RestorePoint, PSRestorePoint>(result, psObject);
                    WriteObject(psObject);
                }
            });
        }
    }
}
