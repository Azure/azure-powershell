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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Properties;
using Microsoft.WindowsAzure.Management.Network.Models;
using System;
namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Network.ApplicationGateway
{
    [Cmdlet(VerbsData.Update, "AzureApplicationGateway"), OutputType(typeof(ApplicationGatewayOperationResponse))]
    public class UpdateApplicationGatewayCommand : NetworkCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of Application Gateway")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 1, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Namof of virtual network application gateway should be deployed in")]
        [ValidateNotNullOrEmpty]
        public string VnetName { get; set; }

        [Parameter(Position = 2, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Subnets")]
        [ValidateNotNullOrEmpty]
        public List<string> Subnets { get; set; }        

        [Parameter(Position = 3, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Number of instances")]
        [ValidateNotNullOrEmpty]
        public uint InstanceCount { get; set; }

        [Parameter(Position = 4, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Size of application gateway Small/Medium/Large/ExtraLarge/A8")]
        [ValidateNotNullOrEmpty]
        public string GatewaySize { get; set; }

        [Parameter(Position = 5, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Description of application gateway")]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        public override void ExecuteCmdlet()
        {
            WriteVerboseWithTimestamp(string.Format(Resources.UpdateAzureApplicationGatewayBeginOperation, CommandRuntime.ToString()));

            if (String.IsNullOrEmpty(VnetName) && (Subnets==null || Subnets.Count == 0) &&
                InstanceCount == 0 && String.IsNullOrEmpty(GatewaySize) && String.IsNullOrEmpty(Description))
            {
                WriteObject("Invalid Arguments: Pass at least one argument other than gateway name.");
                WriteVerboseWithTimestamp(string.Format(Resources.UpdateAzureApplicationGatewayCompletedOperation, CommandRuntime.ToString()));
                return;
            }

            var responseObject = Client.UpdateApplicationGateway(Name, VnetName, Subnets, Description, InstanceCount, GatewaySize);
            WriteVerboseWithTimestamp(string.Format(Resources.UpdateAzureApplicationGatewayCompletedOperation, CommandRuntime.ToString()));

            WriteObject(responseObject);
        }
    }
}
