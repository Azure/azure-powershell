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
using PowerShellAppGwModel = Microsoft.WindowsAzure.Commands.ServiceManagement.Network.ApplicationGateway.Model;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Network.ApplicationGateway
{
    [Cmdlet(VerbsCommon.Get, "AzureApplicationGateway"), OutputType(typeof(PowerShellAppGwModel.ApplicationGateway), typeof(IEnumerable<PowerShellAppGwModel.ApplicationGateway>))]
    public class GetApplicationGatewayCommand : NetworkCmdletBase
    {
        [Parameter(Position = 0, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Application Gateway Name representing the Application Gateway")]        
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrEmpty(Name))
            {
                GetByGatewayName();
            }
            else
            {
                GetNoGatewayName();
            }
        }

        private void GetByGatewayName()
        {
            WriteVerboseWithTimestamp(string.Format(Resources.GetAzureApplicationGatewayBeginOperation, CommandRuntime.ToString()));
            var gateway = Client.GetApplicationGateway(Name);
            WriteVerboseWithTimestamp(string.Format(Resources.GetAzureApplicationGatewayCompletedOperation, CommandRuntime.ToString()));

            WriteObject(gateway);
        }

        private void GetNoGatewayName()
        {
            WriteVerboseWithTimestamp(string.Format(Resources.GetAzureApplicationGatewayBeginOperation, CommandRuntime.ToString()));
            var gateways = Client.ListApplicationGateway();
            WriteVerboseWithTimestamp(string.Format(Resources.GetAzureApplicationGatewayCompletedOperation, CommandRuntime.ToString()));

            WriteObject(gateways, true);   
        }
    }
}
