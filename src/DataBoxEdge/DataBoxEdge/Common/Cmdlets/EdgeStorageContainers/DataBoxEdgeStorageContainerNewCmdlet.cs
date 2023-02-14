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
using Microsoft.Azure.Management.DataBoxEdge;
using Microsoft.Azure.Management.DataBoxEdge.Models;
using Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Models;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Net;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Common.Cmdlets.EdgeStorageContainers
{
    [Cmdlet(VerbsCommon.New, Constants.EdgeStorageContainer,
         DefaultParameterSetName = EdgeStorageAccountParameterSet,
         SupportsShouldProcess = true
     ),
     OutputType(typeof(PSDataBoxEdgeStorageContainer))]
    public class DataBoxEdgeStorageContainerNewCmdlet : AzureDataBoxEdgeCmdletBase
    {
        private const string EdgeStorageAccountParameterSet = "EdgeStorageAccountParameterSet";

        [Parameter(Mandatory = true,
            HelpMessage = Constants.ResourceGroupNameHelpMessage,
            ValueFromPipelineByPropertyName = true,
            Position = 0)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.DeviceNameHelpMessage,
            Position = 1)]
        [ResourceNameCompleter("Microsoft.DataBoxEdge/dataBoxEdgeDevices", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string DeviceName { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessageEdgeStorageContainer.EdgeStorageAccountHelpMessage,
            Position = 2)]
        [ValidateNotNullOrEmpty]
        public string EdgeStorageAccountName { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.NameHelpMessage,
            Position = 3)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessageEdgeStorageContainer.DataFormatHelpMessage)]
        [PSArgumentCompleter("BlockBlob")]
        [ValidateNotNullOrEmpty]
        public string DataFormat;

        [Parameter(Mandatory = false, HelpMessage = Constants.AsJobHelpMessage)]
        public SwitchParameter AsJob { get; set; }


        private Container GetResource()
        {
            return this.DataBoxEdgeManagementClient.Containers.Get(
                this.DeviceName,
                this.EdgeStorageAccountName,
                this.Name,
                this.ResourceGroupName);
        }

        private string GetResourceAlreadyExistMessage()
        {
            return string.Format("'{0}'{1}{2}'.",
                HelpMessageEdgeStorageContainer.ObjectName, Constants.ResourceAlreadyExists, this.Name);
        }

        private bool DoesResourceExists()
        {
            try
            {
                if (GetResource() == null) return false;
                throw new Exception(GetResourceAlreadyExistMessage());
            }
            catch (CloudException e)
            {
                if (e.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    return false;
                }

                throw;
            }
        }

        private PSDataBoxEdgeStorageContainer CreateResource()
        {
            if (!this.IsParameterBound(c => c.DataFormat))
            {
                DataFormat = "BlockBlob";
            }
            var container = new Container(
                name: Name,
                dataFormat: DataFormat
            );

            return new PSDataBoxEdgeStorageContainer(
                this.DataBoxEdgeManagementClient.Containers.CreateOrUpdate(
                    DeviceName,
                    EdgeStorageAccountName,
                    Name,
                    container,
                    this.ResourceGroupName
                ));
        }

        public override void ExecuteCmdlet()
        {
            if (this.ShouldProcess(this.Name,
                string.Format("Creating '{0}' in device '{1}' with name '{2}'.",
                    HelpMessageEdgeStorageContainer.ObjectName, this.DeviceName, this.Name)))
            {
                DoesResourceExists();
                var results = new List<PSDataBoxEdgeStorageContainer>()
                {
                    CreateResource()
                };

                WriteObject(results, true);
            }
        }
    }
}