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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Management.DataBoxEdge;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using PSTopLevelResourceModel = Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Models.PSDataBoxEdgeDevice;
using PSResourceModel = Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Models.PSDataBoxEdgeJob;

namespace Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Common.Cmdlets.Jobs
{
    [Cmdlet(VerbsCommon.Get,
         Constants.Job,
         DefaultParameterSetName = GetByNameParameterSet
     ),
     OutputType(typeof(PSResourceModel))]
    public class DataBoxEdgeJobsGetCmdletBase : AzureDataBoxEdgeCmdletBase
    {
        private const string GetByNameParameterSet = "GetByNameParameterSet";
        private const string GetByResourceIdObject = "GetByResourceIdObject";
        private const string GetByParentObjectParameterSet = "GetByParentObjectParameterSet";

        [Parameter(Mandatory = true,
            ParameterSetName = GetByResourceIdObject,
            HelpMessage = Constants.ResourceIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = GetByNameParameterSet,
            HelpMessage = Constants.ResourceGroupNameHelpMessage,
            Position = 0)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = GetByNameParameterSet,
            HelpMessage = HelpMessageJobs.DeviceName,
            Position = 1)]
        [ResourceNameCompleter("Microsoft.DataBoxEdge/dataBoxEdgeDevices", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string DeviceName { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = GetByNameParameterSet,
            HelpMessage = HelpMessageJobs.Name,
            Position = 2)]
        [Parameter(Mandatory = true,
            ParameterSetName = GetByParentObjectParameterSet,
            HelpMessage = HelpMessageJobs.Name
        )]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true,
            ParameterSetName = GetByParentObjectParameterSet,
            HelpMessage = Constants.PsDeviceObjectHelpMessage)]
        [ValidateNotNull]
        public PSTopLevelResourceModel DeviceObject;


        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => this.ResourceId))
            {
                var resourceIdentifier = new DataBoxEdgeResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = this.ResourceGroupName;
                this.DeviceName = this.DeviceName;
                this.Name = this.Name;
            }

            if (this.IsParameterBound(c => this.DeviceObject))
            {
                this.ResourceGroupName = this.DeviceObject.ResourceGroupName;
                this.DeviceName = this.DeviceObject.Name;
            }

            var results = new List<PSResourceModel>();
            if (!string.IsNullOrEmpty(this.Name) &&
                !string.IsNullOrEmpty(this.DeviceName) &&
                !string.IsNullOrEmpty(this.ResourceGroupName))
            {
                results.Add(
                    new PSResourceModel(
                        JobsOperationsExtensions.Get(
                            this.DataBoxEdgeManagementClient.Jobs,
                            this.DeviceName,
                            this.Name,
                            this.ResourceGroupName
                        )
                    )
                );
            }

            WriteObject(results, true);
        }
    }
}