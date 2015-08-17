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

using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Properties;
using Microsoft.WindowsAzure.Management.Network.Models;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Network.ApplicationGateway
{
    [Cmdlet(VerbsLifecycle.Stop, "AzureApplicationGateway"), OutputType(typeof(ApplicationGatewayOperationResponse))]
    public class StopApplicationGatewayCommand : NetworkCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Application Gateway Name representing the Application Gateway")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            WriteVerboseWithTimestamp(string.Format(Resources.StopAzureApplicationGatewayBeginOperation, CommandRuntime.ToString()));
            var responseObject = Client.ExecuteApplicationGatewayOperation(Name, "stop");
            WriteVerboseWithTimestamp(string.Format(Resources.StopAzureApplicationGatewayCompletedOperation, CommandRuntime.ToString()));

            WriteObject(responseObject);
        }
    }
}
