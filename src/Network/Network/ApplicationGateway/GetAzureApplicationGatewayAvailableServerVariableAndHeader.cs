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

using AutoMapper;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.WindowsAzure.Commands.Common;
using System.Collections.Generic;
using System.IO;
using System.Management.Automation;
using System.Reflection;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApplicationGatewayAvailableServerVariableAndHeader"), OutputType(typeof(PSApplicationGatewayAvailableServerVariableAndRequestHeaderResult))]
    [Alias("List-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApplicationGatewayAvailableServerVariableAndHeader")]
    public class GetAzureApplicationGatewayAvailableServerVariableAndHeader : ApplicationGatewayBaseCmdlet
    {
        [Parameter(
            Mandatory = false,
            HelpMessage = "Application Gateway available server variables.")]
        public SwitchParameter ServerVariables;

        [Parameter(
            Mandatory = false,
            HelpMessage = "Application Gateway available request headers.")]
        public SwitchParameter RequestHeaders;

        [Parameter(
            Mandatory = false,
            HelpMessage = "Application Gateway available response headers.")]
        public SwitchParameter ResponseHeaders;

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            IList<string> availableServerVariable;
            IList<string> availableRequestHeader;
            IList<string> availableResponseHeader;
            Dictionary<string, IList<string>> AvailableServerVariableAndHeaderResponse = new Dictionary<string, IList<string>>();
            bool getAllData = ((!this.ServerVariables.IsPresent && !this.RequestHeaders.IsPresent && !this.ResponseHeaders.IsPresent) ||
                (this.ServerVariables.IsPresent && this.RequestHeaders.IsPresent && this.ResponseHeaders.IsPresent));

            if(getAllData || this.ServerVariables.IsPresent)
            {
                availableServerVariable = this.ApplicationGatewayClient.ListAvailableServerVariables();
                AvailableServerVariableAndHeaderResponse.Add("AvailableServerVariable", availableServerVariable);
            }
            if (getAllData || this.RequestHeaders.IsPresent)
            {
                availableRequestHeader = this.ApplicationGatewayClient.ListAvailableRequestHeaders();
                AvailableServerVariableAndHeaderResponse.Add("AvailableRequestHeader", availableRequestHeader);
            }
            if (getAllData || this.ResponseHeaders.IsPresent)
            {
                availableResponseHeader = this.ApplicationGatewayClient.ListAvailableResponseHeaders();
                AvailableServerVariableAndHeaderResponse.Add("AvailableResponseHeader", availableResponseHeader);
            }

            WriteObject(AvailableServerVariableAndHeaderResponse);
        }
    }
}
