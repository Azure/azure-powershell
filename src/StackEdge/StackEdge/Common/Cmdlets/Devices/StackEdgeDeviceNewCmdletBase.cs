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
using Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Models;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Net;

namespace Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Common.Cmdlets.Devices
{
    [Cmdlet(VerbsCommon.New,
         Constants.Device,
         DefaultParameterSetName = CreateByNewParameterSet,
         SupportsShouldProcess = true
     ),
     OutputType(typeof(PSStackEdgeDevice))]
    public class StackEdgeDeviceNewCmdletBase : AzureStackEdgeCmdletBase
    {
        private const string CreateByNewParameterSet = "CreateByNewParameterSet";

        [Parameter(Mandatory = true,
            HelpMessage = Constants.ResourceGroupNameHelpMessage,
            ValueFromPipelineByPropertyName = true,
            Position = 0)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = Constants.NameHelpMessage,
            Position = 1)]
        [ValidateNotNullOrEmpty]
        [Alias(HelpMessageDevice.NameAlias)]
        public string Name { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = HelpMessageDevice.LocationHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = HelpMessageDevice.SkuHelpMessage)]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Edge", "Gateway")]
        public string Sku { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.AsJobHelpMessage)]
        public SwitchParameter AsJob { get; set; }

        private DataBoxEdgeDevice GetResourceModel()
        {
            return this.StackEdgeManagementClient.Devices.Get(
                this.Name,
                this.ResourceGroupName);
        }

        private string GetResourceNotFoundMessage()
        {
            return string.Format("'{0}'{1}{2}'.",
                HelpMessageDevice.ObjectName, Constants.ResourceAlreadyExists, this.Name);
        }

        private bool DoesResourceExists()
        {
            try
            {
                var resource = GetResourceModel();
                if (resource == null) return false;
                var msg = GetResourceNotFoundMessage();
                throw new Exception(msg);
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


        private PSStackEdgeDevice CreateResourceModel()
        {
            var dbe = new DataBoxEdgeDevice() {Sku = new Sku(this.Sku), Location = this.Location};
            var device = new PSStackEdgeDevice(
                this.StackEdgeManagementClient.Devices.CreateOrUpdate(
                    this.Name,
                    dbe,
                    this.ResourceGroupName));
            return device;
        }

        public override void ExecuteCmdlet()
        {
            if (this.ShouldProcess(this.Name,
                string.Format("Creating '{0}' with name '{1}'.",
                    HelpMessageDevice.ObjectName, this.Name)))
            {
                DoesResourceExists();
                var results = new List<PSStackEdgeDevice>
                {
                    CreateResourceModel()
                };
                WriteObject(results, true);
            }
        }
    }
}