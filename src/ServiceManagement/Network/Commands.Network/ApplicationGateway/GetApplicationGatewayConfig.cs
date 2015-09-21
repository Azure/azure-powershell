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
    [Cmdlet(VerbsCommon.Get, "AzureApplicationGatewayConfig"), OutputType(typeof(PowerShellAppGwModel.ApplicationGatewayConfigContext))]
    public class GetApplicationGatewayConfigCommand : NetworkCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Application Gateway Name representing the Application Gateway")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The file path to save the application gateway configuration to.")]
        [ValidateNotNullOrEmpty]
        public string ExportToFile  { get; set; }

        public override void ExecuteCmdlet()
        {
            WriteVerboseWithTimestamp(string.Format(Resources.GetAzureApplicationGatewayConfigBeginOperation, CommandRuntime.ToString()));
            PowerShellAppGwModel.ApplicationGatewayConfigContext config = Client.GetApplicationGatewayConfig(Name);

            if (!string.IsNullOrEmpty(this.ExportToFile))
            {
                config.ExportToFile(this.ExportToFile);
            }

            WriteVerboseWithTimestamp(string.Format(Resources.GetAzureApplicationGatewayConfigCompletedOperation, CommandRuntime.ToString()));

            WriteObject(config);
        }
    }
}
