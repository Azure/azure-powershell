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
        public SwitchParameter ServerVariable;

        [Parameter(
            Mandatory = false,
            HelpMessage = "Application Gateway available request headers.")]
        public SwitchParameter RequestHeader;

        [Parameter(
            Mandatory = false,
            HelpMessage = "Application Gateway available response headers.")]
        public SwitchParameter ResponseHeader;

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            var AvailableServerVariableAndHeaderResponse = new PSApplicationGatewayAvailableServerVariableAndRequestHeaderResult();
            bool getAllData = ((!this.ServerVariable.IsPresent && !this.RequestHeader.IsPresent && !this.ResponseHeader.IsPresent) ||
                (this.ServerVariable.IsPresent && this.RequestHeader.IsPresent && this.ResponseHeader.IsPresent));

            if(getAllData || this.ServerVariable.IsPresent)
            {
                AvailableServerVariableAndHeaderResponse.AvailableServerVariable = this.ApplicationGatewayClient.ListAvailableServerVariables();
            }
            if (getAllData || this.RequestHeader.IsPresent)
            {
                AvailableServerVariableAndHeaderResponse.AvailableRequestHeader = this.ApplicationGatewayClient.ListAvailableRequestHeaders();
            }
            if (getAllData || this.ResponseHeader.IsPresent)
            {
                AvailableServerVariableAndHeaderResponse.AvailableResponseHeader = this.ApplicationGatewayClient.ListAvailableResponseHeaders();
            }

            WriteObject(AvailableServerVariableAndHeaderResponse);
        }
    }
}
