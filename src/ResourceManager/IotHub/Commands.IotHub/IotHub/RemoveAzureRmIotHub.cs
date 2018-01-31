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
    using System.Globalization;
    using System.Management.Automation;
    using Microsoft.Azure.Management.IotHub;
    using PSIotHubProperties = Microsoft.Azure.Commands.Management.IotHub.Properties;
    using ResourceManager.Common.ArgumentCompleters;

    [Cmdlet(VerbsCommon.Remove, "AzureRmIotHub", SupportsShouldProcess = true)]
    public class RemoveAzureRmIotHub : IotHubBaseCmdlet
    {

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the Resource Group")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the Iot Hub")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }
        
        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Name, Properties.Resources.RemoveIotHub))
            {
                try
                {
                    this.IotHubClient.IotHubResource.Delete(this.ResourceGroupName, this.Name);
                }
                catch (Exception e)
                {
                    // This is because the underlying IotHubClient sdk currently throws an exception when it receives a 404 during the 
                    // long running delete operation. Remove this once the sdk is fixed to handle this.

                    if (!e.Message.Contains("NotFound"))
                    {
                        throw e;
                    }
                }
            }
        }
    }
}
